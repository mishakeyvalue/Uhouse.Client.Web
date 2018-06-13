module PinControl.View

open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
let simpleButton txt action dispatch extClass =
    div
      [ ClassName "column is-narrow" ]
      [ a
          [ ClassName ("button " + extClass )
            OnClick (fun _ -> action |> dispatch) ]
          [ str txt ] ]

let root (model:Model) dispatch =
    div
        [ ]
        [
          h1
            [ ClassName "title" ]
            [str (sprintf "Pin #%i"model.PinId) ] 
          div 
            [ ClassName "columns"]
            [
              simpleButton "TURN ON" TurnOn dispatch "is-info"
              simpleButton "TURN OFF" TurnOff dispatch "is-danger"
            ]
          hr []         
        ]