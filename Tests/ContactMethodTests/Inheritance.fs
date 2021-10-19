module ContactMethodTests.Inheritance

//NB: We are using F# to test C# here

open Xunit
open FsUnit.Xunit
open ObjectOrientedExamples.ContactMethod.UsingInheritance

[<Fact>]
let ``Returns Phone`` () =
    let (contactMethod:Phone) = Phone("01733 555888")
    
    let mutable (person:Person) = Person()
    person.Firstname <- "dave"
    person.Surname <- "cook"
    person.ContactMethod <- contactMethod
    
    person
    |> Example.GetContactDetails
    |> should equal "Phone #: 01733 555888"

[<Fact>]
let ``Returns Email`` () =
    let contactMethod = Email("some.email@email.co.uk")
    
    let mutable person = Person()
    person.Firstname <- "dave"
    person.Surname <- "cook"
    person.ContactMethod <- contactMethod
    
    person
    |> Example.GetContactDetails
    |> should equal "Email: some.email@email.co.uk"

[<Fact>]
let ``Returns Postal Address`` () =
    let contactMethod = Post("Pegasus House", "Bakewell Road", "Peterborough", "PE2 6YS")
    
    let mutable person = Person("dave", "cook")
    person.ContactMethod <- contactMethod
    
    person
    |> Example.GetContactDetails
    |> should equal "Address: Pegasus House, Bakewell Road, Peterborough, PE2 6YS"
