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

        [Fact]
        public void GetAdventYearA_Week3Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 12, 14);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 35:1-6a, 10", SecondReading = "Jas 5:7-10", Gospel = "Mt 11:2-11" }.XUnitComparer);
        }

        [Fact]
        public void GetAdventYearB_Week3Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2023, 12, 17);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 61:1-2a, 10-11", SecondReading = "1 Thes 5:16-24", Gospel = "Jn 1:6-8, 19-28" }.XUnitComparer);
        }

        [Fact]
        public void GetAdventYearC_Week3Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2024, 12, 15);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Zep 3:14-18a", SecondReading = "Phil 4:4-7", Gospel = "Lk 3:10-18" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_Week3MondayNoCutoff_ReturnValue()
        {
            DateTime day = new DateTime(2025, 12, 15);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Nm 24:2-7, 15-17a", Gospel = "Mt 21:23-27" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_Week3TuesdayNoCutoff_ReturnValue()
        {
            DateTime day = new DateTime(2025, 12, 16);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Zep 3:1-2, 9-13", Gospel = "Mt 21:28-32" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_Week3WednesdayNoCutoff_ReturnValue()
        {
            DateTime day = new DateTime(2016, 12, 14);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 45:6c-8, 18, 21c-25", Gospel = "Lk 7:18b-23" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_Week3ThursdayNoCutoff_ReturnValue()
        {
            DateTime day = new DateTime(2016, 12, 15);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 54:1-10", Gospel = "Lk 7:24-30" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_Week3FridayNoCutoff_ReturnValue()
        {
            DateTime day = new DateTime(2016, 12, 16);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 56:1-3a, 6-8", Gospel = "Jn 5:33-36" }.XUnitComparer);
        }

        [Fact]
        public void GetAdventYearA_LastWeekSunday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 12, 21);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 7:10-14", SecondReading = "Rom 1:1-7", Gospel = "Mt 1:18-24" }.XUnitComparer);
        }

        [Fact]
        public void GetAdventYearB_LastWeekSunday_ReturnValue()
        {
            DateTime day = new DateTime(2023, 12, 24);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "2 Sm 7:1-5, 8b-12, 14a, 16", SecondReading = "Rom 16:25-27", Gospel = "Lk 1:26-38" }.XUnitComparer);
        }

        [Fact]
        public void GetAdventYearC_LastWeekSunday_ReturnValue()
        {
            DateTime day = new DateTime(2024, 12, 22);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Mi 5:1-4a", SecondReading = "Heb 10:5-10", Gospel = "Lk 1:39-45" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_LastWeekDec17_ReturnValue()
        {
            DateTime day = new DateTime(2024, 12, 17);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Gn 49:2, 8-10", Gospel = "Mt 1:1-17" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_LastWeekDec18_ReturnValue()
        {
            DateTime day = new DateTime(2024, 12, 18);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jer 23:5-8", Gospel = "Mt 1:18-24" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_LastWeekDec19_ReturnValue()
        {
            DateTime day = new DateTime(2024, 12, 19);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jgs 13:2-7, 24-25a", Gospel = "Lk 1:5-25" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_LastWeekDec20_ReturnValue()
        {
            DateTime day = new DateTime(2024, 12, 20);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 7:10-14", Gospel = "Lk 1:26-38" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_LastWeekDec21_ReturnValue()
        {
            DateTime day = new DateTime(2024, 12, 21);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Zep 3:14-18a", Gospel = "Lk 1:39-45" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_LastWeekDec22_ReturnValue()
        {
            DateTime day = new DateTime(2023, 12, 22);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Sm 1:24-28", Gospel = "Lk 1:46-56" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_LastWeekDec23_ReturnValue()
        {
            DateTime day = new DateTime(2024, 12, 23);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Mal 3:1-4, 23-24", Gospel = "Lk 1:57-66" }.XUnitComparer);
        }

        [Fact]
        public void GetAdvent_LastWeekDec24_ReturnValue()
        {
            DateTime day = new DateTime(2024, 12, 24);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "2 Sm 7:1-5, 8b-12, 14a, 16", Gospel = "Lk 1:67-79" }.XUnitComparer);
        }

        #endregion

        #region Christmas

        [Fact]
        public void GetChristmas_ReturnValue()
        {
            DateTime day = new DateTime(2024, 12, 25);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            // Christmas is set up to return any one of 4 random readings
            Assert.NotNull(reading);
        }

        [Fact]
        public void GetHolyFamily_YearA_ReturnValue()
        {
            DateTime day = new DateTime(2025, 12, 28);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Sir 3:2-6, 12-14", SecondReading = "Col 3:12-21", Gospel = "Mt 2:13-15, 19-23" }.XUnitComparer);
        }

        [Fact]
        public void GetHolyFamily_YearB_ReturnValue()
        {
            DateTime day = new DateTime(2023, 12, 31);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Gn 15:1-6; 21:1-3", SecondReading = "Heb 11:8, 11-12, 17-19", Gospel = "Lk 2:22-40" }.XUnitComparer);
        }

        [Fact]
        public void GetHolyFamily_YearC_ReturnValue()
        {
            DateTime day = new DateTime(2024, 12, 29);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Sm 1:20-22, 24-28", SecondReading = "1 Jn 3:1-2, 21-24", Gospel = "Lk 2:41-52" }.XUnitComparer);
        }

        [Fact]
        public void GetEphiphany_ReturnValue()
        {
            DateTime day = new DateTime(2021, 1, 3);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 60:1-6", SecondReading = "Eph 3:2-3a, 5-6", Gospel = "Mt 2:1-12" }.XUnitComparer);
        }

        [Fact]
        public void GetBaptism_YearA_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 11);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 42:1-4, 6-7", SecondReading = "Acts 10:34-38", Gospel = "Mt 3:13-17" }.XUnitComparer);
        }

        [Fact]
        public void GetBaptism_YearB_ReturnValue()
        {
            DateTime day = new DateTime(2024, 1, 8);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 55:1-11", SecondReading = "1 Jn 5:1-9", Gospel = "Mk 1:7-11" }.XUnitComparer);
        }

        [Fact]
        public void GetBaptism_YearC_ReturnValue()
        {
            DateTime day = new DateTime(2025, 1, 12);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 40:1-5, 9-11", SecondReading = "Ti 2:11-14; 3:4-7", Gospel = "Lk 3:15-16, 21-22" }.XUnitComparer);
        }

        [Fact]
        public void GetChristmas_December26_ReturnValue()
        {
            DateTime day = new DateTime(2025, 12, 26);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Acts 6:8-10; 7:54-59", Gospel = "Mt 10:17-22" }.XUnitComparer);
        }

        [Fact]
        public void GetChristmas_December27_ReturnValue()
        {
            DateTime day = new DateTime(2025, 12, 27);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Jn 1:1-4", Gospel = "Jn 20:1a, 2-8" }.XUnitComparer);
        }

        [Fact]
        public void GetChristmas_December28_ReturnValue()
        {
            DateTime day = new DateTime(2023, 12, 28);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Jn 1:5—2:2", Gospel = "Mt 2:13-18" }.XUnitComparer);
        }

        [Fact]
        public void GetChristmas_December29_ReturnValue()
        {
            DateTime day = new DateTime(2023, 12, 29);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Jn 2:3-11", Gospel = "Lk 2:22-35" }.XUnitComparer);
        }

        [Fact]
        public void GetChristmas_December30_ReturnValue()
        {
            DateTime day = new DateTime(2023, 12, 30);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Jn 2:12-17", Gospel = "Lk 2:36-40" }.XUnitComparer);
        }

        [Fact]
        public void GetChristmas_December31_ReturnValue()
        {
            DateTime day = new DateTime(2024, 12, 31);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Jn 2:18-21", Gospel = "Jn 1:1-18" }.XUnitComparer);
        }

        [Fact]
        public void GetChristmas_January2_ReturnValue()
        {
            DateTime day = new DateTime(2024, 1, 2);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Jn 2:22-28", Gospel = "Jn 1:19-28" }.XUnitComparer);
        }

        [Fact]
        public void GetChristmas_January3_ReturnValue()
        {
            DateTime day = new DateTime(2024, 1, 3);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Jn 2:29—3:6", Gospel = "Jn 1:29-34" }.XUnitComparer);
        }

        [Fact]
        public void GetChristmas_January4_ReturnValue()
        {
            DateTime day = new DateTime(2024, 1, 4);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Jn 3:7-10", Gospel = "Jn 1:35-42" }.XUnitComparer);
        }

        [Fact]
        public void GetChristmas_January5_ReturnValue()
        {
            DateTime day = new DateTime(2024, 1, 5);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Jn 3:11-21", Gospel = "Jn 1:43-51" }.XUnitComparer);
        }

        [Fact]
        public void GetChristmas_January6_ReturnValue()
        {
            DateTime day = new DateTime(2024, 1, 6);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Jn 5:5-13", Gospel = "Mk 1:7-11" }.XUnitComparer);
        }

        [Fact]
        public void GetChristmas_January7_ReturnValue()
        {
            DateTime day = new DateTime(2023, 1, 7);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Jn 5:14-21", Gospel = "Jn 2:1-11" }.XUnitComparer);
        }

        [Fact]
        public void GetEphiphany_MondayAfter_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 5);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Jn 3:22—4:6", Gospel = "Mt 4:12-17, 23-25" }.XUnitComparer);
        }

        [Fact]
        public void GetEphiphany_TuesdayAfter_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 6);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Jn 4:7-10", Gospel = "Mk 6:34-44" }.XUnitComparer);
        }

        [Fact]
        public void GetEphiphany_WednesdayAfter_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 7);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Jn 4:11-18", Gospel = "Mk 6:45-52" }.XUnitComparer);
        }

        [Fact]
        public void GetEphiphany_ThursdayAfter_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 8);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Jn 4:19—5:4", Gospel = "Lk 4:14-22a" }.XUnitComparer);
        }

        [Fact]
        public void GetEphiphany_FridayAfter_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 9);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Jn 5:5-13", Gospel = "Lk 5:12-16" }.XUnitComparer);
        }

        [Fact]
        public void GetEphiphany_SaturdayAfter_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 10);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Jn 5:14-21", Gospel = "Jn 3:22-30" }.XUnitComparer);
        }

        #endregion
    }
}
