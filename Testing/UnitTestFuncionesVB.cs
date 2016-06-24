using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class UnitTestFuncionesVB
    {
        [TestMethod]
        public void TestMethod1()
        {
            string Hello = "Hello world";
            Assert.AreEqual("Hello world", Hello);
        }

        [TestMethod]
        public void TestHoraMexico()
        {
            DateTime HoraMexico = FuncionesVB.FuncionesGenerales.Takoma_UTCToMexCentral();
            Assert.AreNotEqual("16-06-2016", HoraMexico.AddDays(-1).ToString(), "24 horas Menos");
        }

        
    }
}
