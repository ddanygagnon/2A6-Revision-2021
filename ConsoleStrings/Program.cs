using System;

namespace ConsoleStrings
{
    public static class Program
    {
        private const string nom = "Dany Gagnon";
        private const string initiales = "DG";
        private static void Main()
        {
            Console.Title = $"{nameof(ConsoleStrings)} - {nom}";
            Console.WriteLine("Appuyer sur une touche pour terminer...");
            Console.ReadKey();

        }
    }
}
