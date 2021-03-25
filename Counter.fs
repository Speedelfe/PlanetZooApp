namespace PlanetZooApp

module Counter =
    open Avalonia.Controls
    open Avalonia.Controls.Primitives
    open Avalonia.FuncUI.DSL
    open Avalonia.FuncUI.Types
    open Avalonia.Layout
    open PlanetZooApp.Functions
    open PlanetZooApp.Types
    open Avalonia.FuncUI.Components
    open Avalonia.FuncUI.Components.Hosts
    open Avalonia.FuncUI.Elmish
    open Avalonia.Input
    open Avalonia.Threading
    open Avalonia.Media.Imaging
    open Elmish

    type ViewMode =
        | ListView
        | DetailView of ZooAnimal
        | FilterView

    type State =
        {
            animalMap: Map<AnimalKey, ZooAnimal>
            continentListFilter: Continent List option
            viewMode: ViewMode
        }

    type Msg =
        | ChooseAnimal of ZooAnimal
        | LookForImageJob
        | DownloadImage of (AnimalKey * string)
        | SaveImage of (AnimalKey * string)
        | AsyncError of exn
        | ShowAnimalList
        | FilterAnimalListByContinent of Continent List
        | CLearFilterContinent
        | ShowFilterView

    let init animalMap =
        let state =
            {
                animalMap = animalMap
                continentListFilter = None
                viewMode = ListView
            }

        state, (Cmd.ofMsg LookForImageJob)

    let update (msg: Msg) (state: State) =
        match msg with
        | ChooseAnimal animal ->
            let state =
                { state with
                    viewMode = DetailView animal
                }

            state, Cmd.none
        | LookForImageJob ->
            let chooser key animal =
                match animal.image_path with
                | Some _ -> None
                | None -> Some(key, animal)

            let cmd =
                match Map.tryPick chooser state.animalMap with
                | Some (key, animal) -> DownloadImage(key, animal.image_url) |> Cmd.ofMsg
                | None -> Cmd.none

            state, cmd
        | DownloadImage (key, url) ->
            let cmd =
                match downloadImage key url with
                | HasToBeDownloaded job -> Cmd.OfAsync.either job () (fun imgPath -> SaveImage(key, imgPath)) AsyncError
                | AlreadyDownloaded imgPath -> SaveImage(key, imgPath) |> Cmd.ofMsg

            state, cmd
        | SaveImage (key, imgPath) ->
            let state =
                { state with
                    animalMap =
                        Map.change
                            key
                            (Option.map
                                (fun animal ->
                                    { animal with
                                        image_path = Some imgPath
                                    }))
                            state.animalMap
                }

            state, Cmd.ofMsg LookForImageJob
        | AsyncError ex -> raise ex
        | ShowAnimalList ->
            let state = { state with viewMode = ListView }
            state, Cmd.none
        | FilterAnimalListByContinent continentList ->
            let state =
                { state with
                    continentListFilter = Some continentList
                }

            state, Cmd.none
        | CLearFilterContinent ->
            let state =
                { state with
                    continentListFilter = None
                }

            state, Cmd.none
        | ShowFilterView ->
            let state = { state with viewMode = FilterView }
            state, Cmd.none


    let animalImage (imgPath: string) height width =
        Image.create [
            Image.height height
            Image.width width
            Image.source (new Bitmap(imgPath))
        ]


    let animalItemView (animal: ZooAnimal) =
        StackPanel.create [
            StackPanel.orientation Orientation.Horizontal
            StackPanel.spacing 5.
            StackPanel.children [
                match animal.image_path with
                | Some imgPath -> animalImage imgPath 50. 80.
                | None -> () // TODO: irgendwas tun
                TextBlock.create [
                    TextBlock.padding (0., 10.)
                    TextBlock.fontSize 20.0
                    TextBlock.text (animal.name)
                ]
            ]
        ]

    let viewAnimalDetailsContentHeader (animal: ZooAnimal) : IView =
        StackPanel.create [
            StackPanel.orientation Orientation.Horizontal
            StackPanel.children [
                match animal.image_path with
                | Some imgPath -> animalImage imgPath 160. 200.
                | None -> () // TODO: irgendwas tun

                StackPanel.create [
                    StackPanel.orientation Orientation.Vertical
                    StackPanel.children [
                        TextBlock.create [
                            TextBlock.fontSize 20.
                            TextBlock.padding (5., 5.)
                            TextBlock.text animal.name
                        ]
                        TextBlock.create [
                            TextBlock.fontSize 14.0
                            TextBlock.padding (5., 5.)
                            TextBlock.text animal.latin_name
                        ]
                        TextBlock.create [
                            TextBlock.fontSize 12.
                            TextBlock.lineHeight 16.
                            TextBlock.maxWidth 500.
                            TextBlock.padding (5., 5.)
                            TextBlock.textWrapping Avalonia.Media.TextWrapping.Wrap
                            TextBlock.text animal.description
                        ]
                    ]
                ]
            ]
        ]
        :> IView

    // let blaa (text: string) =
    //     text.Replace()
    //     text.Trim()

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

    let viewAnimalDetailsContentHabitatRequirements (habitatRequirements: HabitatRequirements) : IView =
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
                    renderAnimalInfo "Guest Enter" (optionToString "" habitatRequirements.guest_enter)
                    renderAnimalInfo "Fence" (fencetoString habitatRequirements.fence)
                // TODO: ?!
                // land_additional: int option
                // water_additional: int option
                // climbable_additional: int option

                renderAnimalInfo "Temperature" (rangeToString habitatRequirements.temperature.min habitatRequirements.temperature.max "°C")
                renderAnimalInfo "Group Size" (groupSizeToString habitatRequirements.group_mixed)
                renderAnimalInfo "Male bachelor group size" (groupBachelortoString habitatRequirements.group_male)
                renderAnimalInfo "Female bachelor group size" (groupBachelortoString habitatRequirements.group_female)
            ]
        ]
        :> IView

    let viewAnimalDetailsContent (animal: ZooAnimal) dispatch : IView =
        ScrollViewer.create [
            ScrollViewer.horizontalScrollBarVisibility ScrollBarVisibility.Disabled
            ScrollViewer.content (
                StackPanel.create [
                    StackPanel.orientation Orientation.Vertical
                    StackPanel.children [
                        viewAnimalDetailsContentHeader animal

                        viewAnimalDetailsContentHabitatRequirements animal.habitat_requirements

                        TextBlock.create [
                            TextBlock.fontSize 14.0
                            TextBlock.text ($"{animal}")
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

    let filterView (state: State) dispatch : IView =
        DockPanel.create [
            DockPanel.children [
                Button.create [
                    Button.content "Zurück"
                    Button.onClick (fun _ -> dispatch ShowAnimalList)
                ]
                Button.create [
                    Button.content "Filter nach Continent"
                    Button.onClick (
                        (fun _ ->
                            match state.continentListFilter with
                            | Some _ -> dispatch CLearFilterContinent
                            | None -> FilterAnimalListByContinent [ Europe ] |> dispatch),
                        OnChangeOf state.continentListFilter
                    )
                ]
            ]
        ]
        :> IView

    let listView (state: State) dispatch : IView =
        DockPanel.create [
            DockPanel.children [
                StackPanel.create [
                    StackPanel.dock Dock.Top
                    StackPanel.orientation Orientation.Horizontal
                    StackPanel.spacing 10.
                    StackPanel.children [
                        TextBox.create [
                            TextBox.text "Suche nach Name" //TODO: Funktion zum Suchen nach Animal Name
                        ]
                        Button.create [
                            Button.content "Filter Europa" //TODO: Click Event -> Filter "Fenster" öffnen
                            Button.onClick (fun _ -> dispatch ShowFilterView)

                        ]

                    ]

                ]
                let fullanimalList =
                    state.animalMap |> Map.toList |> List.map snd

                let animalList =
                    match state.continentListFilter with
                    | None -> fullanimalList
                    | Some continentListFilter -> filtercontinent fullanimalList continentListFilter

                ListBox.create [
                    ListBox.dataItems animalList
                    ListBox.itemTemplate (DataTemplateView<ZooAnimal>.create animalItemView)
                    ListBox.onSelectedIndexChanged (
                        (fun index ->
                            if index >= 0 then
                                animalList.Item index |> ChooseAnimal |> dispatch),
                        OnChangeOf animalList
                    )
                ]

            ]

        ]
        :> IView

    let view state dispatch =
        match state.viewMode with
        | ListView -> listView state dispatch
        | DetailView currentAnimal -> viewAnimalDetails (currentAnimal) dispatch
        | FilterView -> filterView state dispatch
