using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using RévisionLib;


namespace ConsoleStrings
{
    public static class Program
    {
        private const string nom = "Dany Gagnon";
        private const string initiales = "DG";
        private static void Main()
        {
            Console.Title = $"{nameof(ConsoleStrings)} - {nom}";
            string alphabet = "";
            string début, fin = "";
            char centre = '\0';
            for (int i = 'A'; i <= 'E'; i++)
            {
                alphabet += (char)i;
                Console.WriteLine(
                    $"Découper({alphabet,20}) = {Strings.Découper(alphabet, out début, out centre, out fin),5} {début,10}  {(centre == '\0' ? ' ' : centre)}  {fin}"
                );
            }
            int aleatoire = new Random().Next(6, 20);

            for (int i = 0; i < 2; i++)
            {
                string fill = "".PadRight(aleatoire + i, '+');
                Console.WriteLine(
                    $"Découper({fill,20}) = {Strings.Découper(fill, out début, out centre, out fin),5} {début,10}  {(centre == '\0' ? ' ' : centre)}  {fin}"
                );
            }

            string nomPoint = nom.Replace(' ', '.');
            Console.WriteLine(
                $"Découper({nomPoint,20}) = {Strings.Découper(nomPoint, out début, out centre, out fin),5} {début,10}  {(centre == '\0' ? ' ' : centre)}  {fin}"
            );
            Console.WriteLine(
                $"Découper({nomPoint + '!',20}) = {Strings.Découper(nomPoint + '!', out début, out centre, out fin),5} {début,10}  {(centre == '\0' ? ' ' : centre)}  {fin}"
            );
            Console.WriteLine();
            Console.WriteLine("Appuyer sur une touche pour terminer...");
            Console.ReadKey();
        }
    }
}
