module FSharpSyntax.DependencyInjection

open System.Runtime.Serialization
open System.Threading
open MongoDB.Bson
open MongoDB.Bson.Serialization.Attributes
open MongoDB.Driver

[<CLIMutable>]
[<DataContract>]
type Customer = {
    [<BsonId>]
    _id:ObjectId
    CustomerId: string
    EmailAddress: string
    Name:string
}

type DbConfig = {
    Server: string
    DBName: string
    CollectionName: string
}

    
module DB =
    let firstOrDefault (results:IFindFluent<Customer, Customer>) =
        results.FirstOrDefault CancellationToken.None
    
    let findCustomerById customerId (collection:IMongoCollection<Customer>) =
        collection.Find (fun customer -> customer.CustomerId = customerId)
    
    
    type GetCustomerF = DbConfig -> (DbConfig -> IMongoCollection<Customer>) -> string -> Customer
    
    
    let getCustomer =
        fun (dbConfig:DbConfig) (getCollection:DbConfig -> IMongoCollection<Customer>) (customerId:string) ->
            dbConfig
            |> getCollection
            |> findCustomerById customerId 
            |> firstOrDefault
    
    let getDatabase dbConfig = 
        dbConfig.Server
        |> MongoUrl
        |> MongoClient
        |> fun client -> client.GetDatabase dbConfig.DBName
        
    let getCollection<'a> dbConfig =
        dbConfig
        |> getDatabase
        |> fun db -> db.GetCollection<'a> dbConfig.CollectionName


module TightlyCoupledApplicationCode =
    
    let printCustomerDetails dbConfig customerId =
       
        let getCustomerCollection = DB.getCollection<Customer>
        
        let customer = DB.getCustomer dbConfig getCustomerCollection customerId
        
        printfn "Customer Name: %s, Email: %s" customer.Name customer.EmailAddress
        customer
        
        
module LooselyCoupledApplicationCode =
    
    let printCustomerDetails dbConfig getCollectionF (getCustomerF:DB.GetCustomerF) customerId =
        
        let customer = getCustomerF dbConfig getCollectionF customerId 
        
        printfn "Customer Name: {%s}; Email: {%s}" customer.Name customer.EmailAddress
        customer
        

module LooselyCoupledApplicationCodeWithPartialApplication =
    
    let printCustomerDetails getCustomerF customerId =
        
        let customer = getCustomerF customerId
        
        printfn "Customer Name: {%s}; Email: {%s}" customer.Name customer.EmailAddress
        
        customer