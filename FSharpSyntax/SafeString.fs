module SafeString 

open System

type SafeString = private SafeString of string

let tryCreate s =
    match s with
    | null -> SafeString String.Empty
    | _ -> SafeString s
    
let getValue (SafeString s) = s

//This is an overly simple example.
//See fsharpforfunandprofit.com/posts/designing-with-types-more-semantic-types for a more complete example