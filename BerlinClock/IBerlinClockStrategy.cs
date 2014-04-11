using System;

namespace BerlinClock
{
    public interface IBerlinClockStrategy
    {
        string Calculate(DateTime time);
    }
}
