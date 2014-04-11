using System;

namespace BerlinClock
{
    /// <summary>
    /// A class to abstract a berlin clock!
    /// </summary>
    public class BerlinClock
    {
        readonly IBerlinClockStrategy _strategy;

        /// <summary>
        /// Creates an instance of BerlinClock using the default strategy: <see cref="BerlinClock.DefaultBerlinClockStrategy"/>
        /// </summary>
        public BerlinClock()
            : this(new DefaultBerlinClockStrategy())
        {
        }

        public BerlinClock(IBerlinClockStrategy strategy)
        {
            _strategy = strategy;
        }

        /// <summary>
        /// Returns a string represeting the berling clock
        /// </summary>
        /// <param name="dateTime">A string represeting time: 'hh:mm:ss'</param>
        /// <returns>A string with format 'O OOOO OOOO OOOOOOOOOOO OOOO'</returns>
        /// <exception cref="System.FormatException">When an invalid string is passed as argument</exception>
        public string TellTime(string dateTime)
        {
            return _strategy.Calculate(dateTime);
        }
    }
}
