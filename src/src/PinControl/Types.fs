module PinControl.Types

type Model = { 
    Settings: Settings.Types.Model
}

type Msg = 
| TurnOn
| TurnOff
| TurnedOn
| TurnedOff
| HttpError of string
