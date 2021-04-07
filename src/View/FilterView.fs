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
            TextBlock.margin 10.
            TextBlock.text label
        ]
        :> IView

    let renderToggleButtonFilter addMsg removeMsg filter filterList dispatch : IView =
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
            ToggleButton.content (string filter)
            ToggleButton.margin 10.
            ToggleButton.height 40.
            ToggleButton.padding (20., 5.)
        ]
        :> IView

    let renderToggleFilterButtonContinent =
        renderToggleButtonFilter FilterAnimalListByContinent RemoveContinentFromFilterList

    let renderToggleFilterButtonDLC =
        renderToggleButtonFilter FilterAnimalListByDLC RemoveDlcFromFilterList

    let renderToggleFilterButtonBiome =
        renderToggleButtonFilter FilterAnimalListByBiome RemoveBiomeFromFilterList



    let viewContinentsFilterOptions (state: State) dispatch : IView =
        let continentList : Continent List =
            match state.continentListFilter with
            | Some continentList -> continentList
            | None -> []

        DockPanel.create [
            DockPanel.dock Dock.Top
            DockPanel.children [
                renderFilterHeadline "Continents"
                WrapPanel.create [
                    WrapPanel.dock Dock.Top
                    WrapPanel.margin (20., 10.)
                    WrapPanel.children [
                        renderToggleFilterButtonContinent Africa continentList dispatch
                        renderToggleFilterButtonContinent Asia continentList dispatch
                        renderToggleFilterButtonContinent CentralAmerica continentList dispatch
                        renderToggleFilterButtonContinent Europe continentList dispatch
                        renderToggleFilterButtonContinent Continent.SouthAmerica continentList dispatch
                        renderToggleFilterButtonContinent NorthAmerica continentList dispatch
                        renderToggleFilterButtonContinent Oceania continentList dispatch
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

        DockPanel.create [
            DockPanel.dock Dock.Top
            DockPanel.children [
                renderFilterHeadline "DLCs"
                WrapPanel.create [
                    WrapPanel.dock Dock.Top
                    WrapPanel.margin (20., 10.)
                    WrapPanel.children [
                        renderToggleFilterButtonDLC Arctic dlcList dispatch
                        renderToggleFilterButtonDLC Aquatic dlcList dispatch
                        renderToggleFilterButtonDLC Australia dlcList dispatch
                        renderToggleFilterButtonDLC Deluxe dlcList dispatch
                        renderToggleFilterButtonDLC SouthAmerica dlcList dispatch
                        renderToggleFilterButtonDLC SoutheastAsia dlcList dispatch
                    ]
                ]
            ]
        ]
        :> IView

    let viewBiomeFilterOption (state: State) dispatch : IView =
        let biomeList : Biome List =
            match state.biomeListFilter with
            | Some biomeList -> biomeList
            | None -> []

        DockPanel.create [
            DockPanel.dock Dock.Top
            DockPanel.children [
                renderFilterHeadline "Biome"
                WrapPanel.create [
                    WrapPanel.dock Dock.Top
                    WrapPanel.margin (20., 10.)
                    WrapPanel.children [
                        renderToggleFilterButtonBiome Biome.Aquatic biomeList dispatch
                        renderToggleFilterButtonBiome Desert biomeList dispatch
                        renderToggleFilterButtonBiome Grassland biomeList dispatch
                        renderToggleFilterButtonBiome Taiga biomeList dispatch
                        renderToggleFilterButtonBiome Temperate biomeList dispatch
                        renderToggleFilterButtonBiome Tropical biomeList dispatch
                        renderToggleFilterButtonBiome Tundra biomeList dispatch
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
                            ToggleButton.margin 10.
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
                            ToggleButton.margin 10.
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

                viewContinentsFilterOptions state dispatch
                viewDLCFilterOption state dispatch
                viewBiomeFilterOption state dispatch
                viewHabitationFilter state dispatch
                StackPanel.create []
            ]
        ]
        :> IView
