namespace PlanetZooApp

module Counter =
    open Avalonia.Controls
    open Avalonia.Controls.Primitives
    open Avalonia.FuncUI.DSL
    open Avalonia.FuncUI.Types
    open Avalonia.Layout
    open PlanetZooApp.Functions
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
            continentListFilter: Continent List option
        }

    type Msg =
        | ChooseAnimal of ZooAnimal
        | LookForImageJob
        | DownloadImage of (AnimalKey * string)
        | SaveImage of (AnimalKey * string)
        | AsyncError of exn
        | ShowAnimalList
        | FilterAnimalListByContinent of Continent List
        | CLearFilterContinent

    let init animalMap =
        let state =
            {
                animalMap = animalMap
                detailViewOf = None
                continentListFilter = None
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
        | ShowAnimalList ->
            let state = { state with detailViewOf = None }
            state, Cmd.none
        | FilterAnimalListByContinent continentList ->
            let state =
                { state with
                    continentListFilter = Some continentList
                }

            state, Cmd.none
        | CLearFilterContinent ->
            let state =
                { state with
                    continentListFilter = None
                }

            state, Cmd.none


    let animalImage (imgPath: string) height width =
        Image.create [
            Image.height height
            Image.width width
            Image.source (new Bitmap(imgPath))
        ]


    let animalItemView (animal: ZooAnimal) =
        StackPanel.create [
            StackPanel.orientation Orientation.Horizontal
            StackPanel.spacing 5.
            StackPanel.children [
                match animal.image_path with
                | Some imgPath -> animalImage imgPath 50. 80.
                | None -> () // TODO: irgendwas tun
                TextBlock.create [
                    TextBlock.padding (0., 10.)
                    TextBlock.fontSize 20.0
                    TextBlock.text (animal.name)
                ]
            ]
        ]

    let viewAnimalDetailsContentHeader (animal: ZooAnimal) : IView =
        StackPanel.create [
            StackPanel.orientation Orientation.Horizontal
            StackPanel.children [
                match animal.image_path with
                | Some imgPath -> animalImage imgPath 160. 200.
                | None -> () // TODO: irgendwas tun

                StackPanel.create [
                    StackPanel.orientation Orientation.Vertical
                    StackPanel.children [
                        TextBlock.create [
                            TextBlock.fontSize 20.
                            TextBlock.padding (5., 5.)
                            TextBlock.text animal.name
                        ]
                        TextBlock.create [
                            TextBlock.fontSize 14.0
                            TextBlock.padding (5., 5.)
                            TextBlock.text animal.latin_name
                        ]
                        TextBlock.create [
                            TextBlock.fontSize 12.
                            TextBlock.lineHeight 16.
                            TextBlock.maxWidth 500.
                            TextBlock.padding (5., 5.)
                            TextBlock.textWrapping Avalonia.Media.TextWrapping.Wrap
                            TextBlock.text animal.description
                        ]
                    ]
                ]
            ]
        ]
        :> IView

    // let blaa (text: string) =
    //     text.Replace()
    //     text.Trim()

    let viewAnimalDetailsContentHabitatRequirements (habitatRequirements: HabitatRequirements) : IView =
        StackPanel.create [
            StackPanel.orientation Orientation.Vertical
            StackPanel.children [
                TextBlock.create [
                    TextBlock.fontSize 14.0
                    TextBlock.text "Habitat min requirements"
                ]
                StackPanel.create [
                    StackPanel.orientation Orientation.Horizontal
                    StackPanel.children [
                        TextBlock.create [
                            TextBlock.padding (5., 0.)
                            TextBlock.text "Land:"
                        ]
                        TextBlock.create [
                            TextBlock.padding (5., 0.)
                            match habitatRequirements.land_ with
                            | Some landArea -> TextBlock.text ($"{landArea}")
                            | None -> ()
                        ]
                        TextBlock.create [ TextBlock.text "m²" ]
                    ]
                ]
                StackPanel.create [
                    StackPanel.orientation Orientation.Horizontal
                    StackPanel.children [
                        TextBlock.create [
                            TextBlock.padding (5., 0.)
                            TextBlock.text "Water:"
                        ]
                        TextBlock.create [
                            TextBlock.padding (5., 0.)
                            match habitatRequirements.water with
                            | Some waterArea -> TextBlock.text ($"{waterArea}")
                            | None -> ()
                        ]
                        TextBlock.create [ TextBlock.text "m²" ]
                    ]
                ]
            ]
        ]
        :> IView

    let viewAnimalDetailsContent (animal: ZooAnimal) dispatch : IView =
        ScrollViewer.create [
            ScrollViewer.horizontalScrollBarVisibility ScrollBarVisibility.Disabled
            ScrollViewer.content (
                StackPanel.create [
                    StackPanel.orientation Orientation.Vertical
                    StackPanel.children [
                        viewAnimalDetailsContentHeader animal

                        viewAnimalDetailsContentHabitatRequirements animal.habitat_requirements

                        TextBlock.create [
                            TextBlock.fontSize 14.0
                            TextBlock.text ($"{animal}")
                        ]
                    ]
                ]
            )
        ]
        :> IView

    let viewAnimalDetails (animal: ZooAnimal) dispatch : IView =
        DockPanel.create [
            DockPanel.children [
                Button.create [
                    DockPanel.dock Dock.Top
                    Button.content "Zurück"
                    Button.onClick (fun _ -> dispatch ShowAnimalList)
                ]
                viewAnimalDetailsContent animal dispatch
            ]
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
                            Button.content "Filter Europa" //TODO: Click Event -> Filter "Fenster" öffnen
                            Button.onClick (
                                (fun _ ->
                                    match state.continentListFilter with
                                    | Some _ -> dispatch CLearFilterContinent
                                    | None -> FilterAnimalListByContinent [ Europe ] |> dispatch),
                                OnChangeOf state.continentListFilter
                            )
                        ]
                    ]
                ]
                let fullanimalList =
                    state.animalMap |> Map.toList |> List.map snd

                let animalList =
                    match state.continentListFilter with
                    | None -> fullanimalList
                    | Some continentListFilter -> filtercontinent fullanimalList continentListFilter

                ListBox.create [
                    ListBox.dataItems animalList
                    ListBox.itemTemplate (DataTemplateView<ZooAnimal>.create animalItemView)
                    ListBox.onSelectedIndexChanged (
                        (fun index ->
                            if index >= 0 then
                                animalList.Item index |> ChooseAnimal |> dispatch),
                        OnChangeOf animalList
                    )
                ]

            ]

        ]
        :> IView

    let view state dispatch =
        match state.detailViewOf with
        | None -> listView state dispatch
        | Some currentAnimal -> viewAnimalDetails (currentAnimal) dispatch
