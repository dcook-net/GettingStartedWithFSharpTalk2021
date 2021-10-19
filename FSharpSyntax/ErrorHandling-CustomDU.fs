module FSharpSyntax.ErrorHandling_CustomDU

open SafeString
open System.IO

type readResult =
    | InvalidDirectory
    | InvalidFileName
    | FileIsEmpty
    | Valid of string list

let readFromFile (path:SafeString) (fileName:SafeString) =
    let pathToFile = path |> getValue
    let fName = fileName |> getValue
    
    if Directory.Exists pathToFile then
        let fullFileName = pathToFile + fName
        if File.Exists fullFileName then 
            fullFileName
            |> File.ReadAllLines
            |> function 
                | [||] -> FileIsEmpty
                | fileLines -> Array.toList fileLines |> Valid 
        else
            InvalidFileName
    else
        InvalidDirectory


let path = "/Users/dcook/" |> SafeString.tryCreate
let fileName = "monday.csv" |> SafeString.tryCreate
let readResult = readFromFile path fileName

let fileContent =
    match readResult with
    | Valid lines -> List.fold (+) "" lines
    | FileIsEmpty -> ""
    | InvalidDirectory -> ""
    | InvalidFileName -> ""