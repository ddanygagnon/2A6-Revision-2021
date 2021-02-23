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
            string param = "AGENT 007 DG";
            Console.WriteLine(
                $"PremierChiffre( {param} ) = {param.PremierChiffre(out int indice),5} {indice,4}"
            );
            param = "AGENT XXX DG";
            Console.WriteLine(
                $"PremierChiffre( {param} ) = {param.PremierChiffre(out indice),5} {indice,4}"
            );
            Console.WriteLine();
            param = "AGENT 007 DG";
            int depart = -1;
            Console.WriteLine(
                $"PremierChiffre( {param}, {depart} ) = {param.PremierChiffre(out indice, depart),5} {indice,4}"
            );
            depart = 0;
            Console.WriteLine(
                $"PremierChiffre( {param}, {depart,2} ) = {param.PremierChiffre(out indice, depart),5} {indice,4}"
            );
            depart = 4;
            Console.WriteLine(
                $"PremierChiffre( {param}, {depart,2} ) = {param.PremierChiffre(out indice, depart),5} {indice,4}"
            );
            depart = 7;
            Console.WriteLine(
                $"PremierChiffre( {param}, {depart,2} ) = {param.PremierChiffre(out indice, depart),5} {depart,4}"
            );
            depart = 10;
            Console.WriteLine(
                $"PremierChiffre( {param}, {depart,2} ) = {param.PremierChiffre(out indice, depart),5} {indice,4}"
            );
            depart = 15;
            Console.WriteLine(
                $"PremierChiffre( {param}, {depart,2} ) = {param.PremierChiffre(out indice, depart),5} {indice,4}"
            );
            param = "1";
            Console.WriteLine(
                $"LocaliserNombre( {param} ) = {param.PremierChiffre(out indice, depart),5} {indice,4}"
            );
            Console.WriteLine("Appuyer sur une touche pour terminer...");
            Console.ReadKey();
        }
    }
}
