// See https://aka.ms/new-console-template for more information
using CatholicDailyReadings.Business;
using CatholicDailyReadings.Utils;

ChristmasCalculator christmasCalculator = new ChristmasCalculator();
MoonCalculator moonCalculator = new MoonCalculator();


for (int i = 1900; i <= 2100; i++)
{
    DateTime baptismOfTheLord = christmasCalculator.CalculateBaptismOfTheLord(i);
    DateTime ashWednesday = moonCalculator.GetLent(i);

    TimeSpan diff = ashWednesday.Subtract(baptismOfTheLord);
    Console.WriteLine($"{i} = {diff.TotalDays / 7}");
}




