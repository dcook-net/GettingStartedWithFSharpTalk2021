module LoanTerm

open System

type LoanTerm = private LoanTerm of int

let tryCreate term =
    match term with
    | n when n < 12 || n > 60 ->
        ArgumentOutOfRangeException "Loan term should be between 12 and 60 months. 1 - 5 years."
        |> raise
    | _ -> LoanTerm term

let tryCreate2 term =
    match term with
    | n when n < 12 || n > 60 ->
        Error "Loan term should be between 12 and 60 months. 1 - 5 years."
    | _ -> LoanTerm term |> Ok

let getValue (LoanTerm term) = term