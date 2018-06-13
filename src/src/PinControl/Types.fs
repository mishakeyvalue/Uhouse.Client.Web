module PinControl.Types

type Model = { 
    Settings: Settings.Types.Model
}

type Msg = 
| SetSettings of Settings.Types.Model
| TurnOn
| TurnOff
| TurnedOn
| TurnedOff
| HttpError of string
