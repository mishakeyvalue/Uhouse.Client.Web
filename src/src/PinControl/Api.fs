module PinControl.Api

open Fable.PowerPack

let pinRequest mode baseUri pinId = Fetch.postRecord (sprintf "%s/api/pin/%i/%s" baseUri pinId mode) () []
let turnOnRequest uri pinId = pinRequest "on" uri pinId
let turnOffRequest uri pinId = pinRequest "off" uri pinId
