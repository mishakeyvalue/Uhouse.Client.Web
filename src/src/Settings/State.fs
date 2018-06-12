module Settings.State

open Types

let init () : Model = { StationUri = "http://192.168.0.102:8090" }

let update msg model : Model = 
    match msg with
    | ChangeStationUri newUri -> { model with StationUri = newUri }
    | _ -> model