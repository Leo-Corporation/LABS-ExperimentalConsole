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
using LeoCorpLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LABS.EC.CSharp.Classes
{
	public static class Functions
	{
		public static void WriteHelp()
		{
			Console.ForegroundColor = ConsoleColor.Blue; // Change color
			Console.WriteLine("+----+ Help +----+"); // Write line
			Console.ResetColor(); // Set default color
			Console.WriteLine("Here's all the available commands:"); // Write line
			Console.WriteLine(""); // Write line
			Console.WriteLine("about : Shows credits"); // Write line
			Console.WriteLine("beep : Beep"); // Write line
			Console.WriteLine("clear, cls : Clears the console"); // Write line
			Console.WriteLine("exit : Closes the console"); // Write line
			Console.WriteLine("help : Dhows help"); // Write line
			Console.WriteLine("list : Shows commands"); // Write line
			Console.WriteLine("logo : Show le logo"); // Write line
			Console.WriteLine("repo : Opens the GitHub repo"); // Write line
			Console.WriteLine("update : Checks updates"); // Write line
			Console.WriteLine("usage : Shows how to use commands"); // Write line
			Console.WriteLine("ver : Shows the version"); // Write line
			Console.WriteLine("searchfile : Search throught files"); // Write line
			Console.WriteLine("test : A test command that can be changed"); // Write line
			Console.WriteLine("dotnet : Allows you to get the .NET version"); // Write line
			Console.WriteLine("leocorplibrary : Tests about LeoCorpLibrary.Core"); // Write line
			Console.WriteLine("passwords : Allows you to generate multiple passwords"); // Write line
			Console.WriteLine("ipconfig : Allows you to get the IP config of this machine"); // Write line
		}

		public static void WriteCommands()
		{
			Console.ForegroundColor = ConsoleColor.Blue; // Change color
			Console.WriteLine("+----+ Commands +----+"); // Write line
			Console.ResetColor(); // Set default color
			Console.WriteLine("Here's the list of all the commands"); // Write line
			Console.WriteLine(""); // Write line
			for (int i = 0; i < Definitions.Commands.Length; i++)
			{
				Console.WriteLine(Definitions.Commands[i]); // Write line
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
					Console.ForegroundColor = ConsoleColor.Blue; // Change color
					Console.Write("> "); // Write line
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					Console.WriteLine(file);
					Console.ResetColor(); // Set default color
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
				Console.WriteLine($"{i + 1}. {passwords[i]}"); // Print message
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
					Console.WriteLine("Usage of 'help' : help"); // Write line
					break;
				case "ver":
					Console.WriteLine("Usage of 'ver' : ver"); // Write line
					break;
				case "update":
					Console.WriteLine("Usage of 'update' : update"); // Write line
					break;
				case "list":
					Console.WriteLine("Usage of 'list' : list"); // Write line
					break;
				case "exit":
					Console.WriteLine("Usage of 'exit' : exit"); // Write line
					break;
				case "about":
					Console.WriteLine("Usage of 'about' : about"); // Write line
					break;
				case "clear":
					Console.WriteLine("Usage of 'clear' : clear"); // Write line
					break;
				case "cls":
					Console.WriteLine("Usage of 'cls' : cls"); // Write line
					break;
				case "beep":
					Console.WriteLine("Usage of 'beep' : beep"); // Write line
					break;
				case "logo":
					Console.WriteLine("Usage of 'logo' : logo"); // Write line
					break;
				case "repo":
					Console.WriteLine("Usage of 'repo' : repo"); // Write line
					break;
				case "usage":
					Console.WriteLine("Usage of 'usage' : usage"); // Write line
					break;
				case "sum":
					Console.WriteLine("Usage of 'sum' : sum"); // Write line
					break;
				case "searchfile":
					Console.WriteLine("Usage of 'searchfile' : searchfile"); // Write line
					break;
				case "test":
					Console.WriteLine("Usage of 'test' : test");
					break;
				case "dotnet":
					Console.WriteLine("Usage of 'dotnet' : dotnet");
					break;
				case "ipconfig":
					Console.WriteLine("Usage of 'ipconfig' : ipconfig");
					break;
			}
		}
		
		public static void IPConfig()
		{
			try
			{
				var interfaces = NetworkInterface.GetAllNetworkInterfaces();
				for (int i = 0; i < interfaces.Length; i++)
				{
					Console.WriteLine($"\n{i + 1}. {interfaces[i].Name}");
					Console.WriteLine($"Status............ {interfaces[i].OperationalStatus}");
					Console.WriteLine($"DNS Suffix........ {interfaces[i].GetIPProperties().DnsSuffix}");
					Console.WriteLine($"IPv6 Address...... {interfaces[i].GetIPProperties().UnicastAddresses.Where(x => x.Address.AddressFamily == AddressFamily.InterNetworkV6).FirstOrDefault()?.Address}");
					Console.WriteLine($"IPv4 Address...... {interfaces[i].GetIPProperties().UnicastAddresses.Where(x => x.Address.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault()?.Address}");
					Console.WriteLine($"IPv6 Gateway...... {interfaces[i].GetIPProperties().GatewayAddresses.Where(x => x.Address.AddressFamily == AddressFamily.InterNetworkV6).FirstOrDefault()?.Address}");
					Console.WriteLine($"IPv4 Gateway...... {interfaces[i].GetIPProperties().GatewayAddresses.Where(x => x.Address.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault()?.Address}");
					Console.WriteLine($"IPv4 Network Mask. {interfaces[i].GetIPProperties().UnicastAddresses.Where(x => x.Address.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault()?.IPv4Mask}");
				}
			}
			catch
			{
				
			}
		}
	}
}
