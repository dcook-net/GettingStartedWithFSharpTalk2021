module Tests.MathsTests

open Maths
open Xunit
open FsUnit.Xunit

[<Fact>]
let ``2 eights squared is 128`` =
    8
    |> Maths.add 8
    |> Maths.square
    |> should equal 128
