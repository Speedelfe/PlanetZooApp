namespace PlanetZooApp

module DetailView =
    open Avalonia.Controls
    open Avalonia.Controls.Primitives
    open Avalonia.FuncUI.DSL
    open Avalonia.FuncUI.Types
    open Avalonia.Input
    open Avalonia.Layout
    open PlanetZooApp.Types
    open PlanetZooApp.ViewHelpers
    open PlanetZooApp.ViewNaturalHabitat
    open PlanetZooApp.ViewSpeciesData

    let viewAnimalDetailsContentHeader (animal: ZooAnimal) : IView =
        StackPanel.create [
            StackPanel.orientation Orientation.Vertical
            StackPanel.children [
                match animal.image_path with
                | Some imgPath -> animalImage imgPath 300. 350.
                | None -> () // TODO: irgendwas tun

                TextBlock.create [
                    TextBlock.fontSize 20.
                    TextBlock.text animal.name
                ]
                TextBlock.create [
                    TextBlock.fontSize 14.0
                    TextBlock.text animal.latin_name
                ]
                TextBlock.create [
                    TextBlock.fontSize 12.
                    TextBlock.lineHeight 16.
                    TextBlock.textWrapping Avalonia.Media.TextWrapping.Wrap
                    TextBlock.text animal.description
                ]
                TextBlock.create [
                    TextBlock.margin 10.
                    TextBlock.text (dlcToString animal.dlc)
                ]
            ]
        ]
        :> IView

    let tabs (animal: ZooAnimal) : IView list =
        [
            TabItem.create [
                TabItem.padding 5.0
                TabItem.header "Basics"
                TabItem.content (viewAnimalDetailsContentHeader animal)
            ]
            TabItem.create [
                TabItem.padding 5.0
                TabItem.header "Natural habitat"
                TabItem.content (viewAnimalDetailsTabNaturalHabitat animal)
            ]
            TabItem.create [
                TabItem.padding 5.0
                TabItem.header "Species data"
                TabItem.content (viewAnimalDetailsTabSpeciesData animal)
            ]
        ]

    let viewAnimalDetailsContent (animal: ZooAnimal) dispatch : IView =
        ScrollViewer.create [
            ScrollViewer.horizontalScrollBarVisibility ScrollBarVisibility.Disabled
            ScrollViewer.content (
                StackPanel.create [
                    StackPanel.orientation Orientation.Vertical
                    StackPanel.children [
                        TabControl.create [
                            TabControl.tabStripPlacement Dock.Left
                            TabControl.viewItems (tabs animal)
                        ]
                    ]
                ]
            )
        ]
        :> IView

    let viewAnimalDetails (animal: ZooAnimal) dispatch : IView =
        DockPanel.create [
            DockPanel.children [
                StackPanel.create [
                    StackPanel.dock Dock.Bottom
                    StackPanel.orientation Orientation.Horizontal
                    StackPanel.children [
                        Button.create [
                            Button.content "Zurück"
                            Button.cursor (Cursor.Parse "wait")
                            Button.onClick (fun _ -> dispatch ShowAnimalList)
                        ]
                    ]
                ]
                viewAnimalDetailsContent animal dispatch
            ]
        ]
        :> IView
