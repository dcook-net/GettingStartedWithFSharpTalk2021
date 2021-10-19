module LoanCalculatorTests

open FSharpSyntax
open Xunit
open Xunit.Sdk

let isOk expectedValue result =
    match result with
    | Ok innerValue when innerValue = expectedValue -> TestPassed |> ignore
    | Error msg -> Assert.True(false, msg)
    | Ok unexpected -> Assert.True(false, $"Result was Ok, but inner value was: {unexpected}")
    
[<Fact>]
let ``Calculates Monthly Repayments V1`` () =
    
    LoanCalculator.calculateMonthlyRepaymentV1 10_000m 36 2.9m
    |> isOk 290.37m


[<Fact>]
let ``Calculates Monthly Repayments using refactored calculator`` () =
    
    let loanAmount = LoanAmount.tryCreate 10_000m
    let term = LoanTerm.tryCreate 36
    let apr = Apr.tryCreate 2.9m
    
    let result = LoanCalculator.calculateRepaymentV2 loanAmount term apr
    
    result |> isOk 290.37m
    


    
