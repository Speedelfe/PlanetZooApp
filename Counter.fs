namespace PlanetZooApp

module Counter =
    open Avalonia.Controls
    open Avalonia.Controls.Primitives
    open Avalonia.FuncUI.DSL
    open Avalonia.FuncUI.Types
    open Avalonia.Layout
    open PlanetZooApp.FileManagement
    open PlanetZooApp.Types
    open Avalonia.FuncUI.Components
    open Avalonia.FuncUI.Components.Hosts
    open Avalonia.FuncUI.Elmish
    open Avalonia.Input
    open Avalonia.Threading
    open Avalonia.Media.Imaging
    open Elmish

    type State =
        {
            animalMap: Map<AnimalKey, ZooAnimal>
            // Wenn wir hier ein Tier haben, zeigen wir die Details an und nicht die Liste
            detailViewOf: ZooAnimal option
        }

    type Msg =
        | ChooseAnimal of ZooAnimal
        | LookForImageJob
        | DownloadImage of (AnimalKey * string)
        | SaveImage of (AnimalKey * string)
        | AsyncError of exn

    let init animalMap =
        let state =
            {
                animalMap = animalMap
                detailViewOf = None
            }

        state, (Cmd.ofMsg LookForImageJob)

    let update (msg: Msg) (state: State) =
        match msg with
        | ChooseAnimal animal ->
            let state =
                { state with
                    detailViewOf = Some animal
                }

            state, Cmd.none
        | LookForImageJob ->
            let chooser key animal =
                match animal.image_path with
                | Some _ -> None
                | None -> Some(key, animal)

            let cmd =
                match Map.tryPick chooser state.animalMap with
                | Some (key, animal) -> DownloadImage(key, animal.image_url) |> Cmd.ofMsg
                | None -> Cmd.none

            state, cmd
        | DownloadImage (key, url) ->
            let cmd =
                match downloadImage key url with
                | HasToBeDownloaded job -> Cmd.OfAsync.either job () (fun imgPath -> SaveImage(key, imgPath)) AsyncError
                | AlreadyDownloaded imgPath -> SaveImage(key, imgPath) |> Cmd.ofMsg

            state, cmd
        | SaveImage (key, imgPath) ->
            let state =
                { state with
                    animalMap =
                        Map.change
                            key
                            (Option.map
                                (fun animal ->
                                    { animal with
                                        image_path = Some imgPath
                                    }))
                            state.animalMap
                }

            state, Cmd.ofMsg LookForImageJob
        | AsyncError ex -> raise ex

    let animalItemView (animal: ZooAnimal) =
        StackPanel.create [
            StackPanel.orientation Orientation.Horizontal
            StackPanel.spacing 5.
            StackPanel.children [
                match animal.image_path with
                | Some imgPath ->
                    Image.create [
                        Image.height 50.0
                        Image.width 50.0
                        Image.source (new Bitmap(imgPath))
                    ]
                | None -> () // TODO: irgendwas tun
                TextBlock.create [
                    TextBlock.fontSize 14.0
                    TextBlock.text (animal.name)
                ]
            ]
        ]

    let viewAnimalDetails (animal: ZooAnimal) : IView =
        ScrollViewer.create [
            ScrollViewer.dock Dock.Bottom
            ScrollViewer.horizontalScrollBarVisibility ScrollBarVisibility.Disabled
            ScrollViewer.content (
                StackPanel.create [
                    StackPanel.orientation Orientation.Vertical
                    StackPanel.children [
                        TextBlock.create [
                            TextBlock.fontSize 14.0
                            TextBlock.text ($"{animal}")
                        ]
                    ]
                ]
            )
        ]
        :> IView

    let listView (state: State) dispatch : IView =
        DockPanel.create [
            DockPanel.children [
                StackPanel.create [
                    StackPanel.dock Dock.Top
                    StackPanel.orientation Orientation.Horizontal
                    StackPanel.spacing 10.
                    StackPanel.children [
                        TextBox.create [
                            TextBox.text "Suche nach Name" //TODO: Funktion zum Suchen nach Animal Name
                        ]
                        Button.create [
                            Button.content "Filter" //TODO: Click Event -> Filter "Fenster" öffnen
                        ]
                    ]
                ]
                let animalList =
                    state.animalMap |> Map.toList |> List.map snd

                ListBox.create [
                    ListBox.dataItems animalList
                    ListBox.itemTemplate (DataTemplateView<ZooAnimal>.create animalItemView)
                    ListBox.onSelectedIndexChanged (
                        (fun index ->
                            if index > 0 then
                                animalList.Item index |> ChooseAnimal |> dispatch),
                        Always
                    )
                ]
            ]
        ]
        :> IView

    let view state dispatch =
        match state.detailViewOf with
        | None -> listView state dispatch
        | Some currentAnimal -> viewAnimalDetails (currentAnimal)
