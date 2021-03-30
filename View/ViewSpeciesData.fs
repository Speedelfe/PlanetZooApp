namespace PlanetZooApp

module ViewSpeciesData =
    open Avalonia.Controls
    open Avalonia.FuncUI.DSL
    open Avalonia.FuncUI.Types
    open Avalonia.Layout
    open PlanetZooApp.Types
    open PlanetZooApp.ViewHelpers

    let viewAnimalDetailsTabSpeciesData (animal: ZooAnimal) : IView =
        StackPanel.create [
            StackPanel.orientation Orientation.Vertical
            StackPanel.children [
                TextBlock.create [
                    TextBlock.fontSize 14.0
                    TextBlock.text "Social Behavior"
                ]
                renderAnimalInfo "Group Size (without young) " (groupSizeToString animal.habitat_requirements.group_mixed)
                renderAnimalInfo "Male bachelor group size (without young) " (groupBachelortoString animal.habitat_requirements.group_male)
                renderAnimalInfo "Female bachelor group size (without young) " (groupBachelortoString animal.habitat_requirements.group_female)
                //Dominanz
                //Paarungsverhalten
                //Beziehung zu Menschen
                renderAnimalInfo "Guest Enter" (boolOptionToString animal.habitat_requirements.guest_enter)



            ]



        ]
        :> IView
