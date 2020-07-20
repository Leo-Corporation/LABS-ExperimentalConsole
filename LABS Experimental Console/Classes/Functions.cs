using System;
using System.Collections.Generic;
using System.Text;

namespace LABS_Experimental_Console.Classes
{
    public static class Functions
    {
        public static void WriteHelp()
        {
            Console.ForegroundColor = ConsoleColor.Magenta; // Changer la couleur
            Console.WriteLine("*----* Aide *----*"); // Ecrire
            Console.ResetColor(); // Mettre la couleur par défaut
            Console.WriteLine("Voici les diverses commandes disponibles :"); // Ecrire
            Console.WriteLine(""); // Ecrire
            Console.WriteLine("about : Affiche les crédits"); // Ecrire
            Console.WriteLine("cl, clear : Efface la console"); // Ecrire
            Console.WriteLine("exit : Ferme la console"); // Ecrire
            Console.WriteLine("help : Affiche l'aide"); // Ecrire
            Console.WriteLine("update : Vérifie si des mises à jour sont disponibles"); // Ecrire
            Console.WriteLine("ver : Affiche la version"); // Ecrire
        }
    }
}
