open System
open System.IO

let december1st =
    File.ReadAllLines(@"challenges/1.txt") |> Array.map System.Int32.Parse
    |> Array.pairwise
    |> Array.filter(fun (current, next) -> current < next)
    |> Array.length
    


[<EntryPoint>]
let main args =
    let input = args.[0]
    if (input = "1") then printf "%A" december1st
    else printf "%A" "NOT_IMPLEMENTED"
    0