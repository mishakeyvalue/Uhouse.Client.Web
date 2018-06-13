module PinControl.View

open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
let simpleButton txt action dispatch extClass =
      a
          [ ClassName ("card-footer-item has-text-black has-text-weight-bold " + extClass )
            OnClick (fun _ -> action |> dispatch) ]
          [ str txt ]

let root (model:Model) dispatch =
    div
        [ ClassName "card" ]
        [
          div 
            [ ClassName (sprintf "card-content has-background-%s" (if model.IsTurnedOn then "warning" else "grey-light"))]
            [
              p
                [ ClassName "title" ]
                [str (sprintf "Pin #%i"model.PinId) ] 
            ]  


          footer 
            [ ClassName "card-footer"]
            [
              simpleButton "TURN ON" TurnOn dispatch "has-background-success"
              simpleButton "TURN OFF" TurnOff dispatch "has-background-grey-lighter"
            ]
        ]