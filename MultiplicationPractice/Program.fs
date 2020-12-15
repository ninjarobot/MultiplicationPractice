open System

type Problem = Multiplication of Factor1:int * Factor2:int

module Problem =
    let format = function
        | Multiplication (factor1, factor2) ->
            sprintf "%d x %d = " factor1 factor2
    
    let generate (max:int) =
        let rng = Random()
        seq {
            while true do
                let factor1 = rng.Next(max + 1)
                let factor2 = rng.Next(max + 1)
                Multiplication (factor1, factor2)
        }

    let check (answer:string) = function
        | Multiplication (factor1, factor2) ->
            match Int32.TryParse (answer.Trim()) with
            | true, parsed when parsed = factor1 * factor2 -> true
            | _ -> false
    
    let rec printAndCheck (problem:Problem) =
        problem |> format |> printf "%s"
        let res = Console.ReadLine ()
        if not <| (problem |> check res) then
            printAndCheck problem


[<EntryPoint>]
let main argv =
    let max =
        if argv.Length > 0 then
            match Int32.TryParse argv.[0] with
            | true, parsed -> parsed
            | _ ->
                eprintfn "Unable to read max factor, exiting."
                Environment.Exit(0)
                0
        else
            12
    printfn "Multiplication problems up to %d coming up. Press Ctrl+C to exit." max
    Problem.generate max |> Seq.iter Problem.printAndCheck
    0
