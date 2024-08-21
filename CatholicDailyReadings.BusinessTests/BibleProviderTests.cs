using CatholicDailyReadings.Business;
using CatholicDailyReadings.Models;

namespace CatholicDailyReadings.BusinessTests
{
    public class BibleProviderTests
    {
        private readonly BibleProvider _bibleProvider;

        public BibleProviderTests()
        {
            _bibleProvider = new BibleProvider();
        }

        #region Advent

        [Fact]
        public void GetAdventYearA_Week1Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2022, 11, 27);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);
            
            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 2:1-5", SecondReading = "Rom 13:11-14", Gospel = "Mt 24:37-44" }.XUnitComparer);
        }

        [Fact]
        public void GetAdventYearB_Week1Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2023, 12, 3);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 63:16b-17, 19b; 64:2-7", SecondReading = "1 Cor 1:3-9", Gospel = "Mk 13:33-37" }.XUnitComparer);
        }

        [Fact]
        public void GetAdventYearC_Week1Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2024, 12, 1);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jer 33:14-16", SecondReading = "1 Thes 3:12—4:2", Gospel = "Lk 21:25-28, 34-36" }.XUnitComparer);
        }

        [Fact]
        public void GetAdventYearA_Week1Monday_ReturnValue()
        {
            DateTime day = new DateTime(2022, 11, 28);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equivalent(reading.XUnitComparer, new DailyReading { FirstReading = "Is 4:2-6", Gospel = "Mt 8:5-11" }.XUnitComparer);
        }

        [Fact]
        public void GetAdventNotYearA_Week1Monday_ReturnValue()
        {
            DateTime day = new DateTime(2023, 12, 4);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.NotEqual(Models.Enums.Year.A, reading.Year);
            Assert.Equivalent(reading.XUnitComparer, new DailyReading { FirstReading = "Is 2:1-5", Gospel = "Mt 8:5-11" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_Week1Tuesday_ReturnValue()
        {
            DateTime day = new DateTime(2022, 11, 29);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equivalent(reading.XUnitComparer, new DailyReading { FirstReading = "Is 11:1-10", Gospel = "Lk 10:21-24" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_Week1Wednesday_ReturnValue()
        {
            DateTime day = new DateTime(2022, 11, 30);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equivalent(reading.XUnitComparer, new DailyReading { FirstReading = "Is 25:6-10a", Gospel = "Mt 15:29-37" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_Week1Thursday_ReturnValue()
        {
            DateTime day = new DateTime(2022, 12, 1);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equivalent(reading.XUnitComparer, new DailyReading { FirstReading = "Is 26:1-6", Gospel = "Mt 7:21, 24-27" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_Week1Friday_ReturnValue()
        {
            DateTime day = new DateTime(2022, 12, 2);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equivalent(reading.XUnitComparer, new DailyReading { FirstReading = "Is 29:17-24", Gospel = "Mt 9:27-31" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_Week1Saturday_ReturnValue()
        {
            DateTime day = new DateTime(2022, 12, 3);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equivalent(reading.XUnitComparer, new DailyReading { FirstReading = "Is 30:19-21, 23-26", Gospel = "Mt 9:35—10:1, 5a, 6-8" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_ImmaculateConceptionSunday_ReturnValue()
        {
            DateTime day = new DateTime(2024, 12, 9);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equivalent(reading.XUnitComparer, new DailyReading { FirstReading = "Gn 3:9-15, 20", SecondReading = "Eph 1:3-6, 11-12", Gospel = "Lk 1:26-38" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_ImmaculateConceptionNotSunday_ReturnValue()
        {
            DateTime day = new DateTime(2023, 12, 8);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equivalent(reading.XUnitComparer, new DailyReading { FirstReading = "Gn 3:9-15, 20", SecondReading = "Eph 1:3-6, 11-12", Gospel = "Lk 1:26-38" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_OurLadyOfGuadalupe_ReturnValue()
        {
            DateTime day = new DateTime(2023, 12, 12);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equivalent(reading.XUnitComparer, new DailyReading { FirstReading = "Zec 2:14-17", Gospel = "Lk 1:39-47" }.XUnitComparer);
        }

        [Fact]
        public void GetAdventYearA_Week2Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 12, 7);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 11:1-10", SecondReading = "Rom 15:4-9", Gospel = "Mt 3:1-12" }.XUnitComparer);
        }

        [Fact]
        public void GetAdventYearB_Week2Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2023, 12, 10);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 40:1-5, 9-11", SecondReading = "2 Pt 3:8-14", Gospel = "Mk 1:1-8" }.XUnitComparer);
        }

        [Fact]
        public void GetAdventYearC_Week2Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2024, 12, 8);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Bar 5:1-9", SecondReading = "Phil 1:4-6, 8-11", Gospel = "Lk 3:1-6" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_Week2Monday_ReturnValue()
        {
            DateTime day = new DateTime(2023, 12, 11);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equivalent(reading.XUnitComparer, new DailyReading { FirstReading = "Is 35:1-10", Gospel = "Lk 5:17-26" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_Week2Tuesday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 12, 9);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equivalent(reading.XUnitComparer, new DailyReading { FirstReading = "Is 40:1-11", Gospel = "Mt 18:12-14" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_Week2Wednesday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 12, 10);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equivalent(reading.XUnitComparer, new DailyReading { FirstReading = "Is 40:25-31", Gospel = "Mt 11:28-30" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_Week2Thursday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 12, 11);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equivalent(reading.XUnitComparer, new DailyReading { FirstReading = "Is 41:13-20", Gospel = "Mt 11:11-15" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_Week2Friday_ReturnValue()
        {
            DateTime day = new DateTime(2023, 12, 15);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equivalent(reading.XUnitComparer, new DailyReading { FirstReading = "Is 48:17-19", Gospel = "Mt 11:16-19" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_Week2Saturday_ReturnValue()
        {
            DateTime day = new DateTime(2023, 12, 16);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equivalent(reading.XUnitComparer, new DailyReading { FirstReading = "Sir 48:1-4, 9-11", Gospel = "Mt 17:9a, 10-13" }.XUnitComparer);
        }

        #endregion
    }
}
