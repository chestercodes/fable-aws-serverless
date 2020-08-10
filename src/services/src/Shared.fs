module Shared

module Dtos =
    type CustomerCreate = { Name: string; Age: int; }
    type Customer =       { Name: string; Age: int; Id: int; }