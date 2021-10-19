module Apr

open System

type Apr = private Apr of decimal

let tryCreate apr =
    match apr with
    | n when n < 0.00m || n > 100.0m ->
        raise (ArgumentOutOfRangeException "Apr should be between 0.00 and 100.00")
    | _ -> Apr apr

let tryCreate2 apr =
    match apr with
    | n when n < 0.00m || n > 100.0m ->
        Error "Apr should be between 0.00 and 100.00"
    | _ -> Apr apr |> Ok
    
let getValue (Apr apr) = apr