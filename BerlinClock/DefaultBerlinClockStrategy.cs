using System;
using System.Text;

namespace BerlinClock
{
    public class DefaultBerlinClockStrategy : IBerlinClockStrategy
    {
        #region IBerlinClockStrategy Members

        public string Calculate(string dateTime)
        {
            DateTime time = Convert.ToDateTime(dateTime ?? string.Empty);

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
            //e.g. 22/5=4; 11/5=2
            return BuildSeriesForHours(hour / 5);
        }

        static string BuildThirdSeries(int hour)
        {
            //e.g 22-(22/5)*5=6; 13-(13/5)*5=3
            return BuildSeriesForHours(hour - (hour / 5) * 5);
        }

        static string BuildFourthSeries(int min)
        {
            int spots = min / 5;
            var builder = new StringBuilder();

            for (int i = 0; i < 11; i++)
            {
                if (i < spots)
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
            int spots = min - (min / 5) * 5;
            var builder = new StringBuilder();

            for (int i = 0; i < 4; i++)
            {
                builder.Append(i < spots ? 'Y' : 'O');
            }

            return builder.ToString();
        }

        static string BuildSeriesForHours(int spots)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < 4; i++)
            {
                builder.Append(i < spots ? 'R' : 'O');
            }

            return builder.ToString();
        }
    }
}
