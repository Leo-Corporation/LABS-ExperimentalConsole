(*
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

module Global
    let public Version = "1.0.0.2111"
    let public PrintLogo() =
        printfn @"       _______  "
        printfn @"       \     /  "
        printfn @"        |   |   "
        printfn @"       /    \   "
        printfn @"      /      \  "
        printfn @"     /        \ "
        printfn @"    /          \"
        printfn @"    \__________/"

    let public Commands = ["about" ; "beep" ; "cls" ; "clear" ; "dotnet" ; "exit" ; "help" ; "list" ; "logo" ; "test" ; "ver"]

    let public PrintHelp() =
        System.Console.ForegroundColor <- System.ConsoleColor.Blue; // Change color
        printfn "+----+ Help +----+" // Write line
        System.Console.ResetColor(); // Set default color
        printfn"Here's all the available commands:" // Write line
        printfn"" // Write line
        printfn"about : Shows credits" // Write line
        printfn"beep : Beep" // Write line
        printfn"clear, cls : Clears the console" // Write line
        printfn"exit : Closes the console" // Write line
        printfn"help : Dhows help" // Write line
        printfn"list : Shows commands" // Write line
        printfn"logo : Show le logo" // Write line
        printfn"repo : Opens the GitHub repo" // Write line
        printfn"update : Checks updates" // Write line
        printfn"usage : Shows how to use commands" // Write line
        printfn"ver : Shows the version" // Write line
        printfn"searchfile : Search throught files" // Write line
        printfn"test : A test command that can be changed" // Write line
        printfn"dotnet : Allows you to get the .NET version" // Write line
        printfn"leocorplibrary : Tests about LeoCorpLibrary.Core" // Write line
        printfn"passwords : Allows you to generate multiple passwords" // Write line