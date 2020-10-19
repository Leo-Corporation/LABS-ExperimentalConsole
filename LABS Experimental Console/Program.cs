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
using LABS_Experimental_Console.Classes;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LABS_Experimental_Console
{
    class Program
    {
        int result = 0; // Résultat
        int[] numbers = new int[10000]; // Nombres
        int counter = 0;
        static void Main(string[] args)
        {
            Console.Title = "LABS Experimental Console v" + Definitions.Version; // Mettre le titre
            Console.ForegroundColor = ConsoleColor.Blue; // Changer la couleur
            Console.WriteLine("LABS Experimental Console v{0}", Definitions.Version); // Ecrire
            new Program().GoHome();
        }

        public void ExecuteCommand(string command)
        {
            if (!IsCommandExist(command))
            {
                WriteWrongCommandMessage();
            }
            else
            {
                switch (command.ToLower())
                {
                    case "help": // Si la commande est "help"
                        Functions.WriteHelp();
                        GoHome();
                        break;
                    case "ver": // Si la commande est "help"
                        Console.ForegroundColor = ConsoleColor.Blue; // Changer la couleur
                        Console.WriteLine("Version {0}, Copyright {1} - Léo Corporation", Definitions.Version, DateTime.Now.Year); // Ecrire
                        GoHome();
                        break;
                    case "about": // Si la commande est "help"
                        Console.ForegroundColor = ConsoleColor.Blue; // Changer la couleur
                        Console.WriteLine("LABS Experimental Console © {0} - Léo Corporation", DateTime.Now.Year); // Ecrire
                        GoHome();
                        break;
                    case "cls":
                        Console.Clear(); // Effacer
                        GoHome();
                        break;
                    case "clear":
                        Console.Clear(); // Effacer
                        GoHome();
                        break;
                    case "list":
                        Functions.WriteCommands();
                        GoHome();
                        break;
                    case "update":
                        if (Functions.IsUpdateAvailable())
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(""); // Ecrire
                            Console.WriteLine("Updates are avialable, do you wanna install them?"); // Ecrire
                            Console.WriteLine(" ___________         __________"); // Ecrire
                            Console.WriteLine("|  Yes (y)  |       |  No (n)  |"); // Ecrire
                            Console.WriteLine(" ¯¯¯¯¯¯¯¯¯¯¯         ¯¯¯¯¯¯¯¯¯¯"); // Ecrire
                            Console.ForegroundColor = ConsoleColor.Blue; // Changer la couleur
                            Console.Write(">>> "); // Ecrire
                            Console.ResetColor(); // Mettre la couleur par défaut
                            if (Console.ReadLine() == "y")
                            {
                                Functions.OpenBrowser("https://github.com/Leo-Corporation/LABS-ExperimentalConsole/releases"); // Ouvrir la page web
                                GoHome();
                            }
                            else
                            {
                                GoHome();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("No updates are available."); // Ecrire
                            GoHome();
                        }
                        break;
                    case "beep":
                        Console.Beep(1500, 300); // Beep
                        Console.WriteLine("Beep !"); // Ecrire
                        System.Threading.Thread.Sleep(300);
                        Console.Beep(1500, 300); // Beep
                        Console.WriteLine("Beep !"); // Ecrire
                        System.Threading.Thread.Sleep(100);
                        Console.Beep(1500, 300); // Beep
                        Console.WriteLine("Beep !"); // Ecrire
                        GoHome();
                        break;
                    case "logo":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Functions.PrintLogo();
                        GoHome();
                        break;
                    case "repo":
                        Functions.OpenBrowser("https://github.com/Leo-Corporation/LABS-ExperimentalConsole/"); // Ouvrir le dépôt
                        Console.ForegroundColor = ConsoleColor.Blue; // Changer la couleur
                        Console.WriteLine("The GitHub repo has been shown in your default browser."); // Ecrire
                        GoHome();
                        break;
                    case "usage":
                        Console.ForegroundColor = ConsoleColor.Blue; // Changer la couleur
                        Console.WriteLine("+----+ Usage +----+"); // Ecrire
                        Console.WriteLine(""); // Ecrire
                        for (int i = 0; i < Definitions.Commands.Length; i++)
                        {
                            Functions.PrintUsage(Definitions.Commands[i]); // Imprimer l'utilisation des commandes
                        }
                        
                        GoHome();
                        break;
                    case "sum":
                        result = 0;
                        counter = 0;
                        numbers = new int[10000];
                        Sum();
                        break;
                    case "searchfile":
                        Console.WriteLine("Wich file(s) do you wanna search? (ex: file.png)");
                        Console.ForegroundColor = ConsoleColor.Blue; // Changer la couleur
                        Console.Write(">>> "); // Ecrire
                        Console.ResetColor(); // Mettre la couleur par défaut
                        string file = Console.ReadLine();
                        Console.WriteLine("Where do you wanna search the files? (ex: C:/Users/Name/Desktop");
                        Console.ForegroundColor = ConsoleColor.Blue; // Changer la couleur
                        Console.Write(">>> "); // Ecrire
                        Console.ResetColor(); // Mettre la couleur par défaut
                        string path = Console.ReadLine();
                        Functions.SearchFiles(file, path);
                        GoHome();
                        break;
                }
            }
        }
        void Sum()
        {
            Console.WriteLine("Entrez un nombre"); // Ecrire
            Console.WriteLine(""); // Ecrire
            Console.ForegroundColor = ConsoleColor.Blue; // Changer la couleur
            Console.Write(">>> "); // Ecrire
            Console.ResetColor(); // Mettre la couleur par défaut
            int number = int.Parse(Console.ReadLine());
            numbers[counter] = number;
            counter++;
            Console.WriteLine("Voulez-vous ajouter un autre nombre ? (y/n)"); // Ecrire
            Console.WriteLine(""); // Ecrire
            Console.ForegroundColor = ConsoleColor.Blue; // Changer la couleur
            Console.Write(">>> "); // Ecrire
            Console.ResetColor(); // Mettre la couleur par défaut
            if (Console.ReadLine() == "y")
            {
                Sum();
            }
            else
            {
                GetResult(numbers); // Obtenir le résultat
                Console.WriteLine($"Résultat : {result}");
                GoHome();
            }
        }

        void GetResult(int[] numbers)
        {
            foreach (int number in numbers)
            {
                result += number;
            }
        }

        public void GoHome()
        {
            Console.ForegroundColor = ConsoleColor.Yellow; // Changer la couleur
            Console.WriteLine(""); // Ecrire
            Console.WriteLine("Pour commencer, tapez une commande. Tapez 'help' pour afficher l'aide."); // Ecrire
            Console.ForegroundColor = ConsoleColor.Blue; // Changer la couleur
            Console.Write(">>> "); // Ecrire
            Console.ResetColor(); // Mettre la couleur par défaut
            ExecuteCommand(Console.ReadLine());
        }

        public void WriteWrongCommandMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red; // Mettre en rouge
            Console.WriteLine("La commande que vous avez executée n'existe pas."); // Afficher le message
            BeepAsync(1000, 100, 2);
            Console.ResetColor(); // Mettre la couleur par défaut
            GoHome();
        }

        public void BeepAsync(int frequency, int duration, int repeat)
        {
            Task.Run(() =>
            {
                for (int i = 0; i < repeat; i++)
                {
                    Console.Beep(frequency, duration); // Beep
                }
            });
        }

        public bool IsCommandExist(string command)
        {
            bool res = true; // Résultat
            if (Definitions.Commands.Contains(command.ToLower()))
            {
                res = true;
            }
            else
            {
                res = false;
            }
            return res;
        }
    }
}
