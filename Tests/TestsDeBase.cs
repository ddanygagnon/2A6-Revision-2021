using Microsoft.VisualStudio.TestTools.UnitTesting;

using RévisionLib;

namespace Tests
{
    [TestClass]
    public class TestsDeBase
    {
        [TestMethod]
        public void T1_Additionner()
        {
            Assert.AreEqual(17, Fonctions.Additionner(7, 10));
            Assert.AreEqual(90, Fonctions.Additionner(100, -10));
            Assert.AreEqual(-90, Fonctions.Additionner(-100, 10));
            Assert.AreEqual(-110, Fonctions.Additionner(-100, -10));
            Assert.AreEqual(100, Fonctions.Additionner(100, 0));
            Assert.AreEqual(0, Fonctions.Additionner(0, 0));
        }
        [TestMethod]
        [DataRow(17, 7, 10)]
        [DataRow(90, 100, -10)]
        [DataRow(-90, -100, 10)]
        [DataRow(-110, -100, -10)]
        [DataRow(100, 100, 0)]
        [DataRow(0, 0, 0)]
        public void T2_Additionner_DG(int somme, int n1, int n2)
        {
            Assert.AreEqual(somme, Fonctions.Additionner(n1, n2));
        }

        [TestMethod]
        [DataRow(3, "Fizz")]
        [DataRow(333, "Fizz")]
        [DataRow(777, "Fizz")]
        [DataRow(5, "Buzz")]
        [DataRow(100, "Buzz")]
        [DataRow(15, "Fizz Buzz")]
        [DataRow(225, "Fizz Buzz")]
        [DataRow(555, "Fizz Buzz")]
        [DataRow(0, "Fizz Buzz")]
        [DataRow(1, "")]
        [DataRow(2, "")]
        [DataRow(7, "")]
        [DataRow(77, "")]
        [DataRow(10201, "")]
        public void T3_FizzBuzz_DG(int nombre, string résultat)
        {
            Assert.AreEqual(résultat, Fonctions.FizzBuzz(nombre));
        }
    }
}
