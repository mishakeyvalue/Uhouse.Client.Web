module Settings.Types

type Model = {
    StationUri: string
}

type Msg = 
| ChangeStationUri of string