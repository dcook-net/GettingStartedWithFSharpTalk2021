module Tests.FunctionalCodeYouAlreadyKnowTests

//NB: We are using F# to test C# here

open FSharpSyntax.FunctionalCodeYouAlreadyKnow

open FsUnit.Xunit
open Xunit

[<Fact>]
let ``Should sum the total of even squares between 1 and 10 v1`` () =
    totalOfEvenNumbersUpTo 10
    |> should equal 220
    
[<Fact>]
let ``Should sum the total of even squares between 1 and 10 v2`` () =
    totalOfEvenNumbersUpToV2 10
    |> should equal 220