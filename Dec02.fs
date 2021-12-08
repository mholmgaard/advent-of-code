module Dec02

open System

let result(input: string[]) =
    let matcher(a: string[]) =
        match a with
        | a when a[0].Contains("up")      -> (0, (a[1] |> Int32.Parse) * -1)
        | a when a[0].Contains("down")    -> (0, a[1] |> Int32.Parse)
        | a when a[0].Contains("forward") -> (a[1] |> Int32.Parse, 0) 
        | _                               -> raise(NotImplementedException())

    let resTuple =
        input
        |> Array.map(fun s -> s.Split(" "))
        |> Array.map(fun arr -> matcher arr)
        |> Array.fold(fun (x, y)(z, w) -> (x + z, y + w)) (0, 0)
    fst resTuple * snd resTuple