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
using LABS.EC.CSharp.Classes;
using LeoCorpLibrary.Core;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LABS.EC.CSharp
{
	class Program
	{
		int result = 0; // Result
		int[] numbers = new int[10000]; // Nombres
		int counter = 0;
		static void Main(string[] args)
		{
			Console.Title = "LABS Experimental Console v" + Definitions.Version; // Mettre le titre
			Console.ForegroundColor = ConsoleColor.Blue; // Change color
			Console.WriteLine("LABS Experimental Console v{0}, running on .NET {1}", Definitions.Version, Environment.Version); // Write line
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
					case "help": // If command is "help"
						Functions.WriteHelp();
						GoHome();
						break;
					case "ver": // If command is "help"
						Console.ForegroundColor = ConsoleColor.Blue; // Change color
						Console.WriteLine("Version {0}, Copyright {1} - Léo Corporation", Definitions.Version, DateTime.Now.Year); // Write line
						GoHome();
						break;
					case "about": // If command is "help"
						Console.ForegroundColor = ConsoleColor.Blue; // Change color
						Console.WriteLine("LABS Experimental Console © {0} - Léo Corporation", DateTime.Now.Year); // Write line
						GoHome();
						break;
					case "cls":
						Console.Clear(); // Clear console
						GoHome();
						break;
					case "clear":
						Console.Clear(); // Clear console
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
							Console.WriteLine(""); // Write line
							Console.WriteLine("Updates are available, do you wanna install them?"); // Write line
							Console.WriteLine(" ___________         __________"); // Write line
							Console.WriteLine("|  Yes (y)  |       |  No (n)  |"); // Write line
							Console.WriteLine(" ¯¯¯¯¯¯¯¯¯¯¯         ¯¯¯¯¯¯¯¯¯¯"); // Write line
							Console.ForegroundColor = ConsoleColor.Blue; // Change color
							Console.Write(">>> "); // Write line
							Console.ResetColor(); // Set default color
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
							Console.WriteLine("No updates are available."); // Write line
							GoHome();
						}
						break;
					case "beep":
						if (Env.CurrentOperatingSystem == OperatingSystems.Windows)
						{
							Console.Beep(1500, 300); // Beep
							Console.WriteLine("Beep !"); // Write line
							System.Threading.Thread.Sleep(300);
							Console.Beep(1500, 300); // Beep
							Console.WriteLine("Beep !"); // Write line
							System.Threading.Thread.Sleep(100);
							Console.Beep(1500, 300); // Beep
							Console.WriteLine("Beep !"); // Write line 
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.Red; // Set color to red
							Console.WriteLine("The beep command is only available on Windows.");
							Console.ResetColor();
						}
						GoHome();
						break;
					case "logo":
						Console.ForegroundColor = ConsoleColor.Blue;
						Functions.PrintLogo();
						GoHome();
						break;
					case "repo":
						Functions.OpenBrowser("https://github.com/Leo-Corporation/LABS-ExperimentalConsole/"); // Ouvrir le dépôt
						Console.ForegroundColor = ConsoleColor.Blue; // Change color
						Console.WriteLine("The GitHub repo has been shown in your default browser."); // Write line
						GoHome();
						break;
					case "usage":
						Console.ForegroundColor = ConsoleColor.Blue; // Change color
						Console.WriteLine("+----+ Usage +----+"); // Write line
						Console.WriteLine(""); // Write line
						for (int i = 0; i < Definitions.Commands.Length; i++)
						{
							Functions.PrintUsage(Definitions.Commands[i]); // Print command usage
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
						Console.ForegroundColor = ConsoleColor.Blue; // Change color
						Console.Write(">>> "); // Write line
						Console.ResetColor(); // Set default color
						string file = Console.ReadLine();
						Console.WriteLine("Where do you wanna search the files? (ex: C:/Users/Name/Desktop");
						Console.ForegroundColor = ConsoleColor.Blue; // Change color
						Console.Write(">>> "); // Write line
						Console.ResetColor(); // Set default color
						string path = Console.ReadLine();
						Functions.SearchFiles(file, path);
						GoHome();
						break;
					case "test":
						int[] intarr = { 1, 2, 3, 4 };
						int it = 5;
						int[] newarr = intarr.Append(it);
						for (int i = 0; i < newarr.Length; i++)
						{
							Console.WriteLine(newarr[i]);
						}

						GoHome();
						break;
					case "dotnet":
						Console.WriteLine(".NET v" + Environment.Version.ToString());
						GoHome();
						break;

					case "leocorplibrary":
						Functions.TestLeoCorpLibrary();
						GoHome();
						break;
					case "passwords":
						Functions.MultiplePasswords();
						GoHome();
						break;
				}
			}
		}
		void Sum()
		{
			Console.WriteLine("Entrez un nombre"); // Write line
			Console.WriteLine(""); // Write line
			Console.ForegroundColor = ConsoleColor.Blue; // Change color
			Console.Write(">>> "); // Write line
			Console.ResetColor(); // Set default color
			int number = int.Parse(Console.ReadLine());
			numbers[counter] = number;
			counter++;
			Console.WriteLine("Voulez-vous ajouter un autre nombre ? (y/n)"); // Write line
			Console.WriteLine(""); // Write line
			Console.ForegroundColor = ConsoleColor.Blue; // Change color
			Console.Write(">>> "); // Write line
			Console.ResetColor(); // Set default color
			if (Console.ReadLine() == "y")
			{
				Sum();
			}
			else
			{
				GetResult(numbers); // Get result
				Console.WriteLine($"Result : {result}");
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
			Console.ForegroundColor = ConsoleColor.Yellow; // Change color
			Console.WriteLine(""); // Write line
			Console.WriteLine("To get started, type a command. Type 'help' to show help."); // Write line
			Console.ForegroundColor = ConsoleColor.Blue; // Change color
			Console.Write(">>> "); // Write line
			Console.ResetColor(); // Set default color
			ExecuteCommand(Console.ReadLine());
		}

		public void WriteWrongCommandMessage()
		{
			Console.ForegroundColor = ConsoleColor.Red; // Set foreground color to red
			Console.WriteLine("The command that you wrote doesn't exist. Type 'help' to get help."); // Show message
			BeepAsync(1000, 100, 2);
			Console.ResetColor(); // Set default color
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
			bool res = true; // Result
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
