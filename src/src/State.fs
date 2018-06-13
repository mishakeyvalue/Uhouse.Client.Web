module App.State

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Import
open Types

let pageParser: Parser<Page->Page,Page> =
    oneOf [              
      map About (s "about")
      map App.Types.Page.PinControl (s "pin-control")
      map Counter (s "counter")
      map CounterList (s "counterlist")      
      map Home (s "home")
      map Settings (s "settings")
      map Home top
    ]


let urlUpdate (result: Option<Page>) model =
    match result with
    | None ->
        Browser.console.error("Error parsing url: " + Browser.window.location.href)
        model, Navigation.modifyUrl (toHash model.CurrentPage)

    | Some page ->
        { model with CurrentPage = page }, Cmd.none

let init result =
    let settings = Settings.State.init()
    urlUpdate result
        { CurrentPage = Home
          Counter = Counter.State.init()
          CounterList = CounterList.State.init()
          Home = Home.State.init()
          Settings = settings
          PinControl = PinControl.State.init settings
        }


let update msg (model:Model) =
    match msg with
    | CounterMsg msg ->
        let counter = Counter.State.update msg model.Counter
        { model with Counter = counter }, Cmd.none
    | CounterListMsg msg ->
        let counterList = CounterList.State.update msg model.CounterList
        { model with CounterList = counterList }, Cmd.none
    | HomeMsg msg ->
        let home = Home.State.update msg model.Home
        { model with Home =  home }, Cmd.none

    | SettingsMsg msg ->
        let settings = Settings.State.update msg model.Settings
        { model with Settings = settings }, settings |> PinControl.Types.Msg.SetSettings |> PinControlMsg |> Cmd.ofMsg 

    | PinControlMsg msg ->
        let (pinControl, cmds) = PinControl.State.update msg model.PinControl
        { model with PinControl = pinControl }, Cmd.batch [Cmd.map PinControlMsg cmds]
    | _ -> model, []
