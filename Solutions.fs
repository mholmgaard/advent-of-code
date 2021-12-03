open System
open System.IO

let december1st =
    File.ReadAllLines(@"challenges/1.txt") |> Array.map Int32.Parse
    |> Array.pairwise
    |> Array.filter(fun (current, next) -> current < next)
    |> Array.length

let december2nd =
    let matcher(a: string[]) =
        match a with
        | a when a[0].Contains("up")      -> (0, (a[1] |> Int32.Parse) * -1)
        | a when a[0].Contains("down")    -> (0, a[1] |> Int32.Parse)
        | a when a[0].Contains("forward") -> (a[1] |> Int32.Parse, 0) 
        | _                               -> (0, 0)
    let resTuple =
        File.ReadAllLines(@"challenges/2.txt")
        |> Array.map(fun s -> s.Split(" "))
        |> Array.map(fun arr -> matcher arr)
        |> Array.fold(fun (x, y)(z, w) -> (x + z, y + w)) (0, 0)
    fst resTuple * snd resTuple

[<EntryPoint>]
let main args =
    let input = args.[0]
    if (input = "1") then printf "%A" december1st
    else if (input = "2") then printf "%A" december2nd
    else printf "%A" "NOT_IMPLEMENTED"
    0