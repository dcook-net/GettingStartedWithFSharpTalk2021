module DependencyInjectionTests

open FSharpSyntax.DependencyInjection
open MongoDB.Bson
open Xunit
open FsUnit.Xunit

// For these tests to run successfully, start a local mongo server running
// on the default port with no security, or launch a Docker container with the following cmd: 
// 
// docker run -p 27017:27017 mongo:4.2.15

let customerId = "12345"

let (config:DbConfig) = {
    Server = "mongodb://localhost:27017"
    DBName = "MyCompany"
    CollectionName = "Customer"
}

let runTestSetup customerId =

    let customer = {
        _id = ObjectId.GenerateNewId()
        CustomerId = customerId
        EmailAddress = "customer@email.com"
        Name = "Real Customer Person"
    }

    let database = DB.getDatabase config
    database.DropCollection config.CollectionName
    
    let collection = DB.getCollection<Customer> config
    collection.InsertOne customer

    customer._id.ToString()


open FSharpSyntax.DependencyInjection.TightlyCoupledApplicationCode


[<Fact>]
let ``Tightly Coupled ApplicationCode Get Customer`` () =
    let id = runTestSetup customerId
    
    let customer = printCustomerDetails config customerId
    
    customer |> should equal { _id = id |> ObjectId.Parse
                               CustomerId = customerId
                               EmailAddress = "customer@email.com"
                               Name = "Real Customer Person"}
    
open FSharpSyntax.DependencyInjection.LooselyCoupledApplicationCode
[<Fact>]
let ``Loosely Coupled ApplicationCode Get Customer`` () =

    let id = runTestSetup customerId
    
    let getCollection = DB.getCollection
    let getCustomer = DB.getCustomer
    
    let customer = printCustomerDetails config getCollection getCustomer customerId
    
    customer |> should equal { _id = id |> ObjectId.Parse
                               CustomerId = customerId
                               EmailAddress = "customer@email.com"
                               Name = "Real Customer Person"}

open FSharpSyntax.DependencyInjection.LooselyCoupledApplicationCodeWithPartialApplication


[<Fact>]
let ``Loosely Coupled ApplicationCode with Partial Application Get Customer`` () =

    let id = runTestSetup customerId
    
    let getCustomer = DB.getCustomer config DB.getCollection<Customer>
    
    let customer = printCustomerDetails getCustomer customerId
    
    customer |> should equal { _id = id |> ObjectId.Parse
                               CustomerId = customerId
                               EmailAddress = "customer@email.com"
                               Name = "Real Customer Person"}
