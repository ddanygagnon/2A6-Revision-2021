using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using RévisionLib;

using static Tests.TestHelpers;

using Strings = RévisionLib.Strings;

namespace Tests
{
    public static class TestHelpers
    {
        static public void Implemented(Action action)
        {
            try { action(); }
            catch (NotImplementedException)
            { Assert.Inconclusive(); }
        }

        static public bool IsImplemented(Action action)
        {
            try { action(); return true; }
            catch (NotImplementedException)
            { return false; }
        }
    }

    [TestClass]
    public class TestsStrings
    {

        [TestMethod]
        [DataRow("", false, "", '\0', "")]
        [DataRow("12", false, "1", '\0', "2")]
        [DataRow("1234", false, "12", '\0', "34")]
        [DataRow("12345678", false, "1234", '\0', "5678")]
        [DataRow("1", true, "", '1', "")]
        [DataRow("123", true, "1", '2', "3")]
        [DataRow("12345", true, "12", '3', "45")]
        [DataRow("123456789", true, "1234", '5', "6789")]
        public void T2_Découper(string s,
            bool _estImpair, string _début, char _centre, string _fin)
            => Implemented(() =>
            {
                bool estImpair = Strings.Découper(s,
                    out string début, out char centre, out string fin);
                Assert.AreEqual(_estImpair, estImpair);
                Assert.AreEqual(_début, début);
                Assert.AreEqual(_centre, centre);
                Assert.AreEqual(_fin, fin);
            });


        [TestMethod]
        [DataRow("", false, -1)]
        [DataRow("      ", false, -1)]
        [DataRow("abcde *+&?()", false, -1)]
        [DataRow("1", true, 0)]
        [DataRow("1a", true, 0)]
        [DataRow(" 12 ", true, 1)]
        [DataRow("bonjour9 9", true, 7)]
        [DataRow("bonjour 123 45", true, 8)]
        [DataRow("bonjour 123 45", true, 8)]
        public void T3a_PremierChiffre(string s, bool _estPrésent, int _indice)
            => Implemented(() =>
            {
                bool estPrésent = s.PremierChiffre(out int indice);
                Assert.AreEqual(_estPrésent, estPrésent);
                Assert.AreEqual(_indice, indice);
            });

        [TestMethod]
        [DataRow("", false, -1, 0)]
        [DataRow("", false, -1, 1)]
        [DataRow("", false, -1, -1)]
        [DataRow("abcde *+&?()", false, -1, 0)]
        [DataRow("abcde *+&?()", false, -1, -20)]
        [DataRow("abcde *+&?()", false, -1, 20)]
        [DataRow("1", true, 0, 0)]
        [DataRow("1", false, -1, 1)]
        [DataRow("1", false, -1, -1)]
        [DataRow("1a", false, -1, 1)]
        [DataRow("1a", false, -1, 2)]
        [DataRow(" 12 ", true, 2, 2)]
        [DataRow(" 12 ", false, -1, 3)]
        [DataRow("bonjour9 9", true, 7, 4)]
        [DataRow("bonjour 123 45", true, 10, 10)]
        [DataRow("bonjour 123 45", true, 12, 11)]
        [DataRow("bonjour 123 45", false, -1, 14)]
        [DataRow("bonjour 123 45", false, -1, -1)]
        public void T3b_PremierChiffrePlus(string s, bool _estPrésent, int _indice, int indiceDépart)
            => Implemented(() =>
            {
                bool estPrésent = s.PremierChiffre(out int indice, indiceDépart);
                Assert.AreEqual(_estPrésent, estPrésent);
                Assert.AreEqual(_indice, indice);
            });

        [TestMethod]
        public void T3c_PremierChiffreDéfaut()
        {
            if (IsImplemented(() => "".PremierChiffre(out _))
                && IsImplemented(() => "".PremierChiffre(out _, 0)))
            {
                // On veut une seule méthode PremierChiffre, pas deux
                Assert.AreEqual(1, typeof(Strings).GetMethods().Count(m => m.Name == nameof(Strings.PremierChiffre)));
            }
            else
            {
                Assert.Inconclusive();
            }
        }



        [TestMethod]
        [DataRow("", false, -1, 0)]
        [DataRow("", false, -1, 1)]
        [DataRow("", false, -1, -1)]
        [DataRow("12345", false, -1, 0)]
        [DataRow("12345", false, -1, -20)]
        [DataRow("12345", false, -1, 20)]
        [DataRow("a", true, 0, 0)]
        [DataRow("a", false, -1, 1)]
        [DataRow("a", false, -1, -1)]
        [DataRow("a1", false, -1, 1)]
        [DataRow("a1", false, -1, 2)]
        [DataRow("12a", true, 2, 2)]
        [DataRow("12a", false, -1, 3)]
        [DataRow("1234567a8b", true, 7, 4)]
        [DataRow("1234567a8b", true, 9, 8)]
        [DataRow("1234567a8b", false, -1, -1)]
        [DataRow("1234567a8b", false, -1, 10)]
        public void T3d_PremierNonChiffre(string s, bool _estPrésent, int _indice, int indiceDépart)
            => Implemented(() =>
            {
                bool estPrésent = s.PremierNonChiffre(out int indice, indiceDépart);
                Assert.AreEqual(_estPrésent, estPrésent);
                Assert.AreEqual(_indice, indice);
            });


        [TestMethod]
        [DataRow("", false, -1, -1)]
        [DataRow("      ", false, -1, -1)]
        [DataRow("abcde *+&?()", false, -1, -1)]
        [DataRow("1a", true, 0, 1)]
        [DataRow("12", true, 0, 2)]
        [DataRow("123 bonjour", true, 0, 3)]
        [DataRow("bonjour9", true, 7, 8)]
        [DataRow("bonjour 12345", true, 8, 13)]
        [DataRow("a1b", true, 1, 2)]
        [DataRow("2021-01-18", true, 0, 4)]
        [DataRow("date 2021-01-18", true, 5, 9)]
        [DataRow("a1b2c3d", true, 1, 2)]
        public void T4a_LocaliserNombre(string s, bool _estPrésent, int _début, int _fin)
            => Implemented(() =>
            {
                bool estPrésent = s.LocaliserNombre(out int début, out int fin);
                Assert.AreEqual(_estPrésent, estPrésent);
                Assert.AreEqual(_début, début);
                Assert.AreEqual(_fin, fin);
            });

        [TestMethod]
        [DataRow("", 0, false, -1, -1)]
        [DataRow("", 1, false, -1, -1)]
        [DataRow("", -1, false, -1, -1)]
        [DataRow("", 10, false, -1, -1)]
        [DataRow("", -10, false, -1, -1)]
        [DataRow("      ", 1, false, -1, -1)]
        [DataRow("abcde *+&?()", 3, false, -1, -1)]
        [DataRow("12", 0, true, 0, 2)]
        [DataRow("12", 1, true, 1, 2)]
        [DataRow("12", 2, false, -1, -1)]
        [DataRow("1a", 0, true, 0, 1)]
        [DataRow("1a", 1, false, -1, -1)]
        [DataRow("1a", -1, false, -1, -1)]
        [DataRow("1a", 5, false, -1, -1)]
        [DataRow("123 bonjour", 1, true, 1, 3)]
        [DataRow("123 bonjour", 3, false, -1, -1)]
        [DataRow("bonjour9", 4, true, 7, 8)]
        [DataRow("bonjour 12345", 6, true, 8, 13)]
        [DataRow("bonjour 12345", 10, true, 10, 13)]
        [DataRow("a1b", 1, true, 1, 2)]
        [DataRow("2021-01-18", 2, true, 2, 4)]
        [DataRow("2021-01-18", 4, true, 5, 7)]
        [DataRow("2021-01-18", 7, true, 8, 10)]
        [DataRow("date 2021-01-18", 11, true, 11, 12)]
        [DataRow("a1b2c3d", 4, true, 5, 6)]
        public void T4b_LocaliserNombrePlus(string s, int démarrage, bool _estPrésent, int _début, int _fin)
            => Implemented(() =>
            {
                bool estPrésent = s.LocaliserNombre(out int début, out int fin, démarrage);
                Assert.AreEqual(_estPrésent, estPrésent);
                Assert.AreEqual(_début, début);
                Assert.AreEqual(_fin, fin);
            });

        [TestMethod]
        [DataRow("", 0, 0, false, 0)]
        [DataRow("", 1, 1, false, 0)]
        [DataRow("", -1, -1, false, 0)]
        [DataRow("abcde *+&?()", 3, 12, false, 0)]
        [DataRow("12", 0, 2, true, 12)]
        [DataRow("12", 1, 2, true, 2)]
        [DataRow("12", 2, 2, false, 0)]
        [DataRow("4a", 0, 1, true, 4)]
        [DataRow("1a", 1, 2, false, 0)]
        [DataRow("1a", 5, 5, false, 0)]
        [DataRow("123 bonjour", 1, 3, true, 23)]
        [DataRow("bonjour9", 4, 8, true, 9)]
        [DataRow("bonjour 12345", 6, 13, true, 12345)]
        [DataRow("bonjour 12345", 10, 13, true, 345)]
        [DataRow("2021-01-18", 2, 4, true, 21)]
        [DataRow("2021-01-18", 4, 7, true, 1)]
        [DataRow("2021-01-18", 7, 10, true, 18)]
        [DataRow("date 2021-01-18", 2, 9, true, 2021)]
        [DataRow("Big 1000000000000 one", 1, 4, false, 0)]
        public void T5a_ExtraireNombre(string s, int démarrage, int _démarrage, bool _estPrésent, int _nombre)
            => Implemented(() =>
            {
                bool estPrésent = s.ExtraireNombre(out int nombre, ref démarrage);
                Assert.AreEqual(_estPrésent, estPrésent);
                Assert.AreEqual(_nombre, nombre);
                Assert.AreEqual(_démarrage, démarrage);
            });

        [TestMethod]
        [DataRow("", true)]
        [DataRow("abcde *+&?()", true)]
        [DataRow("12", true, 12)]
        [DataRow("Machin 12 - 13 - 14 truc", true, 12, 13, 14)]
        [DataRow("Date 2001/09/11", true, 2001, 9, 11)]
        [DataRow("Big 1000000000000 one", false)]
        [DataRow("Big 10, 15, 20, 1000000000000, 30, 40 one", false, 10, 15, 20)]
        public void T5b_ExtraireNombres(string s, bool _ok, params int[] _nombres)
            => Implemented(() =>
            {
                var nombres = new List<int>();
                bool ok = s.ExtraireNombres(nombres);
                Assert.AreEqual(_ok, ok);
                CollectionAssert.AreEqual(_nombres, nombres);
            });
    }
}
