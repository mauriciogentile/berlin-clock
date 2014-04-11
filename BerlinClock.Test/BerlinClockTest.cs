using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BerlinClock.Test
{
    [TestClass]
    public class BerlinClockTest
    {
        [TestMethod]
        public void should_use_default_strategy_when_no_strategy_is_passed_in()
        {
            BerlinClock target = new BerlinClock();
            var result1 = target.TellTime("00:00:00");
            
            Assert.AreEqual("Y OOOO OOOO OOOOOOOOOOO OOOO", result1);
        }

        [TestMethod]
        public void should_use_specific_strategy_when_passed_by_argument()
        {
            var mockStrategy = new Mock<IBerlinClockStrategy>();
            mockStrategy.Setup(x => x.Calculate(It.IsAny<string>())).Returns("123456");

            BerlinClock target = new BerlinClock(mockStrategy.Object);
            var result1 = target.TellTime("00:00:00");
            
            Assert.AreEqual("123456", result1);
                        mockStrategy.Verify(x => x.Calculate("00:00:00"), Times.Once);
        }
    }
}
