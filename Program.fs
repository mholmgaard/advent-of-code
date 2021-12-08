open System.IO

let read(day: string) = File.ReadAllLines($@"challenges/{day}.txt")
    
[<EntryPoint>]
let main args =
    let input = args[0]
    if      (input = "1") then printf "%A" (Dec01.result(read(input)))
    else if (input = "2") then printf "%A" (Dec02.result(read(input)))
    else if (input = "3") then printf "%A" (Dec03.result(read(input)))
    else printf "%A" "NOT_IMPLEMENTED"
    0