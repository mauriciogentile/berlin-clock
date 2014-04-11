using System;

namespace BerlinClock
{
    public class BerlinClock
    {
        readonly IBerlinClockStrategy _strategy;

        public BerlinClock()
            : this(new DefaultBerlinClockStrategy())
        {
        }

        public BerlinClock(IBerlinClockStrategy strategy)
        {
            _strategy = strategy;
        }

        public string TellTime()
        {
            return TellTime(null);
        }

        public string TellTime(string dateTime)
        {
            DateTime time = dateTime != null ? Convert.ToDateTime(dateTime) : DateTime.Now;
            return TellTime(time);
        }

        public string TellTime(DateTime dateTime)
        {
            return _strategy.Calculate(dateTime);
        }
    }
}
