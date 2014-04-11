using System;
using System.Text;

namespace BerlinClock
{
    public class DefaultBerlinClockStrategy : IBerlinClockStrategy
    {
        #region IBerlinClockStrategy Members

        public string Calculate(DateTime time)
        {
            char firstSeries = BuildFirstSeries(time.Second);
            string secondSeries = BuildSecondSeries(time.Hour);
            string thirdSeries = BuildThirdSeries(time.Hour);
            string fourthSeries = BuildFourthSeries(time.Minute);
            string fifthSeries = BuildFifthSeries(time.Minute);

            return string.Format("{0} {1} {2} {3} {4}",
                firstSeries, secondSeries, thirdSeries, fourthSeries, fifthSeries);
        }

        #endregion

        static char BuildFirstSeries(int second)
        {
            return (second % 2) == 0 ? 'Y' : 'O';
        }

        static string BuildSecondSeries(int hour)
        {
            return BuildSeriesForHours(hour / 5);
        }

        static string BuildThirdSeries(int hour)
        {
            return BuildSeriesForHours(hour - (hour / 5) * 5);
        }

        static string BuildFourthSeries(int min)
        {
            int spaces = min / 5;

            var builder = new StringBuilder();

            for (int i = 0; i < 11; i++)
            {
                if (i < spaces)
                {
                    if (i == 2 || i == 5 || i == 8)
                    {
                        builder.Append('R');
                    }
                    else
                    {
                        builder.Append('Y');
                    }
                }
                else
                {
                    builder.Append('O');
                }
            }

            return builder.ToString();
        }

        static string BuildFifthSeries(int min)
        {
            int spaces = min - (min / 5) * 5;
            var builder = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                builder.Append(i < spaces ? 'Y' : 'O');
            }
            return builder.ToString();
        }

        static string BuildSeriesForHours(int spaces)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < 4; i++)
            {
                builder.Append(i < spaces ? 'R' : 'O');
            }

            return builder.ToString();
        }
    }
}
