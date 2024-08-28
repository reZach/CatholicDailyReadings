// See https://aka.ms/new-console-template for more information
using CatholicDailyReadings.Business;
using CatholicDailyReadings.Models.Enums;
using CatholicDailyReadings.Utils;

ChristmasCalculator christmasCalculator = new ChristmasCalculator();
MoonCalculator moonCalculator = new MoonCalculator();
CycleCalculator cycleCalculator = new CycleCalculator();


for (int i = 1900; i <= 2100; i++)
{
    DateTime baptismOfTheLord = christmasCalculator.CalculateBaptismOfTheLord(i);
    DateTime ashWednesday = moonCalculator.GetLent(i);
    Year year = cycleCalculator.CalculateYear(new DateTime(i, 1, 1));

    TimeSpan diff = ashWednesday.Subtract(baptismOfTheLord);
    //Console.WriteLine($"{i} ({year}) = {diff.TotalDays / 7}");



    Console.WriteLine($"{new DateTime(i, 3, 19).ToString("MM-dd-yyyy")} {new DateTime(i, 3, 19).DayOfWeek}");
}




