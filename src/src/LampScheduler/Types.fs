module LampScheduler.Types

open System

type Model = {
    Settings: Settings.Types.Model
    PinId: int
    Delay: TimeSpan
    Duration: TimeSpan    
}

type Msg =
| SetSettings of Settings.Types.Model
| UpdatePinId of int
| UpdateDelay of float
| UpdateDuration of float
| Submit
| Submited