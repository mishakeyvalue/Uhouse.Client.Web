module Settings.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types

let root model dispatch = 
    div
        [ ClassName "content" ]
        [ 
          h1 
            []
            [str "Station uri settings"] 

          p
            [ ClassName "control" ]
            [ input
                [ ClassName "input"
                  Type "text"
                  Value model.StationUri
                  OnChange (fun ev -> !!ev.target?value |> ChangeStationUri |> dispatch ) ] ]
          br [ ]
        ]