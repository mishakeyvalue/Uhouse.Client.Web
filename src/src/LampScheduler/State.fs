module LampScheduler.State

open Api
open Types
open System
open Elmish

let submitCmd model = Cmd.ofPromise (sumbitSchedule model.Settings.StationUri model.Delay) model.Duration (fun _ -> Submited) raise

let init settings = { Settings = settings; PinId = 12; Delay = TimeSpan.FromMinutes(0.); Duration = TimeSpan.FromMinutes(3.)}

let update (msg: Msg) (model: Model) =
    match msg with
    | SetSettings s -> { model with Settings = s }, []
    | UpdatePinId pinId -> { model with PinId = pinId }, []
    | UpdateDelay delay -> { model with Delay = TimeSpan.FromMinutes(delay) }, []
    | UpdateDuration duration -> { model with Duration = TimeSpan.FromMinutes(duration) }, []
    | Submit -> 
        model, submitCmd model
    | _ -> model, []