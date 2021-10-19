module FSharpSyntax.LoanCalculator

open System
open Microsoft.VisualBasic
 
let round (decimalPlaces:int) (number:decimal) =
    Math.Round(number, decimalPlaces)
    
let tryPmt amount term monthlyRate =
    let loanAmount = amount * -1.00m |> float
    try
        Financial.Pmt(monthlyRate, term, loanAmount) |> decimal |> Ok
    with
    | :? Exception as ex -> Error ex.Message
    
let calculateMonthlyRate rate =
    (rate / 100.00m / 12.00m) |> double

let validateWithinBounds min max errorMessage amount =
    match amount with
    | n when n < min || n > max -> Error errorMessage
    | _ -> Ok amount

let validateLoanTerm =
    validateWithinBounds 12.00m 60.00m "Loan term should be between 12 and 60 months. 1 - 5 years."

let validateLoanAmount =
    validateWithinBounds 1000.00m 10_000.00m "Loan amount should be between 1,000.00 and 10,000.00"
    
let validateApr =
    validateWithinBounds 0.00m 100.0m "Apr should be between 0.00 and 100.00"

let aggregate validationResults =
    validationResults
    |> List.fold (fun acc elem ->
                    match elem with
                    | Ok _ -> acc
                    | Error msg -> acc + ", " + msg) String.Empty
    |> function
          | msg when msg = String.Empty -> Ok ()
          | errors -> Error errors
    
let roundTo2Dp amount =
    amount |> round 2
    
let calculateMonthlyRepaymentV1 (principle:decimal) (term: int) (rate:decimal) =
    
    let validationResults = [
        validateLoanAmount principle
        validateLoanTerm (term |> decimal) 
        validateApr rate
    ]
    
    validationResults
    |> aggregate  
    |> function
      | Ok _ -> 
            rate
            |> calculateMonthlyRate
            |> tryPmt principle (term |> float)
            |> Result.map roundTo2Dp
        
      | Error msgs ->
            failwith msgs
   
    
open LoanAmount
open LoanTerm
open Apr
    
let calculateRepaymentV2 (amount:LoanAmount) (loanTerm:LoanTerm) (apr:Apr) =
    let principle = amount |> LoanAmount.getValue
    let term = loanTerm |> LoanTerm.getValue |> float
    let rate = apr |> Apr.getValue |> decimal
    
    rate
    |> calculateMonthlyRate
    |> tryPmt principle term
    |> Result.map roundTo2Dp
    