module App.Types

type Page =
    | Home
    | PinControlList
    | Counter
    | CounterList
    | About
    | Settings
    | LampScheduler

let toHash page =
    match page with
    | About -> "#about"
    | Counter -> "#counter"
    | CounterList -> "#counterlist"
    | Home -> "#home"
    | Settings -> "#settings"
    | PinControlList -> "#pin-control"
    | LampScheduler -> "#scheduler"


type Msg =
    | CounterMsg of Counter.Types.Msg
    | CounterListMsg of CounterList.Types.Msg
    | HomeMsg of Home.Types.Msg
    | SettingsMsg of Settings.Types.Msg
    | PinControlListMsg of PinControlList.Types.Msg
    | LampSchedulerMsg of LampScheduler.Types.Msg
    | SyncTick

type Model =
    { CurrentPage : Page
      Counter : Counter.Types.Model
      CounterList : CounterList.Types.Model
      Home: Home.Types.Model
      Settings: Settings.Types.Model
      PinControlList: PinControlList.Types.Model
      LampScheduler: LampScheduler.Types.Model
    }
