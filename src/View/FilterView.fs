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

    let viewContinentsFilterOptions : IView =
        DockPanel.create [
            DockPanel.dock Dock.Top
            DockPanel.children [
                TextBlock.create [
                    TextBlock.dock Dock.Top
                    TextBlock.fontSize 20.
                    TextBlock.text "Continents"
                ]
                StackPanel.create [
                    StackPanel.orientation Orientation.Horizontal
                    StackPanel.dock Dock.Top
                    StackPanel.margin (20., 10.)
                    StackPanel.children [
                        ToggleButton.create [
                            //ToggleButton.isChecked isActive
                            //ToggleButton.onClick (fun _ -> viewMode |> ChangeViewMode |> dispatch)
                            ToggleButton.content "Afrika"
                            ToggleButton.margin 10.
                            ToggleButton.padding (40., 14.)
                        ]
                        ToggleButton.create [
                            ToggleButton.content "Asia"
                            ToggleButton.margin 10.
                            ToggleButton.padding (40., 14.)
                        ]
                        ToggleButton.create [
                            ToggleButton.content "Central America"
                            ToggleButton.margin 10.
                            ToggleButton.padding (40., 14.)
                        ]
                        ToggleButton.create [
                            ToggleButton.content "Europe"
                            ToggleButton.margin 10.
                            ToggleButton.padding (40., 14.)
                        ]
                    ]
                ]
                StackPanel.create [
                    StackPanel.orientation Orientation.Horizontal
                    StackPanel.dock Dock.Top
                    StackPanel.margin (20., 10.)
                    StackPanel.children [
                        ToggleButton.create [
                            ToggleButton.content "South America"
                            ToggleButton.margin 10.
                            ToggleButton.padding (40., 14.)
                        ]
                        ToggleButton.create [
                            ToggleButton.content "North America"
                            ToggleButton.margin 10.
                            ToggleButton.padding (40., 14.)
                        ]
                        ToggleButton.create [
                            ToggleButton.content "Oceania"
                            ToggleButton.margin 10.
                            ToggleButton.padding (40., 14.)
                        ]
                    ]
                ]
            ]
        ]
        :> IView

    let viewFilterView (state: State) dispatch : IView =
        DockPanel.create [
            DockPanel.children [
                viewContinentsFilterOptions
                // Button.create [
                //     Button.content "Filter nach Continent"
                //     Button.dock Dock.Top
                //     Button.onClick (
                //         (fun _ ->
                //             match state.continentListFilter with
                //             | Some _ -> dispatch CLearFilterContinent
                //             | None -> FilterAnimalListByContinent [ Europe ] |> dispatch),
                //         OnChangeOf state.continentListFilter
                //     )
                // ]
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
                        ]
                    ]
                ]
            ]
        ]
        :> IView
