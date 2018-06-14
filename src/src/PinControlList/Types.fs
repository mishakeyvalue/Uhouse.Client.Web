module PinControlList.Types
open System.Collections.Generic

type Model = {
    Settings: Settings.Types.Model
    Pins: PinControl.Types.Model list
}

type Msg =
| Update of int * PinControl.Types.Msg
| BatchUpdate of Map<int, PinControl.Types.Msg>
| SyncStatus
| SetSettings of Settings.Types.Model
| Foo
