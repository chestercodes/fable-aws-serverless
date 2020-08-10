module App

open Fable.Core.JsInterop
open Fable.Core.JS
open AwsTypes

let apiGatewayResponse code body =
    {
        isBase64Encoded = false
        statusCode = code
        headers = createEmpty
        body = JSON.stringify body
    }

let ok body = apiGatewayResponse 200 body
let notFound = apiGatewayResponse 404 ""
let badRequest body = apiGatewayResponse 400 body

open Fable.SimpleJson
open Shared.Dtos

let customerPost ((event: ApiGatewayEvent), (context: AwsLambdaContext)) =
    match event.body |> Json.tryParseAs<CustomerCreate> with
    | Ok dto -> 
        // act as if this is saved somewhere and return Customer object.
        ok { Id = 234; Name = dto.Name; Age = dto.Age; }
    | Error error -> badRequest error
    |> context.succeed

open Fable.Core.DynamicExtensions

let getId pathParameters = pathParameters.["id"].ToString()

let tryFindCustomer id =
    // pretending as if this is retrieving from a database or similar
    match id with
    | "123" -> Some { Id = 123; Name = "John"; Age = 30; }
    | _ -> None

let tryGetCustomer = getId >> tryFindCustomer
    
let customerGet ((event: ApiGatewayEvent), (context: AwsLambdaContext)) =    
    match tryGetCustomer event.pathParameters with
    | Some customer -> ok customer
    | None          -> notFound
    |> context.succeed
