open System
open System.IO

// Global helpers
let read(day: int) = File.ReadAllLines($@"challenges/{day}.txt")

// Solutions
let december1st =
    // Part I
    let toArrayInt(array: string[]) = array |> Array.map Int32.Parse
    let measurementsIncreased(array: int[]) = array
                                            |> Array.pairwise
                                            |> Array.filter(fun (current, next) -> current < next)

    let array = toArrayInt(read(1))

    let result1 = array
                |> (fun a -> measurementsIncreased(a))
                |> Array.length
    //Part II
    let result2 = array
                |> Array.windowed 3 |> Array.map(fun a -> a |> Array.sum)
                |> (fun a -> measurementsIncreased(a))
                |> Array.length

    (result1, result2)

let december2nd =
    let matcher(a: string[]) =
        match a with
        | a when a[0].Contains("up")      -> (0, (a[1] |> Int32.Parse) * -1)
        | a when a[0].Contains("down")    -> (0, a[1] |> Int32.Parse)
        | a when a[0].Contains("forward") -> (a[1] |> Int32.Parse, 0) 
        | _                               -> (0, 0)

    let resTuple =
        read(2)
        |> Array.map(fun s -> s.Split(" "))
        |> Array.map(fun arr -> matcher arr)
        |> Array.fold(fun (x, y)(z, w) -> (x + z, y + w)) (0, 0)
    fst resTuple * snd resTuple

let december3rd =
    // Part I
    let mostFrequest(array: int[]) =
        array
        |> Array.countBy id
        |> Array.maxBy snd
        |> fst

    let toSplitIntArray(array: string[]) = array |> Array.map(fun s -> s.ToCharArray()|> Array.map(fun i -> int(Char.GetNumericValue(i))))

    let array = toSplitIntArray(read(3))
    let gammaRateBinaryArray = array |> Array.transpose |> Array.map(fun a -> mostFrequest(a))

    let flipBit(bit: int) =
        match bit with
        | 0 -> 1
        | 1 -> 0
        | _ -> raise(NotImplementedException())

    let epsilonRateBinaryArray = gammaRateBinaryArray |> Array.map(flipBit)

    let flattenArray(array: int[]) = array |> Array.map string |> String.concat ""
    let binaryStringToInt(binary: string) = Convert.ToInt32(binary, 2)

    binaryStringToInt(flattenArray(gammaRateBinaryArray)) * binaryStringToInt(flattenArray(epsilonRateBinaryArray))

    
[<EntryPoint>]
let main args =
    let input = args[0]
    if (input = "1") then printf "%A" december1st
    else if (input = "2") then printf "%A" december2nd
    else if (input = "3") then printf "%A" december3rd
    else printf "%A" "NOT_IMPLEMENTED"
    0