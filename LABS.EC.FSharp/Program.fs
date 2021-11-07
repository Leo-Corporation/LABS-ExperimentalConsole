﻿(*
MIT License

Copyright (c) Léo Corporation

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE. 
*)

open System


let CommandExists command =
    let mutable r = false

    match command with
    | "about" when "about" = command -> r = false
    | "test" when "test" = command -> r = false    
    | "ver" when "ver" = command -> r = false
    | "cls" when "cls" = command -> r = false
    | "clear" when "clear" = command -> r = false
    | _ -> r = true
     

let GoHome() =
    Console.ForegroundColor <- ConsoleColor.Yellow // Change color
    printfn "" // Write line
    printfn "To get started, type a command. Type 'help' to show help."  // Write line
    Console.ForegroundColor <- ConsoleColor.Blue // Change color
    Console.Write(">>> ") // Write line
    Console.ResetColor() // Set default color

let rec ExecuteCommand command =
    let ex: bool = CommandExists command
    if ex then
        if command = "about" then
            Console.ForegroundColor <- ConsoleColor.Blue; // Change color
            printfn $"LABS Experimental Console © {DateTime.Now.Year} - Léo Corporation"
        elif command = "test" then
            printfn "This is a test command."
        elif command = "ver" then
            Console.ForegroundColor <- ConsoleColor.Blue; // Change color
            printfn $"Version {Global.Version}, Copyright {DateTime.Now.Year} - Léo Corporation" // Write line
        elif command = "cls" || command = "clear" then
            Console.Clear()
    else
        Console.ForegroundColor <- ConsoleColor.Red; // Set foreground color to red
        printfn "The command that you wrote doesn't exist. Type 'help' to get help." // Show message
        Console.ResetColor()

    GoHome()
    let x = Console.ReadLine()
    ExecuteCommand(x)

[<EntryPoint>]
let main argv =
    // Console setup
    Console.Title <- "Test Console v" + Global.Version
    Console.ForegroundColor <- ConsoleColor.Blue

    printfn $"Test Console v{Global.Version}, running on .NET {Environment.Version}"
    
    // Home
    GoHome()
    let x = Console.ReadLine()
    ExecuteCommand(x)

    0 // return an integer exit code