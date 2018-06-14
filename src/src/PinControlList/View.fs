module PinControlList.View
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types

let root model dispatch =
    let pinDispatch id msg = dispatch (Update (id, msg))
    let pinView pin =
        div 
            [ClassName "column is-4"]
            [
              PinControl.View.root pin (pinDispatch pin.PinId)
            ]    
    div
        []
        [
          div
            [ ClassName "columns is-multiline" ]
            (model.Pins |> List.sortBy (fun pin -> pin.PinId) |>List.map pinView)
        ] 
        