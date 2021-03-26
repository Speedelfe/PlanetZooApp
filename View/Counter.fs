namespace PlanetZooApp

module Counter =
    open Avalonia.Controls
    open Avalonia.Controls.Primitives
    open Avalonia.FuncUI.DSL
    open Avalonia.FuncUI.Types
    open Avalonia.Layout
    open PlanetZooApp.Functions
    open PlanetZooApp.Types
    open PlanetZooApp.ViewHelpers
    open PlanetZooApp.DetailView
    open Avalonia.FuncUI.Components
    open Elmish


    let init animalMap =
        let state =
            {
                animalMap = animalMap
                continentListFilter = None
                viewMode = ListView
            }

        state, (Cmd.ofMsg LookForImageJob)

    let update (msg: Msg) (state: State) =
        match msg with
        | ChooseAnimal animal ->
            let state =
                { state with
                    viewMode = DetailView animal
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
            let state = { state with viewMode = ListView }
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
        | ShowFilterView ->
            let state = { state with viewMode = FilterView }
            state, Cmd.none

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


    let filterView (state: State) dispatch : IView =
        DockPanel.create [
            DockPanel.children [
                Button.create [
                    Button.content "Zurück"
                    Button.onClick (fun _ -> dispatch ShowAnimalList)
                ]
                Button.create [
                    Button.content "Filter nach Continent"
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
                            Button.onClick (fun _ -> dispatch ShowFilterView)

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
        match state.viewMode with
        | ListView -> listView state dispatch
        | DetailView currentAnimal -> viewAnimalDetails (currentAnimal) dispatch
        | FilterView -> filterView state dispatch
