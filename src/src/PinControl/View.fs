module PinControl.View

open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
let simpleButton txt action dispatch =
    div
      [ ClassName "column is-narrow" ]
      [ a
          [ ClassName "button"
            OnClick (fun _ -> action |> dispatch) ]
          [ str txt ] ]

let root (model:Model) dispatch =
    div
        [ ClassName "columns is-vcentered" ]
        [ div
            [ ClassName "column is-half is-offset-one-quarter"
              Style
                [ CSSProp.Width "170px" ] ]
            [ ]
          simpleButton "TURN ON" TurnOn dispatch
          simpleButton "TURN OFF" TurnOff dispatch
        ]