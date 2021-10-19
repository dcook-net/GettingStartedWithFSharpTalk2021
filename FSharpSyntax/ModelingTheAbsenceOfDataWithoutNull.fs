module FSharpSyntax.ModelingTheAbsenceOfDataWithoutNull

type EmailAddress = EmailAddress of string
type LanguageCode = LanguageCode of string
type CountryCode = CountryCode of string

type User = {
    Email : EmailAddress
    Language: LanguageCode
    Location: CountryCode option
}

let English = LanguageCode "English"
let UK = CountryCode "UK"

let pete = {
    Email=EmailAddress "pete@email.com"
    Language=English
    Location = Some UK
}

let claire = {
    Email=EmailAddress "claire@email.com"
    Language=English
    Location = None
}

let getLocation1 user =
    match user.Location with
    | Some countryCode -> countryCode |> string
    | None -> "Unknown!"


let getLocation user =
    let (CountryCode countryCode) =
        Option.defaultValue (CountryCode "Unknown!") user.Location
    countryCode

let printUserLocation user =
    user
    |> getLocation
    |> printfn "User is based in: %s"
 