namespace PlanetZooApp

module MainView =
    open Avalonia.Controls
    open Avalonia.Controls.Primitives
    open Avalonia.FuncUI.DSL
    open Avalonia.FuncUI.Types
    open Avalonia.Layout
    open PlanetZooApp.Functions
    open PlanetZooApp.Types
    open PlanetZooApp.ViewHelpers
    open PlanetZooApp.DetailView
    open PlanetZooApp.FilterView
    open PlanetZooApp.FilterFunctions
    open Avalonia.FuncUI.Components
    open Elmish


    let init () =
        let state =
            {
                animalMap = Map.empty
                continentListFilter = None
                dlcListFilter = None
                biomeListFilter = None
                regionListFilter = None
                vivariumFilter = false
                notVivariumFilter = false
                viewMode = ListView
                isFiltered = false
            }

        (*loadFile ()*)

        state, (Cmd.OfAsync.either loadAnimalData () SaveAnimalData AsyncError)

    let update (msg: Msg) (state: State) =
        match msg with
        | SaveAnimalData map ->
            let state = { state with animalMap = map }

            state, Cmd.ofMsg LookForImageJob
        | ChooseAnimal animal ->
            let state =
                { state with
                    viewMode = DetailView animal
                }

            state, Cmd.none
        | LookForImageJob ->
            let chooser key animal =
                match animal.image_url, animal.image_path with
                | Some url, None -> Some(key, url)
                | _ -> None

            let cmd =
                match Map.tryPick chooser state.animalMap with
                | Some (key, url) -> DownloadImage(key, url) |> Cmd.ofMsg
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
                let setImagePath animal =
                    { animal with
                        image_path = Some imgPath
                    }

                let animalMap =
                    Map.change key (Option.map setImagePath) state.animalMap

                { state with animalMap = animalMap }

            state, Cmd.ofMsg LookForImageJob
        | AsyncError ex -> raise ex
        | ShowAnimalList ->
            let state = { state with viewMode = ListView }
            state, Cmd.none
        | SetIsFiltered isFiltered ->
            let state = { state with isFiltered = isFiltered }
            state, Cmd.none
        | FilterAnimalListByContinent continentList ->
            let state =
                { state with
                    continentListFilter = Some continentList
                }

            state, Cmd.none
        | RemoveContinentFromFilterList continent ->
            let newContinentList : Continent List =
                match state.continentListFilter with
                | Some continentList -> (List.except [ continent ] continentList)
                | None -> [] // Fall trifft nie zu deshalb egal

            let state =
                { state with
                    continentListFilter =
                        match newContinentList with
                        | [] -> None
                        | continentList -> Some continentList
                }

            state, Cmd.none
        | FilterAnimalListByDLC dlcList ->
            let state =
                { state with
                    dlcListFilter = Some dlcList
                }

            state, Cmd.none
        | RemoveDlcFromFilterList dlc ->
            let newDlcList : Dlc List =
                match state.dlcListFilter with
                | Some dlcList -> (List.except [ dlc ] dlcList)
                | None -> []

            let state =
                { state with
                    dlcListFilter =
                        match newDlcList with
                        | [] -> None
                        | dlcList -> Some dlcList
                }

            state, Cmd.none
        | FilterAnimalListByBiome biomeList ->
            let state =
                { state with
                    biomeListFilter = Some biomeList
                }

            state, Cmd.none
        | RemoveBiomeFromFilterList biome ->
            let newBiomeList : Biome List =
                match state.biomeListFilter with
                | Some biomeList -> (List.except [ biome ] biomeList)
                | None -> []

            let state =
                { state with
                    biomeListFilter =
                        match newBiomeList with
                        | [] -> None
                        | biomeList -> Some biomeList
                }

            state, Cmd.none
        | FilterAnimalListByRegion regionList ->
            let state =
                { state with
                    regionListFilter = Some regionList
                }

            state, Cmd.none
        | RemoveRegionFromFilterList region ->
            let newRegionList : Region List =
                match state.regionListFilter with
                | Some regionList -> (List.except [ region ] regionList)
                | None -> []

            let state =
                { state with
                    regionListFilter =
                        match newRegionList with
                        | [] -> None
                        | regionList -> Some regionList
                }

            state, Cmd.none
        | FilterAnimalListByVivarium isVivarium ->
            let state =
                { state with
                    vivariumFilter = isVivarium
                    notVivariumFilter =
                        match isVivarium with
                        | true -> not isVivarium
                        | false -> isVivarium
                }

            state, Cmd.none
        | FilterAnimalListByNotVivarium isNotVivarium ->
            let state =
                { state with
                    notVivariumFilter = isNotVivarium
                    vivariumFilter =
                        match isNotVivarium with
                        | true -> not isNotVivarium
                        | false -> isNotVivarium
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
                TextBlock.create [
                    TextBlock.padding (0., 10.)
                    TextBlock.fontSize 20.0
                    TextBlock.text ($"({animal.nameGerman})")
                ]
            ]
        ]

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
                            Button.content "Filter"
                            Button.onClick (fun _ -> dispatch ShowFilterView)
                        ]
                    ]
                ]

                let animalList =
                    state.animalMap
                    |> Map.toList
                    |> List.map snd
                    // Kontinentfilter
                    |> (fun animalList ->
                        match state.continentListFilter with
                        | None -> animalList
                        | Some continentListFilter -> filtercontinent animalList continentListFilter)
                    // DLCfilter
                    |> (fun animalList ->
                        match state.dlcListFilter with
                        | None -> animalList
                        | Some dlcListFilter -> filterDLC animalList dlcListFilter)
                    // BiomeFilter
                    |> (fun animalList ->
                        match state.biomeListFilter with
                        | None -> animalList
                        | Some biomeListFilter -> filterBiome animalList biomeListFilter)
                    // RegionFilter
                    |> (fun animalList ->
                        match state.regionListFilter with
                        | None -> animalList
                        | Some regionListFilter -> filterRegion animalList regionListFilter)
                    // Vivarium Tier Filter
                    |> (fun animalList ->
                        match state.vivariumFilter with
                        | false -> animalList
                        | true -> filterVivarium animalList)
                    // Gehege Tier Filter
                    |> (fun animalList ->
                        match state.notVivariumFilter with
                        | false -> animalList
                        | true -> filterNotVivarium animalList)

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
        | FilterView -> viewFilterView state dispatch
