using CatholicDailyReadings.Models;
using CatholicDailyReadings.Models.Enums;
using CatholicDailyReadings.Utils;

namespace CatholicDailyReadings.Business
{
    public class BibleProvider
    {
        private readonly AdventCalculator _adventCalculator;
        private readonly ChristmasCalculator _christmasCalculator;
        private readonly CycleCalculator _cycleCalculator;
        private readonly MoonCalculator _moonCalculator;

        public BibleProvider()
        {
            _adventCalculator = new AdventCalculator();
            _christmasCalculator = new ChristmasCalculator();
            _cycleCalculator = new CycleCalculator();
            _moonCalculator = new MoonCalculator();
        }

        public DailyReading? GetDailyReading(DateTime date)
        {
            // Find year
            DateTime advent = _adventCalculator.Calculate(date.Year);
            Year year = _cycleCalculator.CalculateYear(date);
            Cycle cycle = _cycleCalculator.CalculateCycle(date);

            DateTime christmas = new DateTime(date.Year, 12, 25);
            DateTime baptismOfTheLord = _christmasCalculator.CalculateBaptismOfTheLord(date.Year);
            DateTime ashWednesday = _moonCalculator.GetLent(date.Year);
            DateTime easter = _moonCalculator.GetEaster(date.Year);

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

                baptismOfTheLord = _christmasCalculator.CalculateBaptismOfTheLord(date.Year + 1);
            }
            else
            {
                // Move Christmas back a year so we correctly step into GetChristmasReading below
                christmas = new DateTime(date.Year - 1, 12, 25);
            }

            DailyReading? dailyReading = null;

            // Check first for a few feast days that may fall between different
            // liturgial seasons
            DailyReading? stJosephReading = GetStJosephFeastDay(date);
            if (stJosephReading != null)
                return stJosephReading;

            DailyReading? annunciation = GetAnnunciationFeastDay(date, ashWednesday, easter);
            if (annunciation != null)
                return annunciation;

            // Return daily reading within Advent
            if (date >= advent && date < christmas)
                dailyReading = GetAdventReading(advent, date, year);
            else if (date >= christmas && date <= baptismOfTheLord)
                dailyReading = GetChristmasReading(date, year, cycle);
            else if (date > baptismOfTheLord && date < ashWednesday)
                dailyReading = GetOrdinaryTime(date, baptismOfTheLord, ashWednesday, year, cycle);
            else if (date >= ashWednesday && date < easter.AddDays(-3)) /* from ash wednesday to before holy thursday */
                dailyReading = GetLent(date, ashWednesday, year);

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

        private DailyReading? GetChristmasReading(DateTime date, Year year, Cycle cycle)
        {
            // Christmas has 4 different readings depending on the Mass you go;
            // since we only have support to show one set of readings per day,
            // randomize the reading for Christmas
            if (date.Month == 12 && date.Day == 25)
            {
                Random rand = new Random();
                int r = rand.Next(4);

                return r switch
                {
                    0 => new DailyReading { FirstReading = "Is 62:1-5", SecondReading = "Acts 13:16-17, 22-25", Gospel = "Mt 1:1-17" },
                    1 => new DailyReading { FirstReading = "Is 9:1-6", SecondReading = "Ti 2:11-14", Gospel = "Lk 2:1-14" },
                    2 => new DailyReading { FirstReading = "Is 62:11-12", SecondReading = "Ti 3:4-7", Gospel = "Lk 2:15-20" },
                    3 => new DailyReading { FirstReading = "Is 52:7-10", SecondReading = "Heb 1:1-6", Gospel = "Jn 1:1-18" },
                    _ => null
                };
            }

            // Check feast days next

            // Ephiphany of the Lord / Baptism of the Lord
            DateTime holyFamily = _christmasCalculator.CalculateFeastOfTheHolyFamily(date.Year);
            DateTime ephiphany = _christmasCalculator.CalculateEphiphanyOfOurLord(date.Year);
            DateTime baptism = _christmasCalculator.CalculateBaptismOfTheLord(date.Year);

            // Corrects the feast date for days that fall prior to Jan 1st
            if (holyFamily < date)
                holyFamily = _christmasCalculator.CalculateFeastOfTheHolyFamily(date.Year + 1);
            if (date.Month == 12)
            {
                ephiphany = _christmasCalculator.CalculateEphiphanyOfOurLord(date.Year + 1);
                baptism = _christmasCalculator.CalculateBaptismOfTheLord(date.Year + 1);
            }

            if (holyFamily == date)
                return year switch
                {
                    Year.A => new DailyReading { FirstReading = "Sir 3:2-6, 12-14", SecondReading = "Col 3:12-21", Gospel = "Mt 2:13-15, 19-23" },
                    Year.B => new DailyReading { FirstReading = "Gn 15:1-6; 21:1-3", SecondReading = "Heb 11:8, 11-12, 17-19", Gospel = "Lk 2:22-40" },
                    Year.C => new DailyReading { FirstReading = "1 Sm 1:20-22, 24-28", SecondReading = "1 Jn 3:1-2, 21-24", Gospel = "Lk 2:41-52" },
                    _ => null
                };
            if (ephiphany == date)
                return new DailyReading { FirstReading = "Is 60:1-6", SecondReading = "Eph 3:2-3a, 5-6", Gospel = "Mt 2:1-12" };
            if (baptism == date)
                return year switch
                {
                    Year.A => new DailyReading { FirstReading = "Is 42:1-4, 6-7", SecondReading = "Acts 10:34-38", Gospel = "Mt 3:13-17" },
                    Year.B => new DailyReading { FirstReading = "Is 55:1-11", SecondReading = "1 Jn 5:1-9", Gospel = "Mk 1:7-11" },
                    Year.C => new DailyReading { FirstReading = "Is 40:1-5, 9-11", SecondReading = "Ti 2:11-14; 3:4-7", Gospel = "Lk 3:15-16, 21-22" },
                    _ => null
                };

            DateTime christmas = new DateTime(date.Year, 12, 25);
            if (date.Month == 1)
                christmas = new DateTime(date.Year - 1, 12, 25);
            TimeSpan difference = date.Subtract(christmas);
            int dayDifference = (int)difference.TotalDays;

            if (date < ephiphany)
            {
                return dayDifference switch
                {
                    // December 26th
                    1 => new DailyReading { FirstReading = "Acts 6:8-10; 7:54-59", Gospel = "Mt 10:17-22" },
                    // 27th
                    2 => new DailyReading { FirstReading = "1 Jn 1:1-4", Gospel = "Jn 20:1a, 2-8" },
                    // 28th
                    3 => new DailyReading { FirstReading = "1 Jn 1:5—2:2", Gospel = "Mt 2:13-18" },
                    // 29th
                    4 => new DailyReading { FirstReading = "1 Jn 2:3-11", Gospel = "Lk 2:22-35" },
                    // 30th
                    5 => new DailyReading { FirstReading = "1 Jn 2:12-17", Gospel = "Lk 2:36-40" },
                    // 31st
                    6 => new DailyReading { FirstReading = "1 Jn 2:18-21", Gospel = "Jn 1:1-18" },
                    // January 1st; Solemnity of the Blessed Virgin Mary
                    7 => new DailyReading { FirstReading = "Nm 6:22-27", SecondReading = "Gal 4:4-7", Gospel = "Lk 2:16-21" },
                    // January 2nd
                    8 => new DailyReading { FirstReading = "1 Jn 2:22-28", Gospel = "Jn 1:19-28" },
                    // 3rd
                    9 => new DailyReading { FirstReading = "1 Jn 2:29—3:6", Gospel = "Jn 1:29-34" },
                    // 4rd
                    10 => new DailyReading { FirstReading = "1 Jn 3:7-10", Gospel = "Jn 1:35-42" },
                    // 5th
                    11 => new DailyReading { FirstReading = "1 Jn 3:11-21", Gospel = "Jn 1:43-51" },
                    // 6th
                    12 => new DailyReading { FirstReading = "1 Jn 5:5-13", Gospel = "Mk 1:7-11" },
                    // 7th
                    13 => new DailyReading { FirstReading = "1 Jn 5:14-21", Gospel = "Jn 2:1-11" },
                    _ => null
                };
            }
            else
            {
                TimeSpan ephiphanyDifference = date.Subtract(ephiphany);
                int ephiphanyDayDifference = (int)ephiphanyDifference.TotalDays;

                if (date < baptism)
                {
                    return ephiphanyDayDifference switch
                    {
                        // Monday after Ephiphany
                        1 => new DailyReading { FirstReading = "1 Jn 3:22—4:6", Gospel = "Mt 4:12-17, 23-25" },
                        // Tuesday
                        2 => new DailyReading { FirstReading = "1 Jn 4:7-10", Gospel = "Mk 6:34-44" },
                        // Wednesday 
                        3 => new DailyReading { FirstReading = "1 Jn 4:11-18", Gospel = "Mk 6:45-52" },
                        // Thursday
                        4 => new DailyReading { FirstReading = "1 Jn 4:19—5:4", Gospel = "Lk 4:14-22a" },
                        // Friday
                        5 => new DailyReading { FirstReading = "1 Jn 5:5-13", Gospel = "Lk 5:12-16" },
                        // Saturday
                        6 => new DailyReading { FirstReading = "1 Jn 5:14-21", Gospel = "Jn 3:22-30" },
                        _ => null
                    };
                }
            }

            return null;
        }

        private DailyReading? GetOrdinaryTime(DateTime date, DateTime baptismOfTheLord, DateTime ashWednesday, Year year, Cycle cycle)
        {
            // Handle static feast days

            // Presentation of the Lord
            if (date.Month == 2 && date.Day == 2)
                return new DailyReading { FirstReading = "Mal 3:1-4", SecondReading = "Heb 2:14-18", Gospel = "Lk 2:22-40" };


            // Find 2nd Sunday of ordinary time;
            // this will be the anchoring value for
            // the rest of ordinary time before Lent
            DateTime secondSundayOfOrdinaryTime = baptismOfTheLord;

            do
            {
                secondSundayOfOrdinaryTime = secondSundayOfOrdinaryTime.AddDays(1);
            } while (secondSundayOfOrdinaryTime.DayOfWeek != DayOfWeek.Sunday);

            TimeSpan secondSundayDifference = date.Subtract(secondSundayOfOrdinaryTime);
            int secondSundayDayDifference = (int)secondSundayDifference.TotalDays;


            if (cycle == Cycle.One)
            {
                return secondSundayDayDifference switch
                {
                    // Week 1 Monday
                    -6 => new DailyReading { FirstReading = "Heb 1:1-6", Gospel = "Mk 1:14-22" },
                    // Tuesday
                    -5 => new DailyReading { FirstReading = "Heb 2:5-12", Gospel = "Mk 1:21-28" },
                    // Wednesday
                    -4 => new DailyReading { FirstReading = "Heb 2:14-18", Gospel = "Mk 1:29-39" },
                    // Thursday
                    -3 => new DailyReading { FirstReading = "Heb 3:7-14", Gospel = "Mk 1:40-45" },
                    // Friday
                    -2 => new DailyReading { FirstReading = "Heb 4:1-5, 11", Gospel = "Mk 2:1-12" },
                    // Saturday
                    -1 => new DailyReading { FirstReading = "Heb 4:12-16", Gospel = "Mk 2:13-17" },
                    // Week 2 Sunday
                    0 when year is Year.A => new DailyReading { FirstReading = "Is 49:3, 5-6", SecondReading = "1 Cor 1:1-3", Gospel = "Jn 1:29-34" },
                    0 when year is Year.B => new DailyReading { FirstReading = "1 Sm 3:3b-10, 19", SecondReading = "1 Cor 6:13c-15a, 17-20", Gospel = "Jn 1:35-42" },
                    0 when year is Year.C => new DailyReading { FirstReading = "Is 62:1-5", SecondReading = "1 Cor 12:4-11", Gospel = "Jn 2:1-11" },
                    // Monday
                    1 => new DailyReading { FirstReading = "Heb 5:1-10", Gospel = "Mk 2:18-22" },
                    // Tuesday
                    2 => new DailyReading { FirstReading = "Heb 6:10-20", Gospel = "Mk 2:23-28" },
                    // Wednesday
                    3 => new DailyReading { FirstReading = "Heb 7:1-3, 15-17", Gospel = "Mk 3:1-6" },
                    // Thursday
                    4 => new DailyReading { FirstReading = "Heb 7:25—8:6", Gospel = "Mk 3:7-12" },
                    // Friday
                    5 => new DailyReading { FirstReading = "Heb 8:6-13", Gospel = "Mk 3:13-19" },
                    // Saturday
                    6 => new DailyReading { FirstReading = "Heb 9:2-3, 11-14", Gospel = "Mk 3:20-21" },
                    // Week 3 Sunday
                    7 when year is Year.A => new DailyReading { FirstReading = "Is 8:23—9:3", SecondReading = "1 Cor 1:10-13, 17", Gospel = "Mt 4:12-23" },
                    7 when year is Year.B => new DailyReading { FirstReading = "Jon 3:1-5, 10", SecondReading = "1 Cor 7:29-31", Gospel = "Mk 1:14-20" },
                    7 when year is Year.C => new DailyReading { FirstReading = "Neh 8:2-4a, 5-6, 8-10", SecondReading = "1 Cor 12:12-30", Gospel = "Lk 1:1-4; 4:14-21" },
                    // Monday
                    8 => new DailyReading { FirstReading = "Heb 9:15, 24-28", Gospel = "Mk 3:22-30" },
                    // Tuesday
                    9 => new DailyReading { FirstReading = "Heb 10:1-10", Gospel = "Mk 3:31-35" },
                    // Wednesday
                    10 => new DailyReading { FirstReading = "Heb 10:11-18", Gospel = "Mk 4:1-22" },
                    // Thursday
                    11 => new DailyReading { FirstReading = "Heb 10:19-25", Gospel = "Mk 4:21-25" },
                    // Friday
                    12 => new DailyReading { FirstReading = "Heb 10:32-39", Gospel = "Mk 4:26-34" },
                    // Saturday
                    13 => new DailyReading { FirstReading = "Heb 11:1-2, 8-19", Gospel = "Mk 4:35-41" },
                    // Week 4 Sunday
                    14 when year is Year.A => new DailyReading { FirstReading = "Zep 2:3; 3:12-13", SecondReading = "1 Cor 1:26-31", Gospel = "Mt 5:1-12a" },
                    14 when year is Year.B => new DailyReading { FirstReading = "Dt 18:15-20", SecondReading = "1 Cor 7:32-35", Gospel = "Mk 1:21-28" },
                    14 when year is Year.C => new DailyReading { FirstReading = "Jer 1:4-5, 17-19", SecondReading = "1 Cor 12:31—13:13", Gospel = "Lk 4:21-30" },
                    // Monday
                    15 => new DailyReading { FirstReading = "Heb 11:32-40", Gospel = "Mk 5:1-22" },
                    // Tuesday
                    16 => new DailyReading { FirstReading = "Heb 12:1-4", Gospel = "Mk 5:21-43" },
                    // Wednesday
                    17 => new DailyReading { FirstReading = "Heb 12:4-7, 11-15", Gospel = "Mk 6:1-6" },
                    // Thursday
                    18 => new DailyReading { FirstReading = "Heb 12:18-19, 21-24", Gospel = "Mk 6:7-13" },
                    // Friday
                    19 => new DailyReading { FirstReading = "Heb 13:1-8", Gospel = "Mk 6:14-29" },
                    // Saturday
                    20 => new DailyReading { FirstReading = "Heb 13:15-17, 20-21", Gospel = "Mk 6:30-34" },
                    // Week 5 Sunday
                    21 when year is Year.A => new DailyReading { FirstReading = "Is 58:7-10", SecondReading = "1 Cor 2:1-5", Gospel = "Mt 5:13-16" },
                    21 when year is Year.B => new DailyReading { FirstReading = "Jb 7:1-4, 6-7", SecondReading = "1 Cor 9:16-19, 22-23", Gospel = "Mk 1:29-39" },
                    21 when year is Year.C => new DailyReading { FirstReading = "Is 6:1-2a, 3-8", SecondReading = "1 Cor 15:1-11", Gospel = "Lk 5:1-11" },
                    // Monday
                    22 => new DailyReading { FirstReading = "Gn 1:1-19", Gospel = "Mk 6:53-56" },
                    // Tuesday
                    23 => new DailyReading { FirstReading = "Gn 1:20—2:4a", Gospel = "Mk 7:1-13" },
                    // Wednesday
                    24 => new DailyReading { FirstReading = "Gn 2:4b-9, 15-17", Gospel = "Mk 7:14-23" },
                    // Thursday
                    25 => new DailyReading { FirstReading = "Gn 2:18-25", Gospel = "Mk 7:24-30" },
                    // Friday
                    26 => new DailyReading { FirstReading = "Gn 3:1-8", Gospel = "Mk 7:31-37" },
                    // Saturday
                    27 => new DailyReading { FirstReading = "Gn 3:9-24", Gospel = "Mk 8:1-10" },
                    // Week 6 Sunday
                    28 when year is Year.A => new DailyReading { FirstReading = "Sir 15:16-21", SecondReading = "1 Cor 2:6-10", Gospel = "Mt 5:17-37" },
                    28 when year is Year.B => new DailyReading { FirstReading = "Lv 13:1-2, 44-46", SecondReading = "1 Cor 10:31—11:1", Gospel = "Mk 1:40-45" },
                    28 when year is Year.C => new DailyReading { FirstReading = "Jer 17:5-8", SecondReading = "1 Cor 15:12, 16-20", Gospel = "Lk 6:17, 20-26" },
                    // Monday
                    29 => new DailyReading { FirstReading = "Gn 4:1-15, 25", Gospel = "Mk 8:11-13" },
                    // Tuesday
                    30 => new DailyReading { FirstReading = "Gn 6:5-8; 7:1-5, 10", Gospel = "Mk 8:14-21" },
                    // Wednesday
                    31 => new DailyReading { FirstReading = "Gn 8:6-13, 20-22", Gospel = "Mk 8:22-26" },
                    // Thursday
                    32 => new DailyReading { FirstReading = "Gn 9:1-13", Gospel = "Mk 8:27-33" },
                    // Friday
                    33 => new DailyReading { FirstReading = "Gn 11:1-9", Gospel = "Mk 8:34—9:1" },
                    // Saturday
                    34 => new DailyReading { FirstReading = "Heb 11:1-7", Gospel = "Mk 9:2-13" },
                    // Week 7 Sunday
                    35 when year is Year.A => new DailyReading { FirstReading = "Lv 19:1-2, 17-18", SecondReading = "1 Cor 3:16-23", Gospel = "Mt 5:38-48" },
                    35 when year is Year.B => new DailyReading { FirstReading = "Is 43:18-19, 21-22, 24b-25", SecondReading = "2 Cor 1:18-22", Gospel = "Mk 2:1-12" },
                    35 when year is Year.C => new DailyReading { FirstReading = "1 Sm 26:2, 7-9, 12-13, 22-23", SecondReading = "1 Cor 15:45-49", Gospel = "Lk 6:27-38" },
                    // Monday
                    36 => new DailyReading { FirstReading = "Sir 1:1-10", Gospel = "Mk 9:14-29" },
                    // Tuesday
                    37 => new DailyReading { FirstReading = "Sir 2:1-11", Gospel = "Mk 9:30-37" },
                    // Wednesday
                    38 => new DailyReading { FirstReading = "Sir 4:11-19", Gospel = "Mk 9:38-40" },
                    // Thursday
                    39 => new DailyReading { FirstReading = "Sir 5:1-8", Gospel = "Mk 9:41-50" },
                    // Friday
                    40 => new DailyReading { FirstReading = "Sir 6:5-17", Gospel = "Mk 10:1-12" },
                    // Saturday
                    41 => new DailyReading { FirstReading = "Sir 17:1-15", Gospel = "Mk 10:13-16" },
                    // Week 8 Sunday
                    42 when year is Year.A => new DailyReading { FirstReading = "Is 49:14-15", SecondReading = "1 Cor 4:1-5", Gospel = "Mt 6:24-34" },
                    42 when year is Year.B => new DailyReading { FirstReading = "Hos 2:16b, 17b, 21-22", SecondReading = "2 Cor 3:1b-6", Gospel = "Mk 2:18-22" },
                    42 when year is Year.C => new DailyReading { FirstReading = "Sir 27:5-8", SecondReading = "1 Cor 15:54-58", Gospel = "Lk 6:39-45" },
                    // Monday
                    43 => new DailyReading { FirstReading = "Sir 17:20-24", Gospel = "Mk 10:17-27" },
                    // Tuesday
                    44 => new DailyReading { FirstReading = "Sir 35:1-12", Gospel = "Mk 10:28-31" },
                    // Wednesday
                    45 => new DailyReading { FirstReading = "Sir 36:1, 4-5a, 10-17", Gospel = "Mk 10:32-45" },
                    // Thursday
                    46 => new DailyReading { FirstReading = "Sir 42:15-25", Gospel = "Mk 10:46-52" },
                    // Friday
                    47 => new DailyReading { FirstReading = "Sir 44:1, 9-13", Gospel = "Mk 11:11-26" },
                    // Saturday
                    48 => new DailyReading { FirstReading = "Sir 51:12cd-20", Gospel = "Mk 11:27-33" },
                    // Week 9 Sunday
                    49 when year is Year.A => new DailyReading { FirstReading = "Dt 11:18, 26-28, 32", SecondReading = "Rom 3:21-25, 28", Gospel = "Mt 7:21-27" },
                    49 when year is Year.B => new DailyReading { FirstReading = "Dt 5:12-15", SecondReading = "2 Cor 4:6-11", Gospel = "Mk 2:23—3:6" },
                    49 when year is Year.C => new DailyReading { FirstReading = "1 Kgs 8:41-43", SecondReading = "Gal 1:1-2, 6-10", Gospel = "Lk 7:1-10" },
                    // Monday
                    50 => new DailyReading { FirstReading = "Tb 1:3; 2:1a-8", Gospel = "Mk 12:1-12" },
                    // Tuesday
                    51 => new DailyReading { FirstReading = "Tb 2:9-14", Gospel = "Mk 12:13-17" },


                    // The below probably need new numbers; we are at Lent here within the years
                    // that have the longest ordinary time before Lent

                    // Wednesday
                    52 => new DailyReading { FirstReading = "Tb 3:1-11a, 16-17a", Gospel = "Mk 12:18-27" },
                    // Thursday
                    53 => new DailyReading { FirstReading = "Tb 6:10-11; 7:1bcde, 9-17; 8:4-9a", Gospel = "Mk 12:28b-34" },
                    // Friday
                    54 => new DailyReading { FirstReading = "Tb 11:5-17", Gospel = "Mk 12:35-37" },
                    // Saturday
                    55 => new DailyReading { FirstReading = "Tb 12:1, 5-15, 20", Gospel = "Mk 12:38-44" },
                    // Week 10 Sunday
                    56 when year is Year.A => new DailyReading { FirstReading = "Hos 6:3-6", SecondReading = "Rom 4:18-25", Gospel = "Mt 9:9-13" },
                    56 when year is Year.B => new DailyReading { FirstReading = "Gn 3:9-15", SecondReading = "2 Cor 4:13—5:1", Gospel = "Mk 3:20-35" },
                    56 when year is Year.C => new DailyReading { FirstReading = "1 Kgs 17:17-24", SecondReading = "Gal 1:11-19", Gospel = "Lk 7:11-17" },
                    // Monday
                    57 => new DailyReading { FirstReading = "2 Cor 1:1-7", Gospel = "Mt 5:1-12" },
                    // Tuesday
                    58 => new DailyReading { FirstReading = "2 Cor 1:18-22", Gospel = "Mt 5:13-16" },
                    // Wednesday
                    59 => new DailyReading { FirstReading = "2 Cor 3:4-11", Gospel = "Mt 5:17-19" },
                    // Thursday
                    60 => new DailyReading { FirstReading = "2 Cor 3:15—4:1, 3-6", Gospel = "Mt 5:20-26" },
                    // Friday
                    61 => new DailyReading { FirstReading = "2 Cor 4:7-15", Gospel = "Mt 5:27-32" },
                    // Saturday
                    62 => new DailyReading { FirstReading = "2 Cor 5:14-21", Gospel = "Mt 5:33-37" },
                    _ => null
                };
            }
            else if (cycle == Cycle.Two)
            {
                return secondSundayDayDifference switch
                {
                    // Week 1 Monday
                    -6 => new DailyReading { FirstReading = "1 Sm 1:1-8", Gospel = "Mk 1:14-22" },
                    // Tuesday
                    -5 => new DailyReading { FirstReading = "1 Sm 1:9-22", Gospel = "Mk 1:21-28" },
                    // Wednesday
                    -4 => new DailyReading { FirstReading = "1 Sm 3:1-10, 19-22", Gospel = "Mk 1:29-39" },
                    // Thursday
                    -3 => new DailyReading { FirstReading = "1 Sm 4:1-11", Gospel = "Mk 1:40-45" },
                    // Friday
                    -2 => new DailyReading { FirstReading = "1 Sm 8:4-7, 10-22a", Gospel = "Mk 2:1-12" },
                    // Saturday
                    -1 => new DailyReading { FirstReading = "1 Sm 9:1-4, 17-19; 10:1", Gospel = "Mk 2:13-17" },
                    // Week 2 Sunday
                    0 when year is Year.A => new DailyReading { FirstReading = "Is 49:3, 5-6", SecondReading = "1 Cor 1:1-3", Gospel = "Jn 1:29-34" },
                    0 when year is Year.B => new DailyReading { FirstReading = "1 Sm 3:3b-10, 19", SecondReading = "1 Cor 6:13c-15a, 17-20", Gospel = "Jn 1:35-42" },
                    0 when year is Year.C => new DailyReading { FirstReading = "Is 62:1-5", SecondReading = "1 Cor 12:4-11", Gospel = "Jn 2:1-11" },
                    // Monday
                    1 => new DailyReading { FirstReading = "1 Sm 15:16-23", Gospel = "Mk 2:18-22" },
                    // Tuesday
                    2 => new DailyReading { FirstReading = "1 Sm 16:1-13", Gospel = "Mk 2:23-28" },
                    // Wednesday
                    3 => new DailyReading { FirstReading = "1 Sm 17:32-33, 37, 40-51", Gospel = "Mk 3:1-6" },
                    // Thursday
                    4 => new DailyReading { FirstReading = "1 Sm 18:6-9; 19:1-7", Gospel = "Mk 3:7-12" },
                    // Friday
                    5 => new DailyReading { FirstReading = "1 Sm 24:3-21", Gospel = "Mk 3:13-19" },
                    // Saturday
                    6 => new DailyReading { FirstReading = "2 Sm 1:1-4, 11-12, 19, 23-27", Gospel = "Mk 3:20-21" },
                    // Week 3 Sunday
                    7 when year is Year.A => new DailyReading { FirstReading = "Is 8:23—9:3", SecondReading = "1 Cor 1:10-13, 17", Gospel = "Mt 4:12-23" },
                    7 when year is Year.B => new DailyReading { FirstReading = "Jon 3:1-5, 10", SecondReading = "1 Cor 7:29-31", Gospel = "Mk 1:14-20" },
                    7 when year is Year.C => new DailyReading { FirstReading = "Neh 8:2-4a, 5-6, 8-10", SecondReading = "1 Cor 12:12-30", Gospel = "Lk 1:1-4; 4:14-21" },
                    // Monday
                    8 => new DailyReading { FirstReading = "2 Sm 5:1-7, 10", Gospel = "Mk 3:22-30" },
                    // Tuesday
                    9 => new DailyReading { FirstReading = "2 Sm 6:12b-15, 17-19", Gospel = "Mk 3:31-35" },
                    // Wednesday
                    10 => new DailyReading { FirstReading = "2 Sm 7:4-17", Gospel = "Mk 4:1-22" },
                    // Thursday
                    11 => new DailyReading { FirstReading = "2 Sm 7:18-19, 24-29", Gospel = "Mk 4:21-25" },
                    // Friday
                    12 => new DailyReading { FirstReading = "2 Sm 11:1-4a, 5-10a, 13-17", Gospel = "Mk 4:26-34" },
                    // Saturday
                    13 => new DailyReading { FirstReading = "2 Sm 12:1-7a, 10-17", Gospel = "Mk 4:35-41" },
                    // Week 4 Sunday
                    14 when year is Year.A => new DailyReading { FirstReading = "Zep 2:3; 3:12-13", SecondReading = "1 Cor 1:26-31", Gospel = "Mt 5:1-12a" },
                    14 when year is Year.B => new DailyReading { FirstReading = "Dt 18:15-20", SecondReading = "1 Cor 7:32-35", Gospel = "Mk 1:21-28" },
                    14 when year is Year.C => new DailyReading { FirstReading = "Jer 1:4-5, 17-19", SecondReading = "1 Cor 12:31—13:13", Gospel = "Lk 4:21-30" },
                    // Monday
                    15 => new DailyReading { FirstReading = "2 Sm 15:13-14, 30; 16:5-13", Gospel = "Mk 5:1-22" },
                    // Tuesday
                    16 => new DailyReading { FirstReading = "2 Sm 18:9-10, 14b, 24-25a, 30—19:3", Gospel = "Mk 5:21-43" },
                    // Wednesday
                    17 => new DailyReading { FirstReading = "2 Sm 24:2, 9-17", Gospel = "Mk 6:1-6" },
                    // Thursday
                    18 => new DailyReading { FirstReading = "1 Kgs 2:1-4, 10-12", Gospel = "Mk 6:7-13" },
                    // Friday
                    19 => new DailyReading { FirstReading = "Sir 47:2-11", Gospel = "Mk 6:14-29" },
                    // Saturday
                    20 => new DailyReading { FirstReading = "1 Kgs 3:4-13", Gospel = "Mk 6:30-34" },
                    // Week 5 Sunday
                    21 when year is Year.A => new DailyReading { FirstReading = "Is 58:7-10", SecondReading = "1 Cor 2:1-5", Gospel = "Mt 5:13-16" },
                    21 when year is Year.B => new DailyReading { FirstReading = "Jb 7:1-4, 6-7", SecondReading = "1 Cor 9:16-19, 22-23", Gospel = "Mk 1:29-39" },
                    21 when year is Year.C => new DailyReading { FirstReading = "Is 6:1-2a, 3-8", SecondReading = "1 Cor 15:1-11", Gospel = "Lk 5:1-11" },
                    // Monday
                    22 => new DailyReading { FirstReading = "1 Kgs 8:1-7, 9-13", Gospel = "Mk 6:53-56" },
                    // Tuesday
                    23 => new DailyReading { FirstReading = "1 Kgs 8:22-23, 27-30", Gospel = "Mk 7:1-13" },
                    // Wednesday
                    24 => new DailyReading { FirstReading = "1 Kgs 10:1-10", Gospel = "Mk 7:14-23" },
                    // Thursday
                    25 => new DailyReading { FirstReading = "1 Kgs 11:4-13", Gospel = "Mk 7:24-30" },
                    // Friday
                    26 => new DailyReading { FirstReading = "1 Kgs 11:29-32; 12:19", Gospel = "Mk 7:31-37" },
                    // Saturday
                    27 => new DailyReading { FirstReading = "1 Kgs 12:26-32; 13:33-34", Gospel = "Mk 8:1-10" },
                    // Week 6 Sunday
                    28 when year is Year.A => new DailyReading { FirstReading = "Sir 15:16-21", SecondReading = "1 Cor 2:6-10", Gospel = "Mt 5:17-37" },
                    28 when year is Year.B => new DailyReading { FirstReading = "Lv 13:1-2, 44-46", SecondReading = "1 Cor 10:31—11:1", Gospel = "Mk 1:40-45" },
                    28 when year is Year.C => new DailyReading { FirstReading = "Jer 17:5-8", SecondReading = "1 Cor 15:12, 16-20", Gospel = "Lk 6:17, 20-26" },
                    // Monday
                    29 => new DailyReading { FirstReading = "Jas 1:1-11", Gospel = "Mk 8:11-13" },
                    // Tuesday
                    30 => new DailyReading { FirstReading = "Jas 1:12-18", Gospel = "Mk 8:14-21" },
                    // Wednesday
                    31 => new DailyReading { FirstReading = "Jas 1:19-27", Gospel = "Mk 8:22-26" },
                    // Thursday
                    32 => new DailyReading { FirstReading = "Jas 2:1-9", Gospel = "Mk 8:27-33" },
                    // Friday
                    33 => new DailyReading { FirstReading = "Jas 2:14-24, 26", Gospel = "Mk 8:34—9:1" },
                    // Saturday
                    34 => new DailyReading { FirstReading = "Jas 3:1-10", Gospel = "Mk 9:2-13" },
                    // Week 7 Sunday
                    35 when year is Year.A => new DailyReading { FirstReading = "Lv 19:1-2, 17-18", SecondReading = "1 Cor 3:16-23", Gospel = "Mt 5:38-48" },
                    35 when year is Year.B => new DailyReading { FirstReading = "Is 43:18-19, 21-22, 24b-25", SecondReading = "2 Cor 1:18-22", Gospel = "Mk 2:1-12" },
                    35 when year is Year.C => new DailyReading { FirstReading = "1 Sm 26:2, 7-9, 12-13, 22-23", SecondReading = "1 Cor 15:45-49", Gospel = "Lk 6:27-38" },
                    // Monday
                    36 => new DailyReading { FirstReading = "Jas 3:13-18", Gospel = "Mk 9:14-29" },
                    // Tuesday
                    37 => new DailyReading { FirstReading = "Jas 4:1-10", Gospel = "Mk 9:30-37" },
                    // Wednesday
                    38 => new DailyReading { FirstReading = "Jas 4:13-17", Gospel = "Mk 9:38-40" },
                    // Thursday
                    39 => new DailyReading { FirstReading = "Jas 5:1-6", Gospel = "Mk 9:41-50" },
                    // Friday
                    40 => new DailyReading { FirstReading = "Jas 5:9-12", Gospel = "Mk 10:1-12" },
                    // Saturday
                    41 => new DailyReading { FirstReading = "Jas 5:13-22", Gospel = "Mk 10:13-16" },
                    // Week 8 Sunday
                    42 when year is Year.A => new DailyReading { FirstReading = "Is 49:14-15", SecondReading = "1 Cor 4:1-5", Gospel = "Mt 6:24-34" },
                    42 when year is Year.B => new DailyReading { FirstReading = "Hos 2:16b, 17b, 21-22", SecondReading = "2 Cor 3:1b-6", Gospel = "Mk 2:18-22" },
                    42 when year is Year.C => new DailyReading { FirstReading = "Sir 27:5-8", SecondReading = "1 Cor 15:54-58", Gospel = "Lk 6:39-45" },
                    // Monday
                    43 => new DailyReading { FirstReading = "1 Pt 1:3-9", Gospel = "Mk 10:17-27" },
                    // Tuesday
                    44 => new DailyReading { FirstReading = "1 Pt 1:10-16", Gospel = "Mk 10:28-31" },
                    // Wednesday
                    45 => new DailyReading { FirstReading = "1 Pt 1:18-25", Gospel = "Mk 10:32-45" },
                    // Thursday
                    46 => new DailyReading { FirstReading = "1 Pt 2:2-5, 9-12", Gospel = "Mk 10:46-52" },
                    // Friday
                    47 => new DailyReading { FirstReading = "1 Pt 4:7-13", Gospel = "Mk 11:11-26" },
                    // Saturday
                    48 => new DailyReading { FirstReading = "Jude 17, 20b-25", Gospel = "Mk 11:27-33" },
                    // Week 9 Sunday
                    49 when year is Year.A => new DailyReading { FirstReading = "Dt 11:18, 26-28, 32", SecondReading = "Rom 3:21-25, 28", Gospel = "Mt 7:21-27" },
                    49 when year is Year.B => new DailyReading { FirstReading = "Dt 5:12-15", SecondReading = "2 Cor 4:6-11", Gospel = "Mk 2:23—3:6" },
                    49 when year is Year.C => new DailyReading { FirstReading = "1 Kgs 8:41-43", SecondReading = "Gal 1:1-2, 6-10", Gospel = "Lk 7:1-10" },
                    // Monday
                    50 => new DailyReading { FirstReading = "2 Pt 1:2-7", Gospel = "Mk 12:1-12" },
                    // Tuesday
                    51 => new DailyReading { FirstReading = "2 Pt 3:12-15a, 17-18", Gospel = "Mk 12:13-17" },


                    // The below probably need new numbers; we are at Lent here within the years
                    // that have the longest ordinary time before Lent

                    // Wednesday
                    52 => new DailyReading { FirstReading = "2 Tm 1:1-3, 6-12", Gospel = "Mk 12:18-27" },
                    // Thursday
                    53 => new DailyReading { FirstReading = "2 Tm 2:8-15", Gospel = "Mk 12:28b-34" },
                    // Friday
                    54 => new DailyReading { FirstReading = "2 Tm 3:10-17", Gospel = "Mk 12:35-37" },
                    // Saturday
                    55 => new DailyReading { FirstReading = "2 Tm 4:1-8", Gospel = "Mk 12:38-44" },
                    // Week 10 Sunday
                    56 when year is Year.A => new DailyReading { FirstReading = "Hos 6:3-6", SecondReading = "Rom 4:18-25", Gospel = "Mt 9:9-13" },
                    56 when year is Year.B => new DailyReading { FirstReading = "Gn 3:9-15", SecondReading = "2 Cor 4:13—5:1", Gospel = "Mk 3:20-35" },
                    56 when year is Year.C => new DailyReading { FirstReading = "1 Kgs 17:17-24", SecondReading = "Gal 1:11-19", Gospel = "Lk 7:11-17" },
                    // Monday
                    57 => new DailyReading { FirstReading = "1 Kgs 17:1-6", Gospel = "Mt 5:1-12" },
                    // Tuesday
                    58 => new DailyReading { FirstReading = "1 Kgs 17:7-16", Gospel = "Mt 5:13-16" },
                    // Wednesday
                    59 => new DailyReading { FirstReading = "1 Kgs 18:20-39", Gospel = "Mt 5:17-19" },
                    // Thursday
                    60 => new DailyReading { FirstReading = "1 Kgs 18:41-46", Gospel = "Mt 5:20-26" },
                    // Friday
                    61 => new DailyReading { FirstReading = "1 Kgs 19:9a, 11-16", Gospel = "Mt 5:27-32" },
                    // Saturday
                    62 => new DailyReading { FirstReading = "1 Kgs 19:19-21", Gospel = "Mt 5:33-37" },
                    _ => null
                };
            }

            return null;
        }

        private DailyReading? GetLent(DateTime date, DateTime ashWednesday, Year year)
        {
            TimeSpan ashWednesdayDifference = date.Subtract(ashWednesday);
            int ashWednesdayDayDifference = (int)ashWednesdayDifference.TotalDays;

            return ashWednesdayDayDifference switch
            {
                // Ash Wednesday
                0 => new DailyReading { FirstReading = "Jl 2:12-18", Gospel = "Mt 6:1-6, 16-18" },
                1 => new DailyReading { FirstReading = "Dt 30:15-20", Gospel = "Lk 9:22-25" },
                2 => new DailyReading { FirstReading = "Is 58:1-9a", Gospel = "Mt 9:14-15" },
                3 => new DailyReading { FirstReading = "Is 58:9b-14", Gospel = "Lk 5:27-32" },
                // 1st Sunday of Lent
                4 when year is Year.A => new DailyReading { FirstReading = "Gn 2:7-9; 3:1-7", SecondReading = "Rom 5:12-19", Gospel = "Mt 4:1-11" },
                4 when year is Year.B => new DailyReading { FirstReading = "Gn 9:8-15", SecondReading = "1 Pt 3:18-22", Gospel = "Mk 1:12-15" },
                4 when year is Year.C => new DailyReading { FirstReading = "Dt 26:4-10", SecondReading = "Rom 10:8-13", Gospel = "Lk 4:1-13" },
                // Monday
                5 => new DailyReading { FirstReading = "Lv 19:1-2, 11-18", Gospel = "Mt 25:31-46" },
                // Tuesday
                6 => new DailyReading { FirstReading = "Is 55:10-11", Gospel = "Mt 6:7-15" },
                // Wednesday
                7 => new DailyReading { FirstReading = "Jon 3:1-10", Gospel = "Lk 11:29-32" },
                // Thursday
                8 => new DailyReading { FirstReading = "Est C:12, 14-16, 23-25", Gospel = "Mt 7:7-12" },
                // Friday
                9 => new DailyReading { FirstReading = "Ez 18:21-28", Gospel = "Mt 5:20-26" },
                // Saturday
                10 => new DailyReading { FirstReading = "Dt 26:16-19", Gospel = "Mt 5:43-48" },
                // 2nd Sunday of Lent
                11 when year is Year.A => new DailyReading { FirstReading = "Gn 12:1-4a", SecondReading = "2 Tm 1:8b-10", Gospel = "Mt 17:1-9" },
                11 when year is Year.B => new DailyReading { FirstReading = "Gn 22:1-2, 9a, 10-13, 15-18", SecondReading = "Rom 8:31b-34", Gospel = "Mk 9:2-10" },
                11 when year is Year.C => new DailyReading { FirstReading = "Gn 15:5-12, 17-18", SecondReading = "Phil 3:17–4:1", Gospel = "Lk 9:28b-36" },
                // Monday
                12 => new DailyReading { FirstReading = "Dn 9:4b-10", Gospel = "Lk 6:36-38" },
                // Tuesday
                13 => new DailyReading { FirstReading = "Is 1:10, 16-20", Gospel = "Mt 23:1-12" },
                // Wednesday
                14 => new DailyReading { FirstReading = "Jer 18:18-20", Gospel = "Mt 20:17-28" },
                // Thursday
                15 => new DailyReading { FirstReading = "Jer 17:5-10", Gospel = "Lk 16:19-31" },
                // Friday
                16 => new DailyReading { FirstReading = "Gn 37:3-4, 12-13a, 17b-28a", Gospel = "Mt 21:33-43, 45-46" },
                // Saturday
                17 => new DailyReading { FirstReading = "Mi 7:14-15, 18-20", Gospel = "Lk 15:1-3, 11-32" },
                // 3rd Sunday of Lent
                18 when year is Year.A => new DailyReading { FirstReading = "Ex 17:3-7", SecondReading = "Rom 5:1-2, 5-8", Gospel = "Jn 4:5-42" },
                18 when year is Year.B => new DailyReading { FirstReading = "Ex 20:1-17", SecondReading = "1 Cor 1:22-25", Gospel = "Jn 2:13-25" },
                18 when year is Year.C => new DailyReading { FirstReading = "Ex 3:1-8a, 13-15", SecondReading = "1 Cor 10:1-6, 10-12", Gospel = "Lk 13:1-9" },
                // Monday
                19 => new DailyReading { FirstReading = "2 Kgs 5:1-15a", Gospel = "Lk 4:24-30" },
                // Tuesday
                20 => new DailyReading { FirstReading = "Dn 3:25, 34-43", Gospel = "Mt 18:21-35" },
                // Wednesday
                21 => new DailyReading { FirstReading = "Dt 4:1, 5-9", Gospel = "Mt 5:17-19" },
                // Thursday
                22 => new DailyReading { FirstReading = "Jer 7:23-28", Gospel = "Lk 11:14-23" },
                // Friday
                23 => new DailyReading { FirstReading = "Hos 14:2-10", Gospel = "Mk 12:28b-34" },
                // Saturday
                24 => new DailyReading { FirstReading = "Hos 6:1-6", Gospel = "Lk 18:9-14" },
                // 4th Sunday of Lent
                25 when year is Year.A => new DailyReading { FirstReading = "1 Sm 16:1b, 6-7, 10-13a", SecondReading = "Eph 5:8-14", Gospel = "Jn 9:1-41" },
                25 when year is Year.B => new DailyReading { FirstReading = "2 Chr 36:14-16, 19-23", SecondReading = "Eph 2:4-10", Gospel = "Jn 3:14-21" },
                25 when year is Year.C => new DailyReading { FirstReading = "Jos 5:9a, 10-12", SecondReading = "2 Cor 5:17-21", Gospel = "Lk 15:1-3, 11-32" },
                // Monday
                26 => new DailyReading { FirstReading = "Is 65:17-21", Gospel = "Jn 4:43-54" },
                // Tuesday
                27 => new DailyReading { FirstReading = "Ez 47:1-9, 12", Gospel = "Jn 5:1-3a, 5-16" },
                // Wednesday
                28 => new DailyReading { FirstReading = "Is 49:8-15", Gospel = "Jn 5:17-30" },
                // Thursday
                29 => new DailyReading { FirstReading = "Ex 32:7-14", Gospel = "Jn 5:31-47" },
                // Friday
                30 => new DailyReading { FirstReading = "Wis 2:1a, 12-22", Gospel = "Jn 7:1-2, 10, 25-30" },
                // Saturday
                31 => new DailyReading { FirstReading = "Jer 11:18-20", Gospel = "Jn 7:40-53" },
                // 5th Sunday of Lent
                32 when year is Year.A => new DailyReading { FirstReading = "Ez 37:12-14", SecondReading = "Rom 8:8-11", Gospel = "Jn 11:1-45" },
                32 when year is Year.B => new DailyReading { FirstReading = "Jer 31:31-34", SecondReading = "Heb 5:7-9", Gospel = "Jn 12:20-33" },
                32 when year is Year.C => new DailyReading { FirstReading = "Is 43:16-21", SecondReading = "Phil 3:8-14", Gospel = "Jn 8:1-11" },
                // Monday
                33 => new DailyReading { FirstReading = "Dn 13:1-9, 15-17, 19-30, 33-62", Gospel = "Jn 8:1-11" },
                // Tuesday
                34 => new DailyReading { FirstReading = "Nm 21:4-9", Gospel = "Jn 8:21-30" },
                // Wednesday
                35 => new DailyReading { FirstReading = "Dn 3:14-20, 91-92, 95", Gospel = "Jn 8:31-42" },
                // Thursday
                36 => new DailyReading { FirstReading = "Gn 17:3-9", Gospel = "Jn 8:51-59" },
                // Friday
                37 => new DailyReading { FirstReading = "Jer 20:10-13", Gospel = "Jn 10:31-42" },
                // Saturday
                38 => new DailyReading { FirstReading = "Ez 37:21-28", Gospel = "Jn 11:45-56" },
                // Palm Sunday
                39 when year is Year.A => new DailyReading { FirstReading = "Is 50:4-7", SecondReading = "Phil 2:6-11", Gospel = "Mt 26:14 – 27:66" },
                39 when year is Year.B => new DailyReading { FirstReading = "Is 50:4-7", SecondReading = "Phil 2:6-11", Gospel = "Mk 14:1 – 15:47" },
                39 when year is Year.C => new DailyReading { FirstReading = "Is 50:4-7", SecondReading = "Phil 2:6-11", Gospel = "Lk 22:14 – 23:56" },
                // Monday
                40 => new DailyReading { FirstReading = "Is 42:1-7", Gospel = "Jn 12:1-11" },
                // Tuesday
                41 => new DailyReading { FirstReading = "Is 49:1-6", Gospel = "Jn 13:21-33, 36-38" },
                // Wednesday
                42 => new DailyReading { FirstReading = "Is 50:4-9a", Gospel = "Mt 26:14-25" },
                _ => null
            };
        }

        /// <summary>
        /// Returns with a non-null value if <paramref name="date"/> is the feast of St Joseph.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private DailyReading? GetStJosephFeastDay(DateTime date)
        {
            // The feast of St Joseph may fall in Ordinary Time or Lent, so we have a separate method to check for it.            
            DateTime stJosephFeastDay = new DateTime(date.Year, 3, 19);

            // If the Immaculate Conception falls on a Sunday, the readings
            // are said on the following day
            if ((stJosephFeastDay.DayOfWeek == DayOfWeek.Sunday && date.Month == 3 && date.Day == 20) ||
                (date.DayOfWeek != DayOfWeek.Sunday && date.Month == 3 && date.Day == 19))
                return new DailyReading { FirstReading = "2 Sm 7:4-5a, 12-14a, 16", SecondReading = "Rom 4:13, 16-18, 22", Gospel = "Mt 1:16, 18-21, 24a" };

            return null;
        }

        private DailyReading? GetAnnunciationFeastDay(DateTime date, DateTime lent, DateTime easter)
        {
            DateTime annunciation = new DateTime(date.Year, 3, 25);

            DateTime beginningOfHolyWeek = easter.AddDays(-7); // Palm Sunday
            DateTime endOfOctaveOfEaster = easter.AddDays(6);

            // If March 25th falls on a Sunday during Lent, then the feast
            // day is transferred to Monday March 26th
            if (lent <= annunciation && annunciation < beginningOfHolyWeek && annunciation.DayOfWeek == DayOfWeek.Sunday)
            {
                if (date == annunciation.AddDays(1))
                    return new DailyReading { FirstReading = "Is 7:10-14; 8:10", SecondReading = "Heb 10:4-10", Gospel = "Lk 1:26-38" };
            }
            // If March 25th falls during Holy Week or the Easter Octave, then
            // the feast day is transferred to Monday of the 2nd week of Easter
            else if (beginningOfHolyWeek <= annunciation && annunciation <= endOfOctaveOfEaster)
            {
                DateTime transferredMonday = endOfOctaveOfEaster.AddDays(2);

                if (date == transferredMonday)
                    return new DailyReading { FirstReading = "Is 7:10-14; 8:10", SecondReading = "Heb 10:4-10", Gospel = "Lk 1:26-38" };
            }
            else if (date == annunciation)
                return new DailyReading { FirstReading = "Is 7:10-14; 8:10", SecondReading = "Heb 10:4-10", Gospel = "Lk 1:26-38" };

            return null;
        }

        private DailyReading? GetEaster(DateTime date, DateTime easter, Year year)
        {
            TimeSpan easterDifference = date.Subtract(easter);
            int easterDayDifference = (int)easterDifference.TotalDays;

            return easterDayDifference switch
            {
                // Holy Thursday
                -3 => new DailyReading { FirstReading = "Ex 12:1-8, 11-14", SecondReading = "1 Cor 11:23-26", Gospel = "Jn 13:1-15" },
                // Good Friday
                -2 => new DailyReading { FirstReading = "Is 52:13—53:12", SecondReading = "Heb 4:14-16; 5:7-9", Gospel = "Jn 18:1—19:42" },
                // Holy Saturday
                -1 when year is Year.A => new DailyReading { FirstReading = "Ex 14:15—15:1", SecondReading = "Rom 6:3-11", Gospel = "Mt 28:1-10" },
                -1 when year is Year.B => new DailyReading { FirstReading = "Ex 14:15—15:1", SecondReading = "Rom 6:3-11", Gospel = "Mk 16:1-7" },
                -1 when year is Year.C => new DailyReading { FirstReading = "Ex 14:15—15:1", SecondReading = "Rom 6:3-11", Gospel = "Lk 24:1-12" },
                // Easter Sunday
                0 => new DailyReading { FirstReading = "Acts 10:34a, 37-43", SecondReading = "Col 3:1-4", Gospel = "Jn 20:1-9" },
                // Monday
                1 => new DailyReading { FirstReading = "Acts 2:14, 22-33", Gospel = "Mt 28:8-15d" },
                // Tuesday
                2 => new DailyReading { FirstReading = "Acts 2:36-41", Gospel = "Jn 20:11-18" },
                // Wednesday
                3 => new DailyReading { FirstReading = "Acts 3:1-10", Gospel = "Lk 24:13-35" },
                // Thursday
                4 => new DailyReading { FirstReading = "Acts 3:11-26", Gospel = "Lk 24:35-48" },
                // Friday
                5 => new DailyReading { FirstReading = "Acts 4:1-12", Gospel = "Jn 21:1-14" },
                // Saturday
                6 => new DailyReading { FirstReading = "Acts 4:13-21", Gospel = "Mk 16:9-15" },
                // 2nd Sunday of Easter
                7 when year is Year.A => new DailyReading { FirstReading = "Acts 2:42-47", SecondReading = "1 Pt 1:3-9", Gospel = "Jn 20:19-31" },
                7 when year is Year.B => new DailyReading { FirstReading = "Acts 4:32-35v", SecondReading = "1 Jn 5:1-6", Gospel = "Jn 20:19-31" },
                7 when year is Year.C => new DailyReading { FirstReading = "Acts 5:12-16", SecondReading = "Rv 1:9-11a, 12-13, 17-19", Gospel = "Jn 20:19-31" },
                // Monday
                8 => new DailyReading { FirstReading = "Acts 4:23-31", Gospel = "Jn 3:1-8" },
                // Tuesday
                9 => new DailyReading { FirstReading = "Acts 4:32-37", Gospel = "Jn 3:7b-15" },
                // Wednesday
                10 => new DailyReading { FirstReading = "Acts 5:17-26", Gospel = "Jn 3:16-21" },
                // Thursday
                11 => new DailyReading { FirstReading = "Acts 5:27-33", Gospel = "Jn 3:31-36" },
                // Friday
                12 => new DailyReading { FirstReading = "Acts 5:34-42", Gospel = "Jn 6:1-15" },
                // Saturday
                13 => new DailyReading { FirstReading = "Acts 6:1-7", Gospel = "Jn 6:16-21" },
                // 3rd Sunday of Easter
                14 when year is Year.A => new DailyReading { FirstReading = "Acts 2:14, 22-33", SecondReading = "1 Pt 1:17-21", Gospel = "Lk 24:13-35" },
                14 when year is Year.B => new DailyReading { FirstReading = "Acts 3:13-15, 17-19", SecondReading = "1 Jn 2:1-5a", Gospel = "Lk 24:35-48" },
                14 when year is Year.C => new DailyReading { FirstReading = "Acts 5:27-32, 40b-41", SecondReading = "Rv 5:11-14", Gospel = "Jn 21:1-19" },
                // Monday
                15 => new DailyReading { FirstReading = "Acts 6:8-15", Gospel = "Jn 6:22-29" },
                // Tuesday
                16 => new DailyReading { FirstReading = "Acts 7:51—8:1a", Gospel = "Jn 6:30-35" },
                // Wednesday
                17 => new DailyReading { FirstReading = "Acts 8:1b-8", Gospel = "Jn 6:35-40" },
                // Thursday
                18 => new DailyReading { FirstReading = "Acts 8:26-40", Gospel = "Jn 6:44-51" },
                // Friday
                19 => new DailyReading { FirstReading = "Acts 9:1-20", Gospel = "Jn 6:52-59" },
                // Saturday
                20 => new DailyReading { FirstReading = "Acts 9:31-42", Gospel = "Jn 6:60-69" },
                // 4th Sunday of Easter
                21 when year is Year.A => new DailyReading { FirstReading = "Acts 2:14a, 36-41", SecondReading = "1 Pt 2:20b-25", Gospel = "Jn 10:1-10" },
                21 when year is Year.B => new DailyReading { FirstReading = "Acts 4:8-12", SecondReading = "1 Jn 3:1-2", Gospel = "Jn 10:11-18" },
                21 when year is Year.C => new DailyReading { FirstReading = "Acts 13:14, 43-52", SecondReading = "Rv 7:9, 14b-17", Gospel = "Jn 10:27-30" },
                // Monday
                22 when year is Year.A => new DailyReading { FirstReading = "Acts 11:1-18", Gospel = "Jn 10:11-18" },
                22 => new DailyReading { FirstReading = "Acts 11:1-18", Gospel = "Jn 10:1-10" },                
                // Tuesday
                23 => new DailyReading { FirstReading = "Acts 11:19-26", Gospel = "Jn 10:22-30" },
                // Wednesday
                24 => new DailyReading { FirstReading = "Acts 12:24—13:5a", Gospel = "Jn 12:44-50" },
                // Thursday
                25 => new DailyReading { FirstReading = "Acts 13:13-25", Gospel = "Jn 13:16-20" },
                // Friday
                26 => new DailyReading { FirstReading = "Acts 13:26-33", Gospel = "Jn 14:1-6" },
                // Saturday
                27 => new DailyReading { FirstReading = "Acts 13:44-52", Gospel = "Jn 14:7-14" },
                // 5th Sunday of Easter
                28 when year is Year.A => new DailyReading { FirstReading = "Acts 6:1-7", SecondReading = "1 Pt 2:4-9", Gospel = "Jn 14:1-12" },
                28 when year is Year.B => new DailyReading { FirstReading = "Acts 9:26-31", SecondReading = "1 Jn 3:18-24", Gospel = "Jn 15:1-8" },
                28 when year is Year.C => new DailyReading { FirstReading = "Acts 14:21-27", SecondReading = "Rv 21:1-5a", Gospel = "Jn 13:31-33a, 34-35" },
                // Monday                
                29 => new DailyReading { FirstReading = "Acts 14:5-18", Gospel = "Jn 14:21-26" },
                // Tuesday
                30 => new DailyReading { FirstReading = "Acts 14:19-28", Gospel = "Jn 14:27-31a" },
                // Wednesday
                31 => new DailyReading { FirstReading = "Acts 15:1-6", Gospel = "Jn 15:1-8" },
                // Thursday
                32 => new DailyReading { FirstReading = "Acts 15:7-21", Gospel = "Jn 15:9-11" },
                // Friday
                33 => new DailyReading { FirstReading = "Acts 15:22-31", Gospel = "Jn 15:12-17" },
                // Saturday
                34 => new DailyReading { FirstReading = "Acts 16:1-10", Gospel = "Jn 15:18-21" },
                // 6th Sunday of Easter
                35 when year is Year.A => new DailyReading { FirstReading = "Acts 8:5-8, 14-17", SecondReading = "1 Pt 3:15-18", Gospel = "Jn 14:15-21" },
                35 when year is Year.B => new DailyReading { FirstReading = "Acts 10:25-26, 34-35, 44-48", SecondReading = "1 Jn 4:7-10", Gospel = "Jn 15:9-17" },
                35 when year is Year.C => new DailyReading { FirstReading = "Acts 15:1-2, 22-29", SecondReading = "Rv 21:10-14, 22-23", Gospel = "Jn 14:23-29" },
                // Monday                
                36 => new DailyReading { FirstReading = "Acts 16:11-15", Gospel = "Jn 15:26-16:4a" },
                // Tuesday
                37 => new DailyReading { FirstReading = "Acts 16:22-34", Gospel = "Jn 16:5-11" },
                // Wednesday
                38 => new DailyReading { FirstReading = "Acts 17:15, 22—18:1", Gospel = "Jn 16:12-15" },
                // Thursday
                39 => new DailyReading { FirstReading = "Acts 18:1-8", Gospel = "Jn 16:16-20" },
                // Friday
                40 => new DailyReading { FirstReading = "Acts 18:9-18", Gospel = "Jn 16:20-23" },
                // Saturday
                41 => new DailyReading { FirstReading = "Acts 18:23-28", Gospel = "Jn 16:23b-28" },
                // 7th Sunday of Easter
                42 when year is Year.A => new DailyReading { FirstReading = "Acts 1:12-14", SecondReading = "1 Pt 4:13-16", Gospel = "Jn 17:1-11a" },
                42 when year is Year.B => new DailyReading { FirstReading = "Acts 1:15-17, 20a, 20c-26", SecondReading = "1 Jn 4:11-16", Gospel = "Jn 17:11b-19" },
                42 when year is Year.C => new DailyReading { FirstReading = "Acts 7:55-60", SecondReading = "Rv 22:12-14, 16-17, 20", Gospel = "Jn 17:20-26" },
                // Monday                
                43 => new DailyReading { FirstReading = "Acts 19:1-8", Gospel = "Jn 16:29-33" },
                // Tuesday
                44 => new DailyReading { FirstReading = "Acts 20:17-27", Gospel = "Jn 17:1-11a" },
                // Wednesday
                45 => new DailyReading { FirstReading = "Acts 20:28-38", Gospel = "Jn 17:11b-19" },
                // Thursday
                46 => new DailyReading { FirstReading = "Acts 22:30; 23:6-11", Gospel = "Jn 17:20-26" },
                // Friday
                47 => new DailyReading { FirstReading = "Acts 25:13b-21", Gospel = "Jn 21:15-19" },
                // Saturday
                48 => new DailyReading { FirstReading = "Gn 11:1-9", SecondReading = "Rom 8:22-27", Gospel = "Jn 7:37-39" },
                // Pentecost
                49 when year is Year.A => new DailyReading { FirstReading = "Acts 2:1-11", SecondReading = "1 Cor 12:3b-7, 12-13", Gospel = "Jn 20:19-23" },
                49 when year is Year.B => new DailyReading { FirstReading = "Acts 2:1-11", SecondReading = "Gal 5:16-25", Gospel = "Jn 15:26-27; 16:12-15" },
                49 when year is Year.C => new DailyReading { FirstReading = "Acts 2:1-11", SecondReading = "Rom 8:8-17", Gospel = "Jn 14:15-16, 23b-26" },
                _ => null
            };
        }
    }
}
