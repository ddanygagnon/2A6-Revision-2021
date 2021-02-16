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
    }
}
