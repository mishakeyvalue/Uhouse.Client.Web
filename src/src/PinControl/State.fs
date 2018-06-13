module PinControl.State

// open Elmish
open Types
open Elmish
open Api
open System.Runtime.Serialization
open System
open Fable.Import
let init settings pinId : Model = { Settings = settings; PinId = pinId }

let pinCmd request successMsg model =
    let request' = request model.Settings.StationUri 
    Cmd.ofPromise 
        request'
        model.PinId 
        (fun _ -> successMsg) 
        (fun e -> Msg.HttpError e.Message)

let turnOnCmd model = pinCmd turnOnRequest TurnedOn model
let turnOffCmd model = pinCmd turnOffRequest TurnedOff model

let update (msg:Msg) (model:Model) = 
    Browser.console.log (sprintf "%A" msg)
    match msg with 
    | SetSettings settings -> { model with Settings = settings }, []
    | TurnOn -> model, turnOnCmd model
    | TurnOff -> model, turnOffCmd model
    | HttpError msg -> raise (Exception msg)
    | _ -> model, []
