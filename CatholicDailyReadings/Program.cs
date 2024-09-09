// See https://aka.ms/new-console-template for more information
using CatholicDailyReadings.Business;
using CatholicDailyReadings.Models;
using CatholicDailyReadings.Models.Enums;
using CatholicDailyReadings.Utils;

ChristmasCalculator christmasCalculator = new ChristmasCalculator();
AdventCalculator adventCalculator = new AdventCalculator();
MoonCalculator moonCalculator = new MoonCalculator();
CycleCalculator cycleCalculator = new CycleCalculator();
BibleProvider bibleProvider = new BibleProvider();


for (int i = 2023; i <= 2400; i++)
{
    DateTime d = new DateTime(i, 1, 1);

    while (d.Year == i)
    {
        DailyReading? reading = bibleProvider.GetDailyReading(d);

        if (reading == null)
        {
            Console.WriteLine(d.ToString("yyyy-MM-dd"));
            reading = bibleProvider.GetDailyReading(d);
        }
            

        d = d.AddDays(1);
    }

    Console.WriteLine($"Finished {i}");

    //DateTime advent = adventCalculator.Calculate(i);
    //DateTime pentecost = moonCalculator.GetPentecost(i);

    //DateTime temp = new DateTime(advent.Year, advent.Month, advent.Day);
    //temp = temp.AddDays(-1);

    //int week = 34;

    //while (temp > pentecost)
    //{
    //    if (temp.AddDays(1).DayOfWeek == DayOfWeek.Sunday)
    //        week--;


    //    if (week == (10 - 1))
    //    {
    //        DailyReading? r = bibleProvider.GetDailyReading(temp);

    //        if (r != null)
    //        {
    //            if (r.Cycle == Cycle.One && r.Year == Year.B && temp.DayOfWeek == DayOfWeek.Sunday)
    //            {
    //                Console.WriteLine(temp.ToString("MM/dd"));
    //                Console.WriteLine(temp.ToShortDateString());
    //            }
    //        }
    //    }


    //    temp = temp.AddDays(-1);
    //}



    //DateTime pentecost = moonCalculator.GetPentecost(i);
    //DateTime easter = moonCalculator.GetEaster(i);
    //DateTime advent = adventCalculator.Calculate(i);
    //TimeSpan span = advent - pentecost;
    //DateTime temp = new DateTime(advent.Year, advent.Month, advent.Day);
    //DailyReading? r = bibleProvider.GetDailyReading(temp);

    //Console.WriteLine($"{i} {r.Year} {pentecost.ToString("yyyy-MM-dd")} {advent.ToString("yyyy-MM-dd")} {span.Days}");

    //// not-skip 
    //if (i == 2035 ||
    //    i == 2046 ||
    //    i == 2062 ||
    //    i == 2054 ||
    //    i == 2073 ||
    //    i == 2084)
    //    Console.WriteLine($"{i} {pentecost.ToString("yyyy-MM-dd")} {span.Days}");

    //// skip 
    //if (i == 2027 ||
    //    i == 2032 ||
    //    i == 2043 ||
    //    i == 2054 ||
    //    i == 2059 ||
    //    i == 2065 ||
    //    i == 2070 ||
    //    i == 2081 ||
    //    i == 2086 ||
    //    i == 2092 ||
    //    i == 2097 ||
    //    i == 2100)
    //    Console.WriteLine($"{i} {pentecost.ToString("yyyy-MM-dd")} {span.Days}");

    //DateTime annunciation = new DateTime(i, 3, 25);
    //DateTime ashWednesday = moonCalculator.GetLent(i);
    //DateTime easter = moonCalculator.GetEaster(i);
    //DateTime beginningOfHolyWeek = easter.AddDays(-7); // Palm Sunday

    //if (ashWednesday <= annunciation && annunciation < beginningOfHolyWeek && annunciation.DayOfWeek == DayOfWeek.Sunday)
    //{
    //    Console.WriteLine(annunciation.AddDays(1));
    //    //if (date == annunciation.AddDays(1))
    //    //    Console.WriteLine(i);
    //        //return new DailyReading { FirstReading = "Is 7:10-14; 8:10", SecondReading = "Heb 10:4-10", Gospel = "Lk 1:26-38" };
    //}


    //Year year = cycleCalculator.CalculateYear(new DateTime(i, 1, 1));

    //TimeSpan diff = ashWednesday.Subtract(baptismOfTheLord);
    ////Console.WriteLine($"{i} ({year}) = {diff.TotalDays / 7}");



    //Console.WriteLine($"{new DateTime(i, 3, 19).ToString("MM-dd-yyyy")} {new DateTime(i, 3, 19).DayOfWeek}");
}




