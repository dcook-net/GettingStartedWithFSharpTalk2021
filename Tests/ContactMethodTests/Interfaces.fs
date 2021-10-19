module ContactMethodTests.Interfaces

//NB: We are using F# to test C# here
open UsingInterfaces
open Xunit
open FsUnit.Xunit
open ObjectOrientedExamples.ContactMethod.UsingInterfaces
open ObjectOrientedExamples.ContactMethod.UsingInterfaces.Methods

[<Fact>]
let ``Returns Phone`` () =
    let contactMethod = Phone("01733 555888")
    
    let mutable (person:Person) = Person()
    person.Firstname <- "dave"
    person.Surname <- "cook"
    person.ContactMethod <- contactMethod :> IContactMethod
    
    person
    |> Example.GetContactDetails
    |> should equal "Phone #: 01733 555888"

[<Fact>]
let ``Returns Email`` () =
    let (contactMethod:IContactMethod) = Email("some.email@email.co.uk") :> IContactMethod
    
    let mutable person = Person()
    person.Firstname <- "dave"
    person.Surname <- "cook"
    person.ContactMethod <- contactMethod 
    
    person
    |> Example.GetContactDetails
    |> should equal "Email: some.email@email.co.uk"


[<Fact>]
let ``Returns Postal Address`` () =
    let contactMethod =
        Post("Pegasus House", "Bakewell Road", "Peterborough", "PE2 6YS")
        :> IContactMethod
    
    let mutable person = Person("dave", "cook")
    person.ContactMethod <- contactMethod
    
    person
    |> Example.GetContactDetails
    |> should equal "Address: Pegasus House, Bakewell Road, Peterborough, PE2 6YS"
