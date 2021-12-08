module Dec02

open System

let result(input: string[]) =
    let result1 =
        let matcher(a: string[]) =
            let direction = a[0]
            let number = a[1]|> Int32.Parse

            match direction with
            | direction when direction.Equals("up")      -> (0, number * -1)
            | direction when direction.Equals("down")    -> (0, number)
            | direction when direction.Equals("forward") -> (number, 0) 
            | _                               -> raise(NotImplementedException())

        input
        |> Array.map(fun s -> s.Split(" "))
        |> Array.map(matcher)
        |> Array.fold(fun (x, y)(z, w) -> (x + z, y + w)) (0, 0)
        |> (fun (f, s) -> f * s)

    let result2 =
        let matcher(a: string[]) =
            let direction = a[0]
            let number = a[1]|> Int32.Parse

            match direction with
            | direction when direction.Equals("up")      -> (0, number * -1)
            | direction when direction.Equals("down")    -> (0, number)
            | direction when direction.Equals("forward") -> (number, 0) 
            | _                               -> raise(NotImplementedException())

        input
        |> Array.map(fun s -> s.Split(" "))
        |> Array.map(matcher)
        |> Array.fold(fun (h1, depth, a1)(h2, a2) -> (h1 + h2, depth + (a1 * h2), a1 + a2)) (0, 0, 0)
        |> (fun (f, s, t) -> f * s)

    (result1, result2)