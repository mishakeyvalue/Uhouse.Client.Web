module PinControlList.State

open Elmish
open Types

let private pinIds = [0..5] @ [12]

let init settings = { Pins = [ for i in pinIds do
                                yield PinControl.State.init settings i ]
                      Settings = settings }, Cmd.ofMsg SyncStatus

let private updatePin' (pinMap: Map<int, PinControl.Types.Msg>) (pins:PinControl.Types.Model list) = 
        pins 
        |> List.map (fun pin -> 
            match Map.tryFind pin.PinId pinMap with
                | Some msg -> PinControl.State.update msg pin
                | None -> pin, [])
        |> List.fold 
            (fun (pins, cmds) (pin, cmd) -> ([pin] @ pins, Cmd.batch [cmds; Cmd.map (fun cmd -> Update (pin.PinId, cmd)) cmd]))
            ([], [])        
                
let private updatePin pinMap model =
    let (pins, cmd) = updatePin' pinMap model.Pins  
    { model with Pins = pins }, cmd

let syncCmd (model: Model) = 
    let mapStatusToMessages result =        
        let inline mapToMessage v = if v then PinControl.Types.TurnedOn else PinControl.Types.TurnedOff
        result
        |> Map.map (fun _ v -> mapToMessage v)
        |> BatchUpdate
        
    Cmd.ofPromise 
        (PinControlList.Api.getStatus model.Settings.StationUri) 
        (model.Pins |> List.map (fun p -> p.PinId))
        mapStatusToMessages
        (raise)
let update (msg:Msg) (model:Model) =
    Fable.Import.Browser.console.log (sprintf "%A" msg)
    match msg with
    | SetSettings settings -> 
          { model with Settings = settings}
           , model.Pins 
              |> List.map (fun pin -> Update (pin.PinId, PinControl.Types.SetSettings settings) |> Cmd.ofMsg)
              |> Cmd.batch

    | BatchUpdate updates ->
        updatePin updates model
    | Update (pinId, pinMsg) -> 
        updatePin (Map.empty |> Map.add pinId pinMsg) model
    | SyncStatus -> model, syncCmd model
    | _ -> model, []
        