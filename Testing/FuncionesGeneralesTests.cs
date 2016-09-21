using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class FuncionesGeneralesTests
    {
        [TestMethod]
        public void TestHoraMexico()
        {
            var testDate = new DateTime(2016, 06, 16, 18, 0, 0, DateTimeKind.Utc);
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)");
            var expected = TimeZoneInfo.ConvertTimeFromUtc(testDate, timeZone);

            var actual = FuncionesVB.FuncionesGenerales.UtcToMexCentral(testDate);

            Assert.AreEqual(expected, actual);
        }
    }
}
