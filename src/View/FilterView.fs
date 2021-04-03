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

    let renderToggleFilterButton (continent: Continent) (continentList: Continent List) dispatch : IView =
        let continentInState = (List.contains continent continentList)

        ToggleButton.create [
            ToggleButton.isChecked continentInState
            ToggleButton.onClick (
                (fun _ ->
                    match continentInState with
                    | false ->
                        (continent :: continentList)
                        |> FilterAnimalListByContinent
                        |> dispatch
                    | true ->
                        continent
                        |> RemoveContinentFromFilterList
                        |> dispatch),
                OnChangeOf(continentInState, continentList)
            )
            ToggleButton.content continent
            ToggleButton.margin 10.
            ToggleButton.padding (40., 14.)
        ]
        :> IView

    let viewContinentsFilterOptions (state: State) dispatch : IView =
        let continentList : Continent List =
            match state.continentListFilter with
            | Some continentList -> continentList
            | None -> []

        DockPanel.create [
            DockPanel.dock Dock.Top
            DockPanel.children [
                TextBlock.create [
                    TextBlock.dock Dock.Top
                    TextBlock.fontSize 20.
                    TextBlock.text "Continents"
                ]
                WrapPanel.create [
                    WrapPanel.dock Dock.Top
                    WrapPanel.margin (20., 10.)
                    WrapPanel.children [
                        renderToggleFilterButton Africa continentList dispatch
                        renderToggleFilterButton Asia continentList dispatch
                        renderToggleFilterButton CentralAmerica continentList dispatch
                        renderToggleFilterButton Europe continentList dispatch
                        renderToggleFilterButton SouthAmerica continentList dispatch
                        renderToggleFilterButton NorthAmerica continentList dispatch
                        renderToggleFilterButton Oceania continentList dispatch
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
                                (fun _ ->
                                    match state.continentListFilter with
                                    | Some _ -> dispatch ShowAnimalList
                                    | None -> CLearFilterContinent |> dispatch),
                                OnChangeOf state.continentListFilter
                            )
                        ]
                    ]
                ]
                viewContinentsFilterOptions state dispatch
                StackPanel.create []
            ]
        ]
        :> IView
