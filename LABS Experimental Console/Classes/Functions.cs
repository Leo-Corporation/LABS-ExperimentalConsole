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
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace LABS_Experimental_Console.Classes
{
    public static class Functions
    {
        public static void WriteHelp()
        {
            Console.ForegroundColor = ConsoleColor.Blue; // Changer la couleur
            Console.WriteLine("+----+ Aide +----+"); // Ecrire
            Console.ResetColor(); // Mettre la couleur par défaut
            Console.WriteLine("Voici les diverses commandes disponibles :"); // Ecrire
            Console.WriteLine(""); // Ecrire
            Console.WriteLine("about : Affiche les crédits"); // Ecrire
            Console.WriteLine("beep : Beep"); // Ecrire
            Console.WriteLine("clear, cls : Efface la console"); // Ecrire
            Console.WriteLine("exit : Ferme la console"); // Ecrire
            Console.WriteLine("help : Affiche l'aide"); // Ecrire
            Console.WriteLine("list : Affiche les commandes"); // Ecrire
            Console.WriteLine("logo : Affiche le logo"); // Ecrire
            Console.WriteLine("repo : Ouvre le dépôt GitHub"); // Ecrire
            Console.WriteLine("update : Vérifie si des mises à jour sont disponibles"); // Ecrire
            Console.WriteLine("usage : Affiche commant utiliser les commandes"); // Ecrire
            Console.WriteLine("ver : Affiche la version"); // Ecrire
        }

        public static void WriteCommands() 
        {
            Console.ForegroundColor = ConsoleColor.Blue; // Changer la couleur
            Console.WriteLine("+----+ Liste des commandes +----+"); // Ecrire
            Console.ResetColor(); // Mettre la couleur par défaut
            Console.WriteLine("Voici la liste des commandes"); // Ecrire
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

        public static void PrintUsage(string command)
        {
            Console.ResetColor(); // Réintialiser
            switch (command)
            {
                case "help":
                    Console.WriteLine("Utilisation de 'help' : help"); // Ecrire
                    break;
                case "ver":
                    Console.WriteLine("Utilisation de 'ver' : ver"); // Ecrire
                    break;
                case "update":
                    Console.WriteLine("Utilisation de 'update' : update"); // Ecrire
                    break;
                case "list":
                    Console.WriteLine("Utilisation de 'list' : list"); // Ecrire
                    break;
                case "exit":
                    Console.WriteLine("Utilisation de 'exit' : exit"); // Ecrire
                    break;
                case "about":
                    Console.WriteLine("Utilisation de 'about' : about"); // Ecrire
                    break;
                case "clear":
                    Console.WriteLine("Utilisation de 'clear' : clear"); // Ecrire
                    break;
                case "cls":
                    Console.WriteLine("Utilisation de 'cls' : cls"); // Ecrire
                    break;
                case "beep":
                    Console.WriteLine("Utilisation de 'beep' : beep"); // Ecrire
                    break;
                case "logo":
                    Console.WriteLine("Utilisation de 'logo' : logo"); // Ecrire
                    break;
                case "repo":
                    Console.WriteLine("Utilisation de 'repo' : repo"); // Ecrire
                    break;
                case "usage":
                    Console.WriteLine("Utilisation de 'usage' : usage"); // Ecrire
                    break;
            }
        }
    }
}
