module FSharpSyntax.AndTypes

open System

let coordinates = "C", 10 // X AND Y

type Coordinates = string*int //Creates an Alias for our Tuple

let (coordinates2:Coordinates) = "C", 10

type Person = {
    Id: Guid
    //AND
    FirstName: string
    //AND
    Surname: string
}