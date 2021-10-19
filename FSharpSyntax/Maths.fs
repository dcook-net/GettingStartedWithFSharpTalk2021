module Maths

open System

let square x =
   x * x
   
let add a b = a + b

let generateNItems f n =
   [ 0 .. n ]
   |> List.map f
   
let randomNumberGeneratorV1 seed =
    Random(seed).Next(1_000)

let randomNumberGeneratorV2 () =
    Random(DateTime.UtcNow.Millisecond).Next(1_000)
    // Cant replace v1 with v2 without other changes, as the signatures do not match

let numbers = generateNItems randomNumberGeneratorV1 20