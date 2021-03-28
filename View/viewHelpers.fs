namespace PlanetZooApp

module ViewHelpers =
    open Avalonia.Controls
    open Avalonia.FuncUI.DSL
    open Avalonia.Layout
    open Avalonia.Media.Imaging
    open PlanetZooApp.Types

    let optionToString unt op =
        match op with
        | Some value -> $"{value}{unt}"
        | None -> ""

    let rangeToString (min: int) (max: int) (unity: string) = $"{min}{unity} - {max}{unity}"

    let groupSizeToString (group: GroupMixed option) =
        match group with
        | Some value -> $"{value.size.min}-{value.size.max} (up to {value.male} males, up to {value.female} females)"
        | None -> ""

    let groupBachelortoString (group: GroupBachelor option) =
        match group with
        | Some value -> $"{value.size.min}-{value.size.max}"
        | None -> ""

    let fencetoString (fence: Fence option) =
        match fence with
        | Some ({ climbproof = true } as value) -> $"Grade {value.grade}, >{value.height}m, Climb Proof"
        | Some ({ climbproof = false } as value) -> $"Grade {value.grade}, >{value.height}m"
        | None -> ""

    let renderAnimalInfo label info =
        StackPanel.create [
            StackPanel.orientation Orientation.Horizontal
            StackPanel.children [
                TextBlock.create [
                    TextBlock.padding (5., 0.)
                    TextBlock.text $"%s{label}:"
                ]
                TextBlock.create [
                    TextBlock.padding (5., 0.)
                    TextBlock.text (info)
                ]
            ]
        ]

    let animalImage (imgPath: string) height width =
        Image.create [
            Image.height height
            Image.width width
            Image.source (new Bitmap(imgPath))
            Image.horizontalAlignment HorizontalAlignment.Left
        ]
