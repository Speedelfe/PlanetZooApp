namespace PlanetZooApp

open Elmish
open Avalonia
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.Input
open Avalonia.FuncUI
open Avalonia.FuncUI.Elmish
open Avalonia.FuncUI.Components.Hosts

open PlanetZooApp.FileManagement
open PlanetZooApp.Types

type MainWindow() as this =
    inherit HostWindow()

    do
        base.Title <- "PlanetZooApp"
        base.Width <- 400.0
        base.Height <- 400.0

        //this.VisualRoot.VisualRoot.Renderer.DrawFps <- true
        //this.VisualRoot.VisualRoot.Renderer.DrawDirtyRects <- true

        let animalMap =
            loadFile ()
            |> List.fold
                (fun map animalJson ->
                    let animal = (ZooAnimal.createFromJson animalJson)
                    Map.add (AnimalKey animalJson.key) animal map)
                Map.empty

        Program.mkProgram (fun () -> Counter.init animalMap) Counter.update Counter.view
        |> Program.withHost this
#if DEBUG
        |> Program.withTrace (fun msg _ -> printfn $"Got Message: {msg}")
#endif
        |> Program.run

type App() =
    inherit Application()

    override this.Initialize() =
        this.Styles.Load "avares://Avalonia.Themes.Default/DefaultTheme.xaml"
        this.Styles.Load "avares://Avalonia.Themes.Default/Accents/BaseDark.xaml"

    override this.OnFrameworkInitializationCompleted() =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime as desktopLifetime -> desktopLifetime.MainWindow <- MainWindow()
        | _ -> ()

module Program =
    [<EntryPoint>]
    let main (args: string []) =
        AppBuilder
            .Configure<App>()
            .UsePlatformDetect()
            .UseSkia()
            .StartWithClassicDesktopLifetime(args)
