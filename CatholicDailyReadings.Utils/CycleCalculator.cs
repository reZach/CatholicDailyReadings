using CatholicDailyReadings.Models.Enums;

namespace CatholicDailyReadings.Utils
{
    public class CycleCalculator
    {
        /// <summary>
        /// Calculate the year based on <paramref name="date"/>.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public Year CalculateYear(DateTime date)
        {
            // If the year is divisible by 3, the year is C
            int mod = date.Year % 3;

            return mod switch
            {
                0 => Year.C,
                1 => Year.A,
                _ => Year.B
            };
        }

        /// <summary>
        /// Calculate the cycle based on <paramref name="date"/>.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public Cycle CalculateCycle(DateTime date)
        {
            // If the year is odd, the cycle is 1
            bool even = date.Year % 2 == 0;

            return even ? Cycle.Two : Cycle.One;
        }
    }
}