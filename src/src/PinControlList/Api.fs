module PinControlList.Api

open Fable.PowerPack
open Fable.PowerPack.Fetch
open Fable.Core.JsInterop

let private addQueryParam uri paramName (values: string list) =
    let addQueryParam uri paramName (x,xs) = 
        let tail = xs |> List.map (sprintf "&%s=%s" paramName) |> List.reduce (+)        
        sprintf "%s?%s=%s%s" uri paramName x tail   
    match values with
    | [] -> uri
    | x::xs -> addQueryParam uri paramName (x, xs)

let private getPinUri baseUri pinIds = pinIds |> List.map string |> addQueryParam (baseUri+"/api/pin/status") "pins"

let getStatus baseUri (pinIds: int list) = 
    promise {
        let uri = getPinUri baseUri pinIds
        let! response = fetch uri []
        let! text = response.text()
        let status = ofJson<Map<int, bool>>(text)          
        return status
    }