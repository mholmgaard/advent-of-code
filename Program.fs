open System.IO

let read(day: int) = File.ReadAllLines($@"challenges/{day}.txt")
    
[<EntryPoint>]
let main args =
    let input = args[0]
    if      (input = "1") then printf "%A" (Dec01.result(read(1)))
    else if (input = "2") then printf "%A" (Dec02.result(read(2)))
    else if (input = "3") then printf "%A" (Dec03.result(read(3)))
    else printf "%A" "NOT_IMPLEMENTED"
    0