namespace CatholicDailyReadings.Utils
{
    public class ChristmasCalculator
    {
        /// <summary>
        /// calculate the date for the Feast of the Holy Family for a given <paramref name="year"/>.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DateTime CalculateFeastOfTheHolyFamily(int year)
        {
            // The Feast of the Holy Family is the first Sunday after Christmas
            DateTime holyFamily = new DateTime(year, 12, 25);

            do
            {
                holyFamily = holyFamily.AddDays(1);
            } while (holyFamily.DayOfWeek != DayOfWeek.Sunday);

            return holyFamily;
        }

        /// <summary>
        /// Calculate the date for the Ephiphany of the Lord for a given <paramref name="year"/>.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public DateTime CalculateEphiphanyOfOurLord(int year)
        {
            // The Ephiphany of the Lord is on the first Sunday
            // after January 1st always occurs on January 6th
            DateTime ephiphany = new DateTime(year, 1, 1);

            do
            {
                ephiphany = ephiphany.AddDays(1);
            } while (ephiphany.DayOfWeek != DayOfWeek.Sunday);

            return ephiphany;
        }

        /// <summary>
        /// Calculate the date for the Baptism of the Lord for a given <paramref name="year"/>.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DateTime CalculateBaptismOfTheLord(int year)
        {
            // The Baptism of the Lord occurs on the first Sunday following
            // the Ephiphany of the Lord, unless the Ephiphany of the Lord
            // falls on January 7th or 8th - in this case, the Baptistm of
            // the Lord is celebrated on the Monday following the Ephiphay of 
            // the Lord
            DateTime baptismOfTheLord = CalculateEphiphanyOfOurLord(year);

            if (baptismOfTheLord.Day == 7 || baptismOfTheLord.Day == 8)
                return baptismOfTheLord.AddDays(1);

            do
            {
                baptismOfTheLord = baptismOfTheLord.AddDays(1);
            } while (baptismOfTheLord.DayOfWeek != DayOfWeek.Sunday);

            return baptismOfTheLord;
        }
    }
}
