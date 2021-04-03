namespace PlanetZooApp

module ViewNaturalHabitat =
    open Avalonia.Controls
    open Avalonia.FuncUI.DSL
    open Avalonia.FuncUI.Types
    open Avalonia.Layout
    open PlanetZooApp.Types
    open PlanetZooApp.ViewHelpers

    let viewAnimalDetailsTabNaturalHabitat (animal: ZooAnimal) : IView =
        StackPanel.create [
            StackPanel.orientation Orientation.Vertical
            StackPanel.children [
                TextBlock.create [
                    TextBlock.fontSize 14.0
                    TextBlock.text "Herkunft"
                ]
                renderAnimalInfo "Continent" (continentListToString animal.continent)
                renderAnimalInfo "Biome" (biomeListToString animal.biome)
                match animal.region with
                | Some region -> renderAnimalInfo "Region" (regionListToString region)
                | None -> ()
                TextBlock.create [
                    TextBlock.fontSize 14.0
                    TextBlock.text "Habitat min requirements"
                ]
                if animal.habitat_requirements.exhibit then
                    // Vivarien Tier
                    renderAnimalInfo "Humidity" (rangeToString animal.habitat_requirements.humidity.min animal.habitat_requirements.humidity.max "%")
                else
                    // Gehege Tier
                    renderAnimalInfo "Land" (optionToString "m²" animal.habitat_requirements.land_)
                    renderAnimalInfo "Water" (optionToString "m²" animal.habitat_requirements.water)
                    renderAnimalInfo "Climbable" (optionToString "m²" animal.habitat_requirements.climbable)

                    renderAnimalInfo "Fence" (fencetoString animal.habitat_requirements.fence)
                // TODO: ?!
                // land_additional: int option
                // water_additional: int option
                // climbable_additional: int option

                renderAnimalInfo "Temperature" (rangeToString animal.habitat_requirements.temperature.min animal.habitat_requirements.temperature.max "°C")
            ]
        ]
        :> IView
