using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
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
            Console.WriteLine("clear : Efface la console"); // Ecrire
            Console.WriteLine("exit : Ferme la console"); // Ecrire
            Console.WriteLine("help : Affiche l'aide"); // Ecrire
            Console.WriteLine("update : Vérifie si des mises à jour sont disponibles"); // Ecrire
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

        public static bool IsUpdateAvailable()
        {
            bool res = false; // Résultat
            if (Definitions.Version == new WebClient().DownloadString(""))
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
