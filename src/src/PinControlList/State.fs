module PinControlList.State

open Elmish
open Types

let init settings = { Pins = [ for i in 0..5 do
                                yield PinControl.State.init settings i ] }

let private updatePin' pinId pinMsg (pins:PinControl.Types.Model list) = 
        pins 
        |> List.map (fun pin -> 
            if pin.PinId = pinId
                then PinControl.State.update pinMsg pin
                else pin, [])
        |> List.fold 
            (fun (pins, cmds) (pin, cmd) -> ([pin] @ pins, Cmd.batch [cmds; Cmd.map (fun cmd -> Update (pin.PinId, cmd)) cmd]))
            ([], [])        
                
let private updatePin pinId pinMsg model =
    let (pins, cmd) = updatePin' pinId pinMsg model.Pins  
    { model with Pins = pins }, cmd

let update (msg:Msg) (model:Model) =
    Fable.Import.Browser.console.log (sprintf "%A" msg)
    match msg with
    | Update (pinId, pinMsg) -> updatePin pinId pinMsg model
        