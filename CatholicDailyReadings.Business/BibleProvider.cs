using CatholicDailyReadings.Models;
using CatholicDailyReadings.Models.Enums;
using CatholicDailyReadings.Utils;

namespace CatholicDailyReadings.Business
{
    public class BibleProvider
    {
        private readonly AdventCalculator _adventCalculator;
        private readonly CycleCalculator _cycleCalculator;
        private readonly MoonCalculator _moonCalculator;

        public BibleProvider()
        {
            _adventCalculator = new AdventCalculator();
            _cycleCalculator = new CycleCalculator();
            _moonCalculator = new MoonCalculator();
        }

        public DailyReading? GetDailyReading(DateTime date)
        {
            // Find year
            DateTime advent = _adventCalculator.Calculate(date.Year);
            Year year = _cycleCalculator.CalculateYear(date);
            Cycle cycle = _cycleCalculator.CalculateCycle(date);

            // If date falls on or after Advent, increment Year & Cycle
            if (date >= advent)
            {
                if (year == Year.A)
                    year = Year.B;
                else if (year == Year.B)
                    year = Year.C;
                else if (year == Year.C)
                    year = Year.A;

                if (cycle == Cycle.One)
                    cycle = Cycle.Two;
                else if (cycle == Cycle.Two)
                    cycle = Cycle.One;
            }

            DailyReading? dailyReading = null;

            // Return daily reading within Advent
            if (date >= advent && date < new DateTime(date.Year, 12, 25))
                dailyReading = GetAdventReading(advent, date, year);

            // Populate year and cycle onto the daily reading
            if (dailyReading != null)
            {
                dailyReading.Year = year;
                dailyReading.Cycle = cycle;
            }

            return dailyReading;
        }

        private DailyReading? GetAdventReading(DateTime advent, DateTime date, Year year)
        {
            TimeSpan difference = date.Subtract(advent);
            int dayDifference = (int)difference.TotalDays;

            // First week of Advent
            if (dayDifference < 7)
            {
                // Sunday
                if (dayDifference == 0)
                {
                    return year switch
                    {
                        Year.A => new DailyReading { FirstReading = "Is 2:1-5", SecondReading = "Rom 13:11-14", Gospel = "Mt 24:37-44" },
                        Year.B => new DailyReading { FirstReading = "Is 63:16b-17, 19b; 64:2-7", SecondReading = "1 Cor 1:3-9", Gospel = "Mk 13:33-37" },
                        Year.C => new DailyReading { FirstReading = "Jer 33:14-16", SecondReading = "1 Thes 3:12—4:2", Gospel = "Lk 21:25-28, 34-36" },
                        _ => null
                    };
                }

                return dayDifference switch
                {
                    // Monday
                    1 when year is Year.A => new DailyReading { FirstReading = "Is 4:2-6", Gospel = "Mt 8:5-11" },
                    1 => new DailyReading { FirstReading = "Is 2:1-5", Gospel = "Mt 8:5-11" },
                    // Tuesday
                    2 => new DailyReading { FirstReading = "Is 11:1-10", Gospel = "Lk 10:21-24" },
                    // Wednesday
                    3 => new DailyReading { FirstReading = "Is 25:6-10a", Gospel = "Mt 15:29-37" },
                    // Thursday
                    4 => new DailyReading { FirstReading = "Is 26:1-6", Gospel = "Mt 7:21, 24-27" },
                    // Friday
                    5 => new DailyReading { FirstReading = "Is 29:17-24", Gospel = "Mt 9:27-31" },
                    // Saturday
                    6 => new DailyReading { FirstReading = "Is 30:19-21, 23-26", Gospel = "Mt 9:35—10:1, 5a, 6-8" },
                    _ => null
                };
            }

            return null;
        }
    }
}
