module FSharpSyntax.ErrorHandling_AskTheCaller

open ContactMethod
open System.Collections.Generic

let findByKey (cache:IDictionary<'a, 'b>) key =
    cache.Item key //Will throw when key not found!

let people = dict[ "DC", dave; "GF", graham; "RN", ross]

let rh = findByKey people "RH"
    
let findByKeyOrDefault defaultF (cache:IDictionary<'a, 'b>) key =
    if cache.ContainsKey key then cache.Item key
    else defaultF key

let lookupPersonFromSomeWhereElse key =
    //Connect to DB/or make HTTP Call
    { FirstName="Rob"; Surname="Harris"; ContactMethod = Email "rob@email.com" }

let rob = findByKeyOrDefault lookupPersonFromSomeWhereElse people "RH"