namespace PlanetZooApp

open Elmish
open Avalonia
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.Diagnostics
open Avalonia.Input
open Avalonia.FuncUI
open Avalonia.FuncUI.Elmish
open Avalonia.FuncUI.Components.Hosts

open PlanetZooApp.Functions
open PlanetZooApp.Types
open PlanetZooApp.ZooAnimal

type MainWindow() as this =
    inherit HostWindow()

    do
        base.Title <- "PlanetZooApp"
        base.Width <- 800.0
        base.Height <- 600.0

        //this.VisualRoot.VisualRoot.Renderer.DrawFps <- true
        //this.VisualRoot.VisualRoot.Renderer.DrawDirtyRects <- true

#if DEBUG
        DevTools.Attach(this, KeyGesture(Key.F12))
        |> ignore
#endif

        Program.mkProgram MainView.init MainView.update MainView.view
        |> Program.withHost this
#if DEBUG
        |> Program.withTrace (fun msg model -> printfn $"Got Message: {msg} Input: {model.continentListFilter}")

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
