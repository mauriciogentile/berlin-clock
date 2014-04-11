using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock.Test
{
    [TestClass]
    public class BerlinClockSpecTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            BerlinClock target = new BerlinClock();

            var result1 = target.TellTime("00:00:00");
            var result2 = target.TellTime("13:17:01");
            var result3 = target.TellTime("23:59:59");
            var result4 = target.TellTime("24:00:00");

            Assert.AreEqual("Y OOOO OOOO OOOOOOOOOOO OOOO", result1);
            Assert.AreEqual("O RROO RRRO YYROOOOOOOO YYOO", result2);
            Assert.AreEqual("O RRRR RRRO YYRYYRYYRYY YYYY", result3);
            Assert.AreEqual("Y RRRR RRRR OOOOOOOOOOO OOOO", result4);
        }
    }
}
