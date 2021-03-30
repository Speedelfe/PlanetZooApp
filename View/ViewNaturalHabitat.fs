namespace PlanetZooApp

module ViewNaturalHabitat =
    open Avalonia.Controls
    open Avalonia.FuncUI.DSL
    open Avalonia.FuncUI.Types
    open Avalonia.Layout
    open PlanetZooApp.Types
    open PlanetZooApp.ViewHelpers

    let viewAnimalDetailsTabNaturalHabitat (habitatRequirements: HabitatRequirements) : IView =
        StackPanel.create [
            StackPanel.orientation Orientation.Vertical
            StackPanel.children [
                TextBlock.create [
                    TextBlock.fontSize 14.0
                    TextBlock.text "Habitat min requirements"
                ]
                if habitatRequirements.exhibit then
                    // Vivarien Tier
                    renderAnimalInfo "Humidity" (rangeToString habitatRequirements.humidity.min habitatRequirements.humidity.max "%")
                else
                    // Gehege Tier
                    renderAnimalInfo "Land" (optionToString "m²" habitatRequirements.land_)
                    renderAnimalInfo "Water" (optionToString "m²" habitatRequirements.water)
                    renderAnimalInfo "Climbable" (optionToString "m²" habitatRequirements.climbable)

                    renderAnimalInfo "Fence" (fencetoString habitatRequirements.fence)
                // TODO: ?!
                // land_additional: int option
                // water_additional: int option
                // climbable_additional: int option

                renderAnimalInfo "Temperature" (rangeToString habitatRequirements.temperature.min habitatRequirements.temperature.max "°C")
            ]
        ]
        :> IView
