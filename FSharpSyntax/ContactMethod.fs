module FSharpSyntax.ContactMethod

open System

type ContactMethod =
//EITHER
| Email of string
//OR
| Phone of string
//OR
| Post of string list
//OR
| Twitter of string

    
type Person = {
    FirstName: string
    Surname: string
    ContactMethod: ContactMethod
  }


let dave = {
    FirstName = "dave"
    Surname = "cook"
    ContactMethod = Email "dave@email.com"
}

let graham = { FirstName = "graham"; Surname = "Fearn";
    ContactMethod = Phone "01733 123456"
}

let ross = { FirstName = "Ross"; Surname = "Nielson"
             ContactMethod = Post ["42 London Rd"; "Peterborough"; "PE9 6XL"] }

let formatAddress addressLines =
    List.fold (fun acc elem -> acc + elem + ", ") String.Empty addressLines
    |> (fun s -> s.Substring(0, s.Length - 2))

let getContactDetails person =
    match person.ContactMethod with
    | Email address -> $"Email: %s{address}"
    | Phone number -> $"Phone #: %s{number}"
    | Post address -> address |> formatAddress |> sprintf "Address: %s"
    
let printPersonContactDetails person =
    let contactInfo = getContactDetails person
    
    printfn $"Name: %s{person.Surname}, %s{person.FirstName}"    
    printfn $"%s{contactInfo}"