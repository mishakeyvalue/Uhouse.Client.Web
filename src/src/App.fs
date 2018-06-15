module App.View

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser
open Types
open App.State

importAll "../sass/main.sass"

open Fable.Helpers.React
open Fable.Helpers.React.Props

let menuItem label page currentPage=
    li
      [ ]
      [ a
          [ classList [ "is-active", page = currentPage ]
            Href (toHash page) ]
          [ str label ] ]

let menu currentPage =
    aside
      [ ClassName "menu" ]
      [ p
          [ ClassName "menu-label" ]
          [ str "General" ]
        ul
          [ ClassName "menu-list" ]
          [ menuItem "Home" Page.Home currentPage
            menuItem "Direct pin control" Page.PinControlList currentPage
            menuItem "Counter sample" Page.Counter currentPage
            menuItem "Counter list sample" Page.CounterList currentPage
            menuItem "About" Page.About currentPage
            menuItem "Settings" Page.Settings currentPage
            menuItem "Scheduler" Page.LampScheduler currentPage ] ]

let root (model: Model) dispatch =

    let pageHtml =
        function
        | Page.About -> Info.View.root
        | Counter -> Counter.View.root model.Counter (CounterMsg >> dispatch)
        | CounterList -> CounterList.View.root model.CounterList (CounterListMsg >> dispatch)
        | Home -> Home.View.root model.Home (HomeMsg >> dispatch)
        | Settings -> Settings.View.root model.Settings (SettingsMsg >> dispatch)
        | PinControlList -> PinControlList.View.root model.PinControlList (PinControlListMsg >> dispatch)
        | LampScheduler -> LampScheduler.View.root model.LampScheduler (LampSchedulerMsg >> dispatch)
        

    div
        []
        [ div
            [ ClassName "navbar-bg" ]
            [ div
                [ ClassName "container" ]
                [ Navbar.View.root ] ]
          div
            [ ClassName "section" ]
            [ div
                [ ClassName "container" ]
                [ div
                    [ ClassName "columns" ]
                    [ div
                        [ ClassName "column is-3" ]
                        [ menu model.CurrentPage ]
                      div
                        [ ClassName "column" ]
                        [ pageHtml model.CurrentPage ] ] ] ] ]

open Elmish.React
open Elmish.Debug
open Elmish.HMR

// App
Program.mkProgram init update root
|> Program.toNavigable (parseHash pageParser) urlUpdate
//-:cnd:noEmit
#if DEBUG
|> Program.withDebugger
|> Program.withHMR
#endif
//+:cnd:noEmit
|> Program.withReact "elmish-app"
|> Program.run
