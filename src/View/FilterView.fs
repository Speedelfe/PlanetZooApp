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

    let viewFilterView (state: State) dispatch : IView =
        DockPanel.create [
            DockPanel.children [
                //TODO: Pills für Kontinente
                Button.create [
                    Button.content "Filter nach Continent"
                    Button.dock Dock.Top
                    Button.onClick (
                        (fun _ ->
                            match state.continentListFilter with
                            | Some _ -> dispatch CLearFilterContinent
                            | None -> FilterAnimalListByContinent [ Europe ] |> dispatch),
                        OnChangeOf state.continentListFilter
                    )
                ]
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
