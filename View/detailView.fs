namespace PlanetZooApp

module DetailView =
    open Avalonia.Controls
    open Avalonia.Controls.Primitives
    open Avalonia.FuncUI.DSL
    open Avalonia.FuncUI.Types
    open Avalonia.Layout
    open PlanetZooApp.Types
    open PlanetZooApp.ViewHelpers
    open PlanetZooApp.ViewHabitatRequirements

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
            ]
        ]
        :> IView

    let tabs (animal: ZooAnimal) : IView list =
        [
            TabItem.create [
                TabItem.header "Basics"
                TabItem.content (viewAnimalDetailsContentHeader animal)
            ]
            TabItem.create [
                TabItem.header "Habitat Requirements"
                TabItem.content (viewAnimalDetailsContentHabitatRequirements animal.habitat_requirements)
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
                Button.create [
                    DockPanel.dock Dock.Top
                    Button.content "Zurück"
                    Button.onClick (fun _ -> dispatch ShowAnimalList)
                ]
                viewAnimalDetailsContent animal dispatch
            ]
        ]
        :> IView
