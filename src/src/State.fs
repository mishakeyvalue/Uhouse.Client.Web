module App.State

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Import
open Types
let SyncRefreshRate = 512 * 2 * 2 // ms
let tick dispatch =
    Browser.window.setInterval((fun _ -> 
        dispatch SyncTick), SyncRefreshRate) |> ignore
    ()
let pageParser: Parser<Page->Page,Page> =
    oneOf [              
      map About (s "about")
      map PinControlList (s "pin-control")
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
        { model with CurrentPage = page }, Cmd.ofSub tick


let init result =
    let settings = Settings.State.init()
    let (pinListState, pinListCmd) = PinControlList.State.init settings
    let (model, cmd) = 
        urlUpdate 
            result 
            { CurrentPage = Home;
              Counter = Counter.State.init();
              CounterList = CounterList.State.init();
              Home = Home.State.init();
              Settings = settings;
              PinControlList = pinListState
            }

    model, Cmd.batch [cmd; Cmd.map PinControlListMsg pinListCmd]


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
        { model with Settings = settings }, settings |> PinControlList.Types.Msg.SetSettings |> PinControlListMsg |> Cmd.ofMsg 

    | PinControlListMsg msg ->
        let (pinControl, cmds) = PinControlList.State.update msg model.PinControlList
        { model with PinControlList = pinControl }, Cmd.batch [Cmd.map PinControlListMsg cmds]
    | SyncTick ->
        model, PinControlListMsg PinControlList.Types.SyncStatus |> Cmd.ofMsg

    | _ -> model, []
