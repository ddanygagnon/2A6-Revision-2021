﻿using System;

using RévisionLib;

namespace ConsoleFonctions
{
    internal class Program
    {
        private static void Main()
        {
            Console.Title = "*** Dany Gagnon ***";
            Console.WriteLine("Bonjour, je suis Dany Gagnon!");
            Console.WriteLine("Vive Git!");
            AfficherAdditionAléatoire();
            AfficherFizzBuzzAléatoire();
            AfficherSérie(début: 1, fin: 10);
            _ = Console.ReadKey();
        }

        private static void AfficherSérie(int début, int fin)
        {
            Console.WriteLine($"Série de {début} à {fin}: ");
            for (int i = début; i <= fin; i++)
            {
                Console.Write(i + ", ");
            }
            Console.WriteLine();
        }

        private static void AfficherAdditionAléatoire()
        {
            var random = new Random();
            int n1 = random.Next(100);
            int n2 = random.Next(100);

            Console.WriteLine(
                $"{n1} + {n2} = {Fonctions.Additionner(n1, n2)}");
        }
        private static void AfficherFizzBuzzAléatoire()
        {
            var random = new Random();
            int n1 = random.Next(100);

            Console.WriteLine(
                $"FizzBuzz de {n1} = \"{Fonctions.FizzBuzz(n1)}\"");

        }
    }
}
