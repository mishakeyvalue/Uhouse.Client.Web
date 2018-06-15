module LampScheduler.Api

open Fable.PowerPack
open System
open Fable.PowerPack.Fetch
open Fable.Import.Browser

let toString (ts:TimeSpan) = sprintf "%02i:%02i:%02i" ts.Hours ts.Minutes ts.Seconds

let sumbitSchedule uri (delay: TimeSpan) (duration: TimeSpan) = 
    let formData = FormData.Create()
    formData.append("delay", toString delay)
    formData.append("duration", toString duration)
    printfn "Delay: %A; Duration: %A" delay duration
    fetch 
        (sprintf "%s/api/lamp/schedule" uri)
        [
            RequestProperties.Method HttpMethod.POST
            RequestProperties.Body (unbox formData)
        ]