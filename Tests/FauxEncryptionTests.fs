module FauxEncryptionTests

open FsUnit.Xunit
open Xunit

[<Fact>]
let ``should transform string`` () =
    let result =
        " 1234567890 $%^& abcdefg ABCDEFG "
        |> PartialApplication.PartialApplicationUsedForComposition.transformStringV2
    
    result |> should equal "1234efg 1234efg"
    