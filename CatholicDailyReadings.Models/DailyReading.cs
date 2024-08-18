using CatholicDailyReadings.Models.Enums;

namespace CatholicDailyReadings.Models
{
    public class DailyReading
    {
        public Year Year { get; set; }
        public Cycle Cycle { get; set; }
        public required string FirstReading { get; set; }
        public string? SecondReading { get; set; }
        public required string Gospel { get; set; }
                
        /// <summary>
        /// Use this when writing unit tests comparing the DailyReadings to the expected value.
        /// </summary>
        public string XUnitComparer
        {
            // This is the least-nasty way I wanted to go about this.
            // 
            // There will be many hundreds of unit tests confirming the
            // daily readings are correct. In the unit tests, I wanted
            // to just copy the source code (ie. >> new DailyReading { FirstReading = "Is 2:1-5", SecondReading = "Rom 13:11-14", Gospel = "Mt 24:37-44" } )
            // from BibleProvider into the BibleProviderTests file in order to write unit tests quickly.
            //
            // The majority of unit tests will be comparing the FirstReading,
            // SecondReading, and Gospel properties. There will be fewer unit
            // tests confirming the values of Year and Cycle. With these constraints,
            // I couldn't use Assert.Equivalent as an easy way to confirm the
            // results of the unit tests, as Assert.Equivalent compares all public
            // properties on an object. Since Year and Cycle are dynamically set
            // through the BibleProvider.GetDailyReading() call, if I were to use
            // Assert.Equivalent unilaterally in BibleProviderTests, that would
            // force me to manually set the Year and Cycle for all unit tests.
            // Since I want to mix and match dates in my unit tests, it is _way_
            // to much mental overload to calculate the Year and Cycle for the
            // hundreds of unit tests that will be written.
            //
            // Instead, we have XUnitComparer that is meant to be used to compare
            // the FirstReading, SecondReading, and Gospel properties. In unit 
            // tests that want to compare other properties, we will use Assert.Equals
            // as an additional validation/s.

            get
            {
                if (SecondReading == null)
                    return $"{FirstReading} / {Gospel}";
                else
                    return $"{FirstReading} / {SecondReading} / {Gospel}";
            }
        }
    }
}
