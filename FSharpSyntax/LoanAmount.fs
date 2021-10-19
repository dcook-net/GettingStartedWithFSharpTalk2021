module LoanAmount
open System

type LoanAmount = private LoanAmount of decimal
       
let tryCreate amount =
    match amount with
    | n when n < 1000.00m || n > 10_000.00m ->
        "Loan amount should be between 1000.00 and 10,000.00"
        |> ArgumentOutOfRangeException
        |> raise
    | _ -> LoanAmount amount 

let tryCreate2 amount =
    match amount with
    | n when n < 1000.00m || n > 10_000.00m ->
        Error "Loan amount should be between 1000.00 and 10,000.00"
    | _ ->  LoanAmount amount |> Ok
    
let getValue (LoanAmount amount) = amount