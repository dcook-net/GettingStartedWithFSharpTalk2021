module ContactMethodTests.Functions

open Xunit
open FsUnit.Xunit
open FSharpSyntax.ContactMethod

let person = {
     FirstName = "dave"
     Surname = "cook"
     ContactMethod = Phone ""
}

[<Fact>]
let ``Returns Phone`` () =
    
    let person = {
     FirstName = "dave"
     Surname = "cook"
     ContactMethod = Phone "01733 555888"
    }
    
    person
    |> getContactDetails
    |> should equal "Phone #: 01733 555888"

[<Fact>]
let ``Returns Email`` () =
    
    {
        FirstName = "dave"
        Surname = "cook"
        ContactMethod = Email "some.email@email.co.uk"
    }
    |> getContactDetails
    |> should equal "Email: some.email@email.co.uk"
    
[<Fact>]
let ``Returns Postal Address`` () =
    
    let person = {
     FirstName = "dave"
     Surname = "cook"
     ContactMethod = Post [
         "Pegasus House"
         "Bakewell Road"
         "Peterborough"
         "PE2 6YS"
         ]
    }
    
    person |> getContactDetails |> should equal "Address: Pegasus House, Bakewell Road, Peterborough, PE2 6YS"