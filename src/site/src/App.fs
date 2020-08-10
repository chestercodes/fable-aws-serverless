module App

open Feliz
open Elmish
open Shared.Dtos
open Thoth.Fetch
open Fable.Core

type State = { Customer: Customer option }

type Msg =
    | CallGet
    | CallPost
    | ReceivedCustomer of Customer

let init() = { Customer = None }, Cmd.none

let customerPost (data: CustomerCreate): JS.Promise<Customer> = 
    promise {
        return! Fetch.post("/api/customer", data)
    }
    
let customerGet id: JS.Promise<Customer> = 
    promise {
        let url = sprintf "/api/customer/%s" id
        return! Fetch.get(url)
    }
    
let update (msg: Msg) (state: State) =
    match msg with
    | CallGet -> 
        state, Cmd.OfPromise.perform customerGet "123" ReceivedCustomer
    | CallPost -> 
        let data = { Name = "James"; Age = 40; }
        state, Cmd.OfPromise.perform customerPost data ReceivedCustomer
    | ReceivedCustomer customer ->
        { state with Customer = Some customer }, Cmd.none

let render (state: State) (dispatch: Msg -> unit) =
    Html.div [
        Html.button [
            prop.onClick (fun _ -> dispatch CallGet)
            prop.text "Call get customer"
        ]

        Html.button [
            prop.onClick (fun _ -> dispatch CallPost)
            prop.text "Call post customer"
        ]

        match state.Customer with
        | Some customer -> 
            Html.div [
                Html.p (customer.Name)
                Html.p (customer.Id)
            ]
        | None -> Html.div []
    ]
