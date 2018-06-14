module PinControlList.Api

open Fable.PowerPack
open Fable.PowerPack.Fetch
open Fable.Core.JsInterop

// Helpers to extract the Json values into a Result type
let number a =
    match a with
    | Json.Number a -> Ok(a)
    | _ -> Error(System.Exception("Invalid JSON, it must be a number"))

let string a =
    match a with
    | Json.String a -> Ok(a)
    | _ -> Error(System.Exception("Invalid JSON, it must be a string"))

let lookup (key: string) (a: Map<string, Json.Json>) =
    match Map.tryFind key a with
    | Some(a) -> Ok(a)
    | None -> Error(System.Exception("Could not find key " + key))

let object a =
    match a with
    | Json.Object a -> Ok(Map.ofArray a)
    | _ -> Error(System.Exception("Invalid JSON, it must be an object"))

let array a =
    match a with
    | Json.Array a -> Ok(a)
    | _ -> Error(System.Exception("Invalid JSON, it must be an array"))

let getStatus baseUri pinIds = 
    promise {
        let uri = sprintf "%s/api/pin/status?pins=0&pins=1&pins=2&pins=3&pins=4&pins=5" baseUri
        let! response = fetch uri []
        let! text = response.text()
        let status = ofJson<Map<int, bool>>(text)          
        return status
    }