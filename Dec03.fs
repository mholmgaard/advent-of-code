module Dec03

open System

let result(input: string[]) =
    let mostFrequest(array: int[]) =
        array
        |> Array.countBy id
        |> Array.maxBy snd
        |> fst

    let toSplitIntArray(array: string[]) = array |> Array.map(fun s -> s.ToCharArray()|> Array.map(fun i -> int(Char.GetNumericValue(i))))

    let array = toSplitIntArray(input)
    let gammaRateBinaryArray = array |> Array.transpose |> Array.map(mostFrequest)

    let flipBit(bit: int) =
        match bit with
        | 0 -> 1
        | 1 -> 0
        | _ -> raise(NotImplementedException())

    let epsilonRateBinaryArray = gammaRateBinaryArray |> Array.map(flipBit)

    let flattenArray(array: int[]) = array |> Array.map string |> String.concat ""
    let binaryStringToInt(binary: string) = Convert.ToInt32(binary, 2)

    binaryStringToInt(flattenArray(gammaRateBinaryArray)) * binaryStringToInt(flattenArray(epsilonRateBinaryArray))