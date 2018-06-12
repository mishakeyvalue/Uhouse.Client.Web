module PinControl.Api

open Fable.PowerPack

let pinRequest mode baseUri = Fetch.postRecord (sprintf "%s/api/pin/1/%s" baseUri mode) () []
let turnOnRequest uri = pinRequest "on" uri
let turnOffRequest uri = pinRequest "off" uri
