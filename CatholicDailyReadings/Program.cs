// See https://aka.ms/new-console-template for more information
using CatholicDailyReadings.Business;
using CatholicDailyReadings.Models;
using CatholicDailyReadings.Models.Enums;
using CatholicDailyReadings.Utils;
using static System.Runtime.InteropServices.JavaScript.JSType;

ChristmasCalculator christmasCalculator = new ChristmasCalculator();
MoonCalculator moonCalculator = new MoonCalculator();
CycleCalculator cycleCalculator = new CycleCalculator();


for (int i = 1900; i <= 2100; i++)
{
    DateTime annunciation = new DateTime(i, 3, 25);
    DateTime ashWednesday = moonCalculator.GetLent(i);
    DateTime easter = moonCalculator.GetEaster(i);
    DateTime beginningOfHolyWeek = easter.AddDays(-7); // Palm Sunday

    if (ashWednesday <= annunciation && annunciation < beginningOfHolyWeek && annunciation.DayOfWeek == DayOfWeek.Sunday)
    {
        Console.WriteLine(annunciation.AddDays(1));
        //if (date == annunciation.AddDays(1))
        //    Console.WriteLine(i);
            //return new DailyReading { FirstReading = "Is 7:10-14; 8:10", SecondReading = "Heb 10:4-10", Gospel = "Lk 1:26-38" };
    }


    //Year year = cycleCalculator.CalculateYear(new DateTime(i, 1, 1));

    //TimeSpan diff = ashWednesday.Subtract(baptismOfTheLord);
    ////Console.WriteLine($"{i} ({year}) = {diff.TotalDays / 7}");



    //Console.WriteLine($"{new DateTime(i, 3, 19).ToString("MM-dd-yyyy")} {new DateTime(i, 3, 19).DayOfWeek}");
}




