module Settings.State

open Types
open Fable.Import
open Fable.Core

let private STORAGE_KEY = "APP-SETTINGS"
let private load() : Model option = 
        Browser.localStorage.getItem(STORAGE_KEY)
        |> unbox
        |> Core.Option.map (JsInterop.ofJson)
let private save<'T> (model: 'T) =
    Browser.localStorage.setItem(STORAGE_KEY, JsInterop.toJson model)
let private defaultModel = { StationUri = "http://192.168.0.102:8090" }

let init () : Model = Option.defaultValue defaultModel (load())

let update msg model : Model = 
    match msg with
    | ChangeStationUri newUri -> 
        let newModel = { model with StationUri = newUri }
        save newModel
        newModel