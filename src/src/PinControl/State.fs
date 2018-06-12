module PinControl.State

// open Elmish
open Types
open Elmish
open Api
let init settings : Model = { Settings = settings }

let turnOnCmd uri = Cmd.ofPromise turnOnRequest uri (fun _ -> Msg.TurnedOn) (fun e -> Msg.HttpError e.Message)
let turnOffCmd uri = Cmd.ofPromise turnOffRequest uri (fun _ -> Msg.TurnedOff) (fun e -> Msg.HttpError e.Message)

let update (msg:Msg) (model:Model) = 
    match msg with 
    | TurnOn -> model, turnOnCmd model.Settings.StationUri
    | TurnOff -> model, turnOffCmd model.Settings.StationUri
    | _ -> model, []
