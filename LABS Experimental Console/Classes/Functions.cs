/*
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
*/
using LeoCorpLibrary.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LABS_Experimental_Console.Classes
{
    public static class Functions
    {
        public static void WriteHelp()
        {
            Console.ForegroundColor = ConsoleColor.Blue; // Changer la couleur
            Console.WriteLine("+----+ Help +----+"); // Ecrire
            Console.ResetColor(); // Mettre la couleur par défaut
            Console.WriteLine("Here's all the available commands:"); // Ecrire
            Console.WriteLine(""); // Ecrire
            Console.WriteLine("about : Shows credits"); // Ecrire
            Console.WriteLine("beep : Beep"); // Ecrire
            Console.WriteLine("clear, cls : Clears the console"); // Ecrire
            Console.WriteLine("exit : Closes the console"); // Ecrire
            Console.WriteLine("help : Dhows help"); // Ecrire
            Console.WriteLine("list : Shows commands"); // Ecrire
            Console.WriteLine("logo : Show le logo"); // Ecrire
            Console.WriteLine("repo : Opens the GitHub repo"); // Ecrire
            Console.WriteLine("update : Checks updates"); // Ecrire
            Console.WriteLine("usage : Shows how to use commands"); // Ecrire
            Console.WriteLine("ver : Shows the version"); // Ecrire
            Console.WriteLine("searchfile : Search throught files"); // Ecrire
            Console.WriteLine("test : A test command that can be changed"); // Ecrire
            Console.WriteLine("dotnet : Allows you to get the .NET version"); // Ecrire
            Console.WriteLine("leocorplibrary : Tests about LeoCorpLibrary.Core"); // Ecrire
            Console.WriteLine("passwords : Allows you to generate multiple passwords"); // Ecrire
        }

        public static void WriteCommands() 
        {
            Console.ForegroundColor = ConsoleColor.Blue; // Changer la couleur
            Console.WriteLine("+----+ Commands +----+"); // Ecrire
            Console.ResetColor(); // Mettre la couleur par défaut
            Console.WriteLine("Here's the list of all the commands"); // Ecrire
            Console.WriteLine(""); // Ecrire
            for (int i = 0; i < Definitions.Commands.Length; i++)
            {
                Console.WriteLine(Definitions.Commands[i]); // Ecrire
            }
        }

        public static void PrintLogo()
        {
            Console.WriteLine(@"       _______  ");
            Console.WriteLine(@"       \     /  ");
            Console.WriteLine(@"        |   |   ");
            Console.WriteLine(@"       /    \   ");
            Console.WriteLine(@"      /      \  ");
            Console.WriteLine(@"     /        \ ");
            Console.WriteLine(@"    /          \");
            Console.WriteLine(@"    \__________/");
        }

        public static bool IsUpdateAvailable()
        {
            bool res = false; // Résultat
            if (Definitions.Version != new WebClient().DownloadString("https://raw.githubusercontent.com/Leo-Corporation/LeoCorp-Docs/master/Liens/Update%20System/LABS%20Experimental%20Console/version.txt"))
            {
                res = true;   
            }
            else
            {
                res = false;
            }
            return res;
        }

        public static T[] Append<T>(this T[] array, T item)
        {
            T[] items = { item };
            return new List<T>(array.Concat(items)).ToArray();
        }

        public static void SearchFiles(string fileName, string path)
        {
            try
            {
                foreach (string file in Directory.GetFiles(path, fileName, SearchOption.AllDirectories))
                {
                    Console.Write("Found file ");
                    Console.ForegroundColor = ConsoleColor.Blue; // Changer la couleur
                    Console.Write("> "); // Ecrire
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(file);
                    Console.ResetColor(); // Mettre la couleur par défaut
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[{ex.Source}] An error occured: " + ex.Message);
                Console.ResetColor();
            }
        }

        public static bool OpenBrowser(string url)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Process.Start(new ProcessStartInfo("cmd", $"/c start {url.Replace("&", "^&")}") { CreateNoWindow = true });
                return true;
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", url);
                return true;
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", url);
                return true;
            }
            return false;
        }

        public static void MultiplePasswords()
		{
            List<string> passwords = Password.GenerateAmount(10, 50, PasswordPresets.Complex);
            for (int i = 0; i < passwords.Count; i++)
			{
                Console.WriteLine($"{i+1}. {passwords[i]}"); // Print message
			}
        }

        public static void TestLeoCorpLibrary()
        {
            Console.WriteLine($"The area of circle where R=10cm is {Maths.Circle.GetArea(10)}");
            Console.WriteLine($"The 55;21;125 RGB color in HEX is #{ColorsConverter.RGBtoHEX(55, 21, 125).Value}");
            Console.WriteLine($"The current Windows version is {Env.GetWindowsVersion()}");
            Console.WriteLine($"The current Unix Time is {Env.GetUnixTime()}");
        }

        public static void PrintUsage(string command)
        {
            Console.ResetColor(); // Réintialiser
            switch (command)
            {
                case "help":
                    Console.WriteLine("Usage of 'help' : help"); // Ecrire
                    break;
                case "ver":
                    Console.WriteLine("Usage of 'ver' : ver"); // Ecrire
                    break;
                case "update":
                    Console.WriteLine("Usage of 'update' : update"); // Ecrire
                    break;
                case "list":
                    Console.WriteLine("Usage of 'list' : list"); // Ecrire
                    break;
                case "exit":
                    Console.WriteLine("Usage of 'exit' : exit"); // Ecrire
                    break;
                case "about":
                    Console.WriteLine("Usage of 'about' : about"); // Ecrire
                    break;
                case "clear":
                    Console.WriteLine("Usage of 'clear' : clear"); // Ecrire
                    break;
                case "cls":
                    Console.WriteLine("Usage of 'cls' : cls"); // Ecrire
                    break;
                case "beep":
                    Console.WriteLine("Usage of 'beep' : beep"); // Ecrire
                    break;
                case "logo":
                    Console.WriteLine("Usage of 'logo' : logo"); // Ecrire
                    break;
                case "repo":
                    Console.WriteLine("Usage of 'repo' : repo"); // Ecrire
                    break;
                case "usage":
                    Console.WriteLine("Usage of 'usage' : usage"); // Ecrire
                    break;
                case "sum":
                    Console.WriteLine("Usage of 'sum' : sum"); // Ecrire
                    break;
                case "searchfile":
                    Console.WriteLine("Usage of 'searchfile' : searchfile"); // Ecrire
                    break;
                case "test":
                    Console.WriteLine("Usage of 'test' : test");
                    break;
                case "dotnet":
                    Console.WriteLine("Usage of 'dotnet' : dotnet");
                    break;
            }
        }
    }
}
