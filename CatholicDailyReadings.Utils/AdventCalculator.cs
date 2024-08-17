namespace CatholicDailyReadings.Utils
{
    public class AdventCalculator
    {
        /// <summary>
        /// Calculate the date for Advent for a given <paramref name="year"/>.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public DateTime Calculate(int year)
        {
            // Advent always starts 4 Sundays before Christmas
            DateTime advent = new DateTime(year, 12, 25);

            int foundSundays = 0;
            while (foundSundays < 4)
            {
                advent = advent.AddDays(-1);

                if (advent.DayOfWeek == DayOfWeek.Sunday)
                    foundSundays++;
            }

            return advent;
        }
    }
}