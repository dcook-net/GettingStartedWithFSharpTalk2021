module FSharpSyntax.FunctionalCodeYouAlreadyKnow

let totalOfEvenNumbersUpTo maxValue =
    [1 .. maxValue]                         // 1,2,3,4,5,6,7,8,9,10
    |> List.filter (fun x -> x % 2 = 0)     // 2,4,6,8,10
    |> List.map (fun x -> x * x)            // 4,16,36,64,100
    |> List.fold (fun acc elem -> acc + elem) 0;  // 220


let isEven x = x % 2 = 0
let squared x = x * x

let sum numbers =
    numbers
    |> List.fold (fun acc elem -> acc + elem) 0

let totalOfEvenNumbersUpToV2 maxValue =
    [1 .. maxValue]         // 1,2,3,4,5,6,7,8,9,10
    |> List.filter isEven   // 2,4,6,8,10
    |> List.map squared     // 4,16,36,64,100
    |> sum;                       // 220