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
            // Check feast days first

            // Immaculate Conception
            DateTime immaculateConception = new DateTime(date.Year, 12, 8);

            // If the Immaculate Conception falls on a Sunday, the readings
            // are said on the following day
            if ((immaculateConception.DayOfWeek == DayOfWeek.Sunday && date.Month == 12 && date.Day == 9) ||
                (date.DayOfWeek != DayOfWeek.Sunday && date.Month == 12 && date.Day == 8))
                return new DailyReading { FirstReading = "Gn 3:9-15, 20", SecondReading = "Eph 1:3-6, 11-12", Gospel = "Lk 1:26-38" };

            // Our Lady of Guadalupe
            if (date.Month == 12 && date.Day == 12)
                return new DailyReading { FirstReading = "Zec 2:14-17", Gospel = "Lk 1:39-47" };




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
            else if (dayDifference >= 7 && dayDifference < 14)
            {
                // Sunday
                if (dayDifference == 7)
                {
                    return year switch
                    {
                        Year.A => new DailyReading { FirstReading = "Is 11:1-10", SecondReading = "Rom 15:4-9", Gospel = "Mt 3:1-12" },
                        Year.B => new DailyReading { FirstReading = "Is 40:1-5, 9-11", SecondReading = "2 Pt 3:8-14", Gospel = "Mk 1:1-8" },
                        Year.C => new DailyReading { FirstReading = "Bar 5:1-9", SecondReading = "Phil 1:4-6, 8-11", Gospel = "Lk 3:1-6" },
                        _ => null
                    };
                }

                return dayDifference switch
                {
                    // Monday
                    8 => new DailyReading { FirstReading = "Is 35:1-10", Gospel = "Lk 5:17-26" },
                    // Tuesday
                    9 => new DailyReading { FirstReading = "Is 40:1-11", Gospel = "Mt 18:12-14" },
                    // Wednesday
                    10 => new DailyReading { FirstReading = "Is 40:25-31", Gospel = "Mt 11:28-30" },
                    // Thursday
                    11 => new DailyReading { FirstReading = "Is 41:13-20", Gospel = "Mt 11:11-15" },
                    // Friday
                    12 => new DailyReading { FirstReading = "Is 48:17-19", Gospel = "Mt 11:16-19" },
                    // Saturday
                    13 => new DailyReading { FirstReading = "Sir 48:1-4, 9-11", Gospel = "Mt 17:9a, 10-13" },
                    _ => null
                };
            }
            else if (dayDifference >= 14)
            {
                // Sunday
                if (dayDifference == 14)
                {
                    return year switch
                    {
                        Year.A => new DailyReading { FirstReading = "Is 35:1-6a, 10", SecondReading = "Jas 5:7-10", Gospel = "Mt 11:2-11" },
                        Year.B => new DailyReading { FirstReading = "Is 61:1-2a, 10-11", SecondReading = "1 Thes 5:16-24", Gospel = "Jn 1:6-8, 19-28" },
                        Year.C => new DailyReading { FirstReading = "Zep 3:14-18a", SecondReading = "Phil 4:4-7", Gospel = "Lk 3:10-18" },
                        _ => null
                    };
                }

                // If the day is December 17th or 18th or later, different Advent readings should be used
                DateTime cutOff = new DateTime(date.Year, 12, 17);

                if (date < cutOff)
                {
                    return dayDifference switch
                    {
                        // Monday
                        15 => new DailyReading { FirstReading = "Nm 24:2-7, 15-17a", Gospel = "Mt 21:23-27" },
                        // Tuesday
                        16 => new DailyReading { FirstReading = "Zep 3:1-2, 9-13", Gospel = "Mt 21:28-32" },
                        // Wednesday
                        17 => new DailyReading { FirstReading = "Is 45:6c-8, 18, 21c-25", Gospel = "Lk 7:18b-23" },
                        // Thursday
                        18 => new DailyReading { FirstReading = "Is 54:1-10", Gospel = "Lk 7:24-30" },
                        // Friday
                        19 => new DailyReading { FirstReading = "Is 56:1-3a, 6-8", Gospel = "Jn 5:33-36" },
                        _ => null
                    };
                }

                // Handle the 4th Sunday of Advent here, as it simplifies the logic a bit
                if (date.DayOfWeek == DayOfWeek.Sunday)
                {
                    return year switch
                    {
                        Year.A => new DailyReading { FirstReading = "Is 7:10-14", SecondReading = "Rom 1:1-7", Gospel = "Mt 1:18-24" },
                        Year.B => new DailyReading { FirstReading = "2 Sm 7:1-5, 8b-12, 14a, 16", SecondReading = "Rom 16:25-27", Gospel = "Lk 1:26-38" },
                        Year.C => new DailyReading { FirstReading = "Mi 5:1-4a", SecondReading = "Heb 10:5-10", Gospel = "Lk 1:39-45" },
                        _ => null
                    };
                }


                TimeSpan december17Difference = date.Subtract(cutOff);
                int december17DayDifference = (int)december17Difference.TotalDays;

                return december17DayDifference switch
                {
                    // December 17th
                    0 => new DailyReading { FirstReading = "Gn 49:2, 8-10", Gospel = "Mt 1:1-17" },
                    // 18th
                    1 => new DailyReading { FirstReading = "Jer 23:5-8", Gospel = "Mt 1:18-24" },
                    // 19th
                    2 => new DailyReading { FirstReading = "Jgs 13:2-7, 24-25a", Gospel = "Lk 1:5-25" },
                    // 20th
                    3 => new DailyReading { FirstReading = "Is 7:10-14", Gospel = "Lk 1:26-38" },
                    // 21st
                    4 => new DailyReading { FirstReading = "Zep 3:14-18a", Gospel = "Lk 1:39-45" },
                    // 22nd
                    5 => new DailyReading { FirstReading = "1 Sm 1:24-28", Gospel = "Lk 1:46-56" },
                    // 23rd
                    6 => new DailyReading { FirstReading = "Mal 3:1-4, 23-24", Gospel = "Lk 1:57-66" },
                    // 24th
                    7 => new DailyReading { FirstReading = "2 Sm 7:1-5, 8b-12, 14a, 16", Gospel = "Lk 1:67-79" },
                    _ => null
                };
            }

            return null;
        }
    }
}
