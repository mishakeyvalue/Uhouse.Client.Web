module PinControlList.View
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types

let centerButton txt action dispatch =
    div
      [ ClassName "column is-half is-offset-one-quarter" ]
      [ a
          [ ClassName "button"
            OnClick (fun _ -> action |> dispatch) ]
          [ str txt ] ]

let root model dispatch =
    let pinDispatch id msg = dispatch (Update (id, msg))

    div
        []
        [
          div
            [ ClassName "columns" ]
            [ div
                [ ClassName "column is-half is-offset-one-quarter" ]
                [ div
                    [ ClassName "column is-narrow"
                      Style
                        [ CSSProp.Width "170px" ] ]
                    (model.Pins |> List.map (fun p -> PinControl.View.root p (pinDispatch p.PinId))) ] ]
        ] 
        