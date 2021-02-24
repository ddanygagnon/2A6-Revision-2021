using System;
using System.Collections.Generic;

using RévisionLib;

using static System.Console;


namespace ConsoleStrings
{
    public static class Program
    {
        private const string nom = "Dany Gagnon";
        private const string initiales = "DG";

        private static void Main()
        {
            Title = $"{nameof(ConsoleStrings)} - {nom}";

            DémoDécouper();
            DémoPremierChiffre();
            DémoLocaliserNombre();
            DémoExtraireNombres();

            WriteLine("Appuyer sur une touche pour terminer...");

            _ = ReadKey();
        }

        private static void DémoExtraireNombres()
        {
            WriteLine();
            var tester = new[]
            {
                "",
                "1",
                "Biden",
                "123 Go!",
                "Wayne 99",
                "Agent 007 DG",
                "Big 10000000000000"
            };
            foreach (string nbTest in tester)
            {
                int indice = 0;
                bool resultat = nbTest.ExtraireNombre(out int nb, ref indice);
                WriteLine(
                    $"ExtraireNombre( {nbTest,20} ) = {resultat,5} {indice,3}{($"{"",2}=> {nb}")}"
                );
            }

            string test = "DG: 10, 20, 30, 40, 50, 60";
            var nbs = new List<int>();
            Write($"\nExtraireNombres({test}) = \n{test.ExtraireNombres(nbs)} => ");
            int idx = 0;
            foreach (int nb in nbs)
            {
                idx++;
                Write(nb);
                Write(idx < nbs.Count ? ", " : "\n");
            }

            test = "DG: 10, 20, 300000000000, 40";
            nbs = new List<int>();
            Write($"\nExtraireNombres({test}) = \n{test.ExtraireNombres(nbs)} => ");
            idx = 0;
            foreach (int nb in nbs)
            {
                idx++;
                Write(nb);
                Write(idx < nbs.Count ? ", " : "\n");
            }
        }

        private static void DémoPremierChiffre()
        {
            WriteLine();
            const string param = "AGENT 007 DG";
            WriteLine(
                $"PremierChiffre( {param} ) = {param.PremierChiffre(out int indice),5} {indice,4}"
            );
            const string paramXxx = "AGENT XXX DG";
            WriteLine(
                $"PremierChiffre( {paramXxx} ) = {paramXxx.PremierChiffre(out indice),5} {indice,4}"
            );
            WriteLine();
            var aTest = new[] { -1, 0, 4, 7, 10, 15 };
            foreach (int test in aTest)
            {
                WriteLine(
                    $"PremierChiffre( {param}, {test,2} ) = {param.PremierChiffre(out indice, test),5} {indice,4}"
                );
            }
        }

        private static void DémoDécouper()
        {
            string alphabet = "";
            string début;
            char centre;
            string fin;
            for (int i = 'A'; i <= 'E'; i++)
            {
                alphabet += (char)i;
                WriteLine(
                    $"Découper({alphabet,20}) = {Strings.Découper(alphabet, out début, out centre, out fin),5} {début,10}  {(centre == '\0' ? ' ' : centre)}  {fin}"
                );
            }

            int aleatoire = new Random().Next(6, 20);

            for (int i = 0; i < 2; i++)
            {
                string fill = "".PadRight(aleatoire + i, '+');
                WriteLine(
                    $"Découper({fill,20}) = {Strings.Découper(fill, out début, out centre, out fin),5} {début,10}  {(centre == '\0' ? ' ' : centre)}  {fin}"
                );
            }

            string nomPoint = nom.Replace(' ', '.');
            WriteLine(
                $"Découper({nomPoint,20}) = {Strings.Découper(nomPoint, out début, out centre, out fin),5} {début,10}  {(centre == '\0' ? ' ' : centre)}  {fin}"
            );
            WriteLine(
                $"Découper({nomPoint + '!',20}) = {Strings.Découper(nomPoint + '!', out début, out centre, out fin),5} {début,10}  {(centre == '\0' ? ' ' : centre)}  {fin}"
            );
        }

        private static void DémoLocaliserNombre()
        {
            WriteLine();
            var tester = new[] {
                "",
                "1",
                "Biden",
                "123 Go!",
                "Wayne 99",
                "Agent 007 DG"
            };
            foreach (string nbTest in tester)
            {
                bool resultat = nbTest.LocaliserNombre(out int debut, out int fin);
                WriteLine(
                    $"LocaliserNombre( {nbTest,13} ) = {resultat,5} {debut,3} {fin,3}{(resultat ? $"{"",2}=> {nbTest[debut..fin]}" : "")}"
                );
            }
            WriteLine();
            string msg = "Agents 007, 008 et 00DG au rapport!";
            WriteLine($"Message: {msg}\n");
            var àTester = new[] { -1, 4, 8, 10, 13, 15, 25, 40 };
            var listeNbs = new List<string>();
            foreach (int nbTest in àTester)
            {
                bool resultat = msg.LocaliserNombre(out int debut, out int fin, nbTest);
                if (resultat)
                {
                    listeNbs.Add(msg[debut..fin]);
                }

                WriteLine(
                    $"LocaliserNombre( {nbTest,2} ) = {resultat,5} {debut,3} {fin,3}{(resultat ? $"{"",2}=> {msg[debut..fin]}" : "")}"
                );


            }

            WriteLine();
            Write("Les nombres sont: ");
            int indDepart = 0;
            while (msg.LocaliserNombre(out int deb, out int f, indDepart))
            {
                Write($"{msg[deb..f]} ");
                indDepart = f;
            }
            WriteLine();
        }
    }
}
