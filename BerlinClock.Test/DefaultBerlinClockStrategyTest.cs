using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock.Test
{
    [TestClass]
    public class DefaultBerlinClockStrategyTest
    {
        [TestMethod]
        public void should_generetate_correct_outputs_for_correct_inputs()
        {
            DefaultBerlinClockStrategy target = new DefaultBerlinClockStrategy();

            var result1 = target.Calculate("00:00:00");
            var result2 = target.Calculate("13:17:01");
            var result3 = target.Calculate("23:59:59");
            var result4 = target.Calculate("04:01:02");

            Assert.AreEqual("Y OOOO OOOO OOOOOOOOOOO OOOO", result1);
            Assert.AreEqual("O RROO RRRO YYROOOOOOOO YYOO", result2);
            Assert.AreEqual("O RRRR RRRO YYRYYRYYRYY YYYY", result3);
            Assert.AreEqual("Y OOOO RRRR OOOOOOOOOOO YOOO", result4);
        }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(FormatException))]
        public void should_raise_exception_for_invalid_inputs()
        {
            DefaultBerlinClockStrategy target = new DefaultBerlinClockStrategy();
            target.Calculate("00:99:99");
        }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(FormatException))]
        public void should_raise_exception_for_null_input()
        {
            DefaultBerlinClockStrategy target = new DefaultBerlinClockStrategy();
            target.Calculate(null);
        }
    }
}
