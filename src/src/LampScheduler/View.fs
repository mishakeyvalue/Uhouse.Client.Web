module LampScheduler.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types

let numberInput defaultValue name action dispatch = 
    div
        [ ClassName "field"]
        [
            label 
                [ ClassName "label"]
                [ str name ]
            div 
                [ ClassName "control"] 
                [ 
                    input
                        [ 
                            ClassName "input"
                            Type "number"
                            DefaultValue (defaultValue |> string)
                            OnChange (fun ev -> !!ev.target?value |> action |> dispatch)
                        ]
                ]
        ]

let root (model: Model) dispatch =
    div
        []
        [
            numberInput model.Delay.TotalMinutes "Delay (in minutes)" UpdateDelay dispatch
            numberInput model.Duration.TotalMinutes "Duration (in minutes)" UpdateDuration dispatch
            div
                [ ClassName "control" ]
                [
                    button
                        [ 
                            ClassName "button is-primary"
                            OnClick (fun _ -> dispatch Submit)
                        ]
                        [ str "Submit" ]
                ]
        ]

// <div class="control">
//   <button class="button is-primary">Submit</button>
// </div>
