module Dec01

open System

let result(input: string[]) =
    let toArrayInt(array: string[]) = array |> Array.map Int32.Parse
    let measurementsIncreased(array: int[]) = array
                                            |> Array.pairwise
                                            |> Array.filter(fun (current, next) -> current < next)

    let array = toArrayInt(input)

    // Part I
    let result1 = array
                |> (fun a -> measurementsIncreased(a))
                |> Array.length
    //Part II
    let result2 = array
                |> Array.windowed 3 |> Array.map(fun a -> a |> Array.sum)
                |> (fun a -> measurementsIncreased(a))
                |> Array.length

    (result1, result2)