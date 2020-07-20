using LABS_Experimental_Console.Classes;
using System;

namespace LABS_Experimental_Console
{
    class Program
    {
        static void Main(string[] args)
        {
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
                }
            }
        }

        public void GoHome()
        {
            Console.ResetColor(); // Metttre la couleur par défaut
            Console.WriteLine(""); // Ecrire
            Console.WriteLine("Pour commencer, tapez une commande. Tapez 'help' pour afficher l'aide."); // Ecrire
            ExecuteCommand(Console.ReadLine());
        }

        public void WriteWrongCommandMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red; // Mettre en rouge
            Console.WriteLine("La commande que vous avez executée n'existe pas."); // Afficher le message
            Console.ResetColor(); // Mettre la couleur par défaut
        }

        public bool IsCommandExist(string command)
        {
            bool res = false; // Résultat
            foreach (string com in Definitions.Commands)
            {
                if (com == command) // Si la commande existe
                {
                    res = true;
                }
                else // Si la commande n'existe pas
                {
                    res = false;
                }
            }
            return res;
        }
    }
}
