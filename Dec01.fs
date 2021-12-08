module Dec01

open System

let result(input: string[]) =
    let toArrayInt(array: string[]) = array |> Array.map Int32.Parse
    let measurementsIncreased(array: int[]) = array
                                            |> Array.pairwise
                                            |> Array.filter(fun (current, next) -> current < next)

    let array = toArrayInt(input)

    let result1 = array
                |> measurementsIncreased
                |> Array.length

    let result2 = array
                |> Array.windowed 3 |> Array.map(Array.sum)
                |> measurementsIncreased
                |> Array.length

    (result1, result2)