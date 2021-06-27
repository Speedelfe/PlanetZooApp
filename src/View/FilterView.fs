namespace PlanetZooApp

module FilterView =
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

    let renderFilterHeadline label : IView =
        TextBlock.create [
            TextBlock.dock Dock.Top
            TextBlock.fontSize 20.
            TextBlock.margin 5.
            TextBlock.text label
        ]
        :> IView

    let renderToggleButtonFilter addMsg removeMsg toString dispatch filterList filter : IView =
        let filterOptionInState = (List.contains filter filterList)

        ToggleButton.create [
            ToggleButton.isChecked filterOptionInState
            ToggleButton.onClick (
                (fun _ ->
                    match filterOptionInState with
                    | false -> (filter :: filterList) |> addMsg |> dispatch
                    | true -> filter |> removeMsg |> dispatch),
                OnChangeOf(filterOptionInState, filterList)
            )
            ToggleButton.content ((toString filter): string)
            ToggleButton.margin 5.
            ToggleButton.height 40.
            ToggleButton.padding (20., 5.)
        ]
        :> IView

    let renderToggleFilterButtonContinent =
        renderToggleButtonFilter FilterAnimalListByContinent RemoveContinentFromFilterList continentToString

    let renderToggleFilterButtonDLC =
        renderToggleButtonFilter FilterAnimalListByDLC RemoveDlcFromFilterList dlcToString

    let renderToggleFilterButtonBiome =
        renderToggleButtonFilter FilterAnimalListByBiome RemoveBiomeFromFilterList string

    let renderToggleFilterButtonRegion =
        renderToggleButtonFilter FilterAnimalListByRegion RemoveRegionFromFilterList string



    let viewContinentsFilterOptions (state: State) dispatch : IView =
        let continentList : Continent List =
            match state.continentListFilter with
            | Some continentList -> continentList
            | None -> []

        let renderToggleFilterButtonContinent =
            renderToggleFilterButtonContinent dispatch continentList

        DockPanel.create [
            DockPanel.dock Dock.Top
            DockPanel.children [
                renderFilterHeadline "Continents"
                WrapPanel.create [
                    WrapPanel.dock Dock.Top
                    WrapPanel.margin (20., 10.)
                    WrapPanel.children [
                        renderToggleFilterButtonContinent Continent.Africa
                        renderToggleFilterButtonContinent Asia
                        renderToggleFilterButtonContinent CentralAmerica
                        renderToggleFilterButtonContinent Europe
                        renderToggleFilterButtonContinent Continent.SouthAmerica
                        renderToggleFilterButtonContinent NorthAmerica
                        renderToggleFilterButtonContinent Oceania
                    ]
                ]
            ]
        ]
        :> IView

    let viewDLCFilterOption (state: State) dispatch : IView =
        let dlcList : Dlc List =
            match state.dlcListFilter with
            | Some dlcList -> dlcList
            | None -> []

        let renderToggleFilterButtonDLC =
            renderToggleFilterButtonDLC dispatch dlcList

        DockPanel.create [
            DockPanel.dock Dock.Top
            DockPanel.children [
                renderFilterHeadline "DLCs"
                WrapPanel.create [
                    WrapPanel.dock Dock.Top
                    WrapPanel.margin (20., 10.)
                    WrapPanel.children [
                        renderToggleFilterButtonDLC Arctic
                        renderToggleFilterButtonDLC Aquatic
                        renderToggleFilterButtonDLC Australia
                        renderToggleFilterButtonDLC Deluxe
                        renderToggleFilterButtonDLC SouthAmerica
                        renderToggleFilterButtonDLC SoutheastAsia
                    ]
                ]
            ]
        ]
        :> IView

    let viewBiomeFilterOption (state: State) dispatch : IView =
        let biomeList =
            state.biomeListFilter |> Option.defaultValue []

        let renderToggleFilterButtonBiome =
            renderToggleFilterButtonBiome dispatch biomeList

        DockPanel.create [
            DockPanel.dock Dock.Top
            DockPanel.children [
                renderFilterHeadline "Biome"
                WrapPanel.create [
                    WrapPanel.dock Dock.Top
                    WrapPanel.margin (20., 10.)
                    WrapPanel.children [
                        renderToggleFilterButtonBiome Biome.Aquatic
                        renderToggleFilterButtonBiome Desert
                        renderToggleFilterButtonBiome Grassland
                        renderToggleFilterButtonBiome Taiga
                        renderToggleFilterButtonBiome Temperate
                        renderToggleFilterButtonBiome Tropical
                        renderToggleFilterButtonBiome Tundra
                    ]
                ]
            ]
        ]
        :> IView

    let viewRegionFilterOption (state: State) dispatch : IView =
        let regions =
            state.animalMap
            |> Map.toList
            |> List.map snd
            |> regionsFromAnimalList
            |> Set.toList

        let filteredRegionList =
            match state.regionListFilter with
            | Some regionList -> regionList
            | None -> []

        let renderToggleFilterButtonRegion =
            renderToggleFilterButtonRegion dispatch filteredRegionList

        DockPanel.create [
            DockPanel.dock Dock.Top
            DockPanel.children [
                renderFilterHeadline "Region"
                WrapPanel.create [
                    WrapPanel.dock Dock.Top
                    WrapPanel.margin (20., 10.)
                    WrapPanel.children [
                        for region in regions do
                            renderToggleFilterButtonRegion region
                    ]
                ]
            ]
        ]
        :> IView


    let viewHabitationFilter (state: State) dispatch : IView =
        let isVivariumFiltered : bool = state.vivariumFilter
        let isNotVivariumFiltered : bool = state.notVivariumFilter

        DockPanel.create [
            DockPanel.dock Dock.Top
            DockPanel.children [
                renderFilterHeadline "Vivarium/Gehege"
                WrapPanel.create [
                    WrapPanel.dock Dock.Top
                    WrapPanel.margin (20., 10.)
                    WrapPanel.children [
                        ToggleButton.create [
                            ToggleButton.isChecked isVivariumFiltered
                            ToggleButton.onClick (
                                (fun _ ->
                                    not isVivariumFiltered
                                    |> FilterAnimalListByVivarium
                                    |> dispatch),
                                OnChangeOf(isVivariumFiltered)
                            )
                            ToggleButton.content "Vivarium"
                            ToggleButton.margin 5.
                            ToggleButton.height 40.
                            ToggleButton.padding (20., 5.)
                        ]
                        ToggleButton.create [
                            ToggleButton.isChecked isNotVivariumFiltered
                            ToggleButton.onClick (
                                (fun _ ->
                                    not isNotVivariumFiltered
                                    |> FilterAnimalListByNotVivarium
                                    |> dispatch),
                                OnChangeOf(isNotVivariumFiltered)
                            )
                            ToggleButton.content "Gehege"
                            ToggleButton.margin 5.
                            ToggleButton.height 40.
                            ToggleButton.padding (20., 5.)
                        ]
                    ]
                ]
            ]
        ]
        :> IView

    let viewFilterView (state: State) dispatch : IView =
        DockPanel.create [
            DockPanel.children [
                StackPanel.create [
                    StackPanel.dock Dock.Bottom
                    StackPanel.orientation Orientation.Horizontal
                    StackPanel.children [
                        Button.create [
                            Button.content "Zurück"
                            Button.onClick (fun _ -> dispatch ShowAnimalList)
                        ]
                        Button.create [
                            Button.content "Filter anwenden"
                            Button.onClick (
                                (fun _ -> ShowAnimalList |> dispatch)

                            )
                        ]
                    ]
                ]
                ScrollViewer.create [
                    ScrollViewer.horizontalScrollBarVisibility ScrollBarVisibility.Disabled
                    ScrollViewer.content (
                        StackPanel.create [
                            StackPanel.children [
                                viewContinentsFilterOptions state dispatch
                                viewDLCFilterOption state dispatch
                                viewBiomeFilterOption state dispatch
                                viewRegionFilterOption state dispatch
                                viewHabitationFilter state dispatch
                            ]
                        ]


                    //StackPanel.create []
                    )
                ]
            ]
        ]
        :> IView
