module PinControlList.Types

type Model = {
    Pins: PinControl.Types.Model list
}

type Msg =
| Update of int * PinControl.Types.Msg

