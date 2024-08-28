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

        #region Ordinary Time

        [Fact]
        public void GetOrdinaryTime_PresentationOfTheLord_ReturnValue()
        {
            DateTime day = new DateTime(2026, 2, 2);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Mal 3:1-4", SecondReading = "Heb 2:14-18", Gospel = "Lk 2:22-40" }.XUnitComparer);
        }

        #region Cycle 1

        [Fact]
        public void GetOrdinaryTimeCycle1_Week1Monday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 1, 10);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Heb 1:1-6", Gospel = "Mk 1:14-22" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week1Tuesday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 1, 11);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Heb 2:5-12", Gospel = "Mk 1:21-28" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week1Wednesday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 1, 12);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Heb 2:14-18", Gospel = "Mk 1:29-39" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week1Thursday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 1, 13);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Heb 3:7-14", Gospel = "Mk 1:40-45" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week1Friday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 1, 14);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Heb 4:1-5, 11", Gospel = "Mk 2:1-12" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week1Saturday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 1, 15);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Heb 4:12-16", Gospel = "Mk 2:13-17" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1YearA_Week2Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 1, 16);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 49:3, 5-6", SecondReading = "1 Cor 1:1-3", Gospel = "Jn 1:29-34" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1YearB_Week2Sunday_ReturnValue()
        {
            DateTime day = new DateTime(1943, 1, 17);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Sm 3:3b-10, 19", SecondReading = "1 Cor 6:13c-15a, 17-20", Gospel = "Jn 1:35-42" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1YearC_Week2Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2049, 1, 17);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 62:1-5", SecondReading = "1 Cor 12:4-11", Gospel = "Jn 2:1-11" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week2Monday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 1, 17);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Heb 5:1-10", Gospel = "Mk 2:18-22" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week2Tuesday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 1, 18);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Heb 6:10-20", Gospel = "Mk 2:23-28" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week2Wednesday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 1, 19);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Heb 7:1-3, 15-17", Gospel = "Mk 3:1-6" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week2Thursday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 1, 20);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Heb 7:25—8:6", Gospel = "Mk 3:7-12" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week2Friday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 1, 21);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Heb 8:6-13", Gospel = "Mk 3:13-19" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week2Saturday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 1, 22);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Heb 9:2-3, 11-14", Gospel = "Mk 3:20-21" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1YearA_Week3Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 1, 23);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 8:23—9:3", SecondReading = "1 Cor 1:10-13, 17", Gospel = "Mt 4:12-23" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1YearB_Week3Sunday_ReturnValue()
        {
            DateTime day = new DateTime(1943, 1, 24);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jon 3:1-5, 10", SecondReading = "1 Cor 7:29-31", Gospel = "Mk 1:14-20" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1YearC_Week3Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2049, 1, 24);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Neh 8:2-4a, 5-6, 8-10", SecondReading = "1 Cor 12:12-30", Gospel = "Lk 1:1-4; 4:14-21" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week3Monday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 1, 24);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Heb 9:15, 24-28", Gospel = "Mk 3:22-30" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week3Tuesday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 1, 25);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Heb 10:1-10", Gospel = "Mk 3:31-35" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week3Wednesday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 1, 26);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Heb 10:11-18", Gospel = "Mk 4:1-22" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week3Thursday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 1, 27);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Heb 10:19-25", Gospel = "Mk 4:21-25" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week3Friday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 1, 28);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Heb 10:32-39", Gospel = "Mk 4:26-34" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week3Saturday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 1, 29);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Heb 11:1-2, 8-19", Gospel = "Mk 4:35-41" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1YearA_Week4Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 1, 30);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Zep 2:3; 3:12-13", SecondReading = "1 Cor 1:26-31", Gospel = "Mt 5:1-12a" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1YearB_Week4Sunday_ReturnValue()
        {
            DateTime day = new DateTime(1943, 1, 31);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Dt 18:15-20", SecondReading = "1 Cor 7:32-35", Gospel = "Mk 1:21-28" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1YearC_Week4Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2049, 1, 31);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jer 1:4-5, 17-19", SecondReading = "1 Cor 12:31—13:13", Gospel = "Lk 4:21-30" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week4Monday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 1, 31);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Heb 11:32-40", Gospel = "Mk 5:1-22" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week4Tuesday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 1);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Heb 12:1-4", Gospel = "Mk 5:21-43" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week4Wednesday_ReturnValue()
        {
            DateTime day = new DateTime(1981, 2, 4);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Heb 12:4-7, 11-15", Gospel = "Mk 6:1-6" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week4Thursday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 3);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Heb 12:18-19, 21-24", Gospel = "Mk 6:7-13" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week4Friday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 4);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Heb 13:1-8", Gospel = "Mk 6:14-29" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week4Saturday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 5);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Heb 13:15-17, 20-21", Gospel = "Mk 6:30-34" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1YearA_Week5Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 6);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 58:7-10", SecondReading = "1 Cor 2:1-5", Gospel = "Mt 5:13-16" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1YearB_Week5Sunday_ReturnValue()
        {
            DateTime day = new DateTime(1943, 2, 7);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jb 7:1-4, 6-7", SecondReading = "1 Cor 9:16-19, 22-23", Gospel = "Mk 1:29-39" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1YearC_Week5Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2049, 2, 7);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 6:1-2a, 3-8", SecondReading = "1 Cor 15:1-11", Gospel = "Lk 5:1-11" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week5Monday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 7);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Gn 1:1-19", Gospel = "Mk 6:53-56" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week5Tuesday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 8);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Gn 1:20—2:4a", Gospel = "Mk 7:1-13" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week5Wednesday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 9);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Gn 2:4b-9, 15-17", Gospel = "Mk 7:14-23" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week5Thursday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 10);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Gn 2:18-25", Gospel = "Mk 7:24-30" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week5Friday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 11);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Gn 3:1-8", Gospel = "Mk 7:31-37" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week5Saturday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 12);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Gn 3:9-24", Gospel = "Mk 8:1-10" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1YearA_Week6Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 13);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Sir 15:16-21", SecondReading = "1 Cor 2:6-10", Gospel = "Mt 5:17-37" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1YearB_Week6Sunday_ReturnValue()
        {
            DateTime day = new DateTime(1943, 2, 14);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Lv 13:1-2, 44-46", SecondReading = "1 Cor 10:31—11:1", Gospel = "Mk 1:40-45" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1YearC_Week6Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2049, 2, 14);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jer 17:5-8", SecondReading = "1 Cor 15:12, 16-20", Gospel = "Lk 6:17, 20-26" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week6Monday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 14);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Gn 4:1-15, 25", Gospel = "Mk 8:11-13" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week6Tuesday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 15);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Gn 6:5-8; 7:1-5, 10", Gospel = "Mk 8:14-21" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week6Wednesday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 16);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Gn 8:6-13, 20-22", Gospel = "Mk 8:22-26" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week6Thursday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 17);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Gn 9:1-13", Gospel = "Mk 8:27-33" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week6Friday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 18);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Gn 11:1-9", Gospel = "Mk 8:34—9:1" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week6Saturday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 19);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Heb 11:1-7", Gospel = "Mk 9:2-13" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1YearA_Week7Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 20);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Lv 19:1-2, 17-18", SecondReading = "1 Cor 3:16-23", Gospel = "Mt 5:38-48" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1YearB_Week7Sunday_ReturnValue()
        {
            DateTime day = new DateTime(1943, 2, 21);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 43:18-19, 21-22, 24b-25", SecondReading = "2 Cor 1:18-22", Gospel = "Mk 2:1-12" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1YearC_Week7Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2049, 2, 21);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Sm 26:2, 7-9, 12-13, 22-23", SecondReading = "1 Cor 15:45-49", Gospel = "Lk 6:27-38" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week7Monday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 21);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Sir 1:1-10", Gospel = "Mk 9:14-29" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week7Tuesday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 22);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Sir 2:1-11", Gospel = "Mk 9:30-37" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week7Wednesday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 23);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Sir 4:11-19", Gospel = "Mk 9:38-40" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week7Thursday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 24);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Sir 5:1-8", Gospel = "Mk 9:41-50" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week7Friday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 25);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Sir 6:5-17", Gospel = "Mk 10:1-12" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week7Saturday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 26);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Sir 17:1-15", Gospel = "Mk 10:13-16" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1YearA_Week8Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 27);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 49:14-15", SecondReading = "1 Cor 4:1-5", Gospel = "Mt 6:24-34" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1YearB_Week8Sunday_ReturnValue()
        {
            DateTime day = new DateTime(1943, 2, 28);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Hos 2:16b, 17b, 21-22", SecondReading = "2 Cor 3:1b-6", Gospel = "Mk 2:18-22" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1YearC_Week8Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2049, 2, 28);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Sir 27:5-8", SecondReading = "1 Cor 15:54-58", Gospel = "Lk 6:39-45" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week8Monday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 2, 28);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Sir 17:20-24", Gospel = "Mk 10:17-27" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week8Tuesday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 3, 1);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Sir 35:1-12", Gospel = "Mk 10:28-31" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week8Wednesday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 3, 2);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Sir 36:1, 4-5a, 10-17", Gospel = "Mk 10:32-45" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week8Thursday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 3, 3);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Sir 42:15-25", Gospel = "Mk 10:46-52" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week8Friday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 3, 4);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Sir 44:1, 9-13", Gospel = "Mk 11:11-26" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week8Saturday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 3, 5);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Sir 51:12cd-20", Gospel = "Mk 11:27-33" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1YearA_Week9Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 3, 6);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Dt 11:18, 26-28, 32", SecondReading = "Rom 3:21-25, 28", Gospel = "Mt 7:21-27" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1YearB_Week9Sunday_ReturnValue()
        {
            DateTime day = new DateTime(1943, 3, 7);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Dt 5:12-15", SecondReading = "2 Cor 4:6-11", Gospel = "Mk 2:23—3:6" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1YearC_Week9Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2049, 3, 7);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Kgs 8:41-43", SecondReading = "Gal 1:1-2, 6-10", Gospel = "Lk 7:1-10" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week9Monday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 3, 7);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Tb 1:3; 2:1a-8", Gospel = "Mk 12:1-12" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle1_Week9Tuesday_ReturnValue()
        {
            DateTime day = new DateTime(2011, 3, 8);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Tb 2:9-14", Gospel = "Mk 12:13-17" }.XUnitComparer);
        }

        #endregion

        #region Cycle 2        

        [Fact]
        public void GetOrdinaryTimeCycle2_Week1Monday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 12);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Sm 1:1-8", Gospel = "Mk 1:14-22" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week1Tuesday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 13);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Sm 1:9-22", Gospel = "Mk 1:21-28" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week1Wednesday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 14);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Sm 3:1-10, 19-22", Gospel = "Mk 1:29-39" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week1Thursday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 15);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Sm 4:1-11", Gospel = "Mk 1:40-45" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week1Friday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 16);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Sm 8:4-7, 10-22a", Gospel = "Mk 2:1-12" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week1Saturday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 17);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Sm 9:1-4, 17-19; 10:1", Gospel = "Mk 2:13-17" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2YearA_Week2Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 18);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 49:3, 5-6", SecondReading = "1 Cor 1:1-3", Gospel = "Jn 1:29-34" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2YearB_Week2Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2024, 1, 14);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Sm 3:3b-10, 19", SecondReading = "1 Cor 6:13c-15a, 17-20", Gospel = "Jn 1:35-42" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2YearC_Week2Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2022, 1, 16);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 62:1-5", SecondReading = "1 Cor 12:4-11", Gospel = "Jn 2:1-11" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week2Monday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 19);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Sm 15:16-23", Gospel = "Mk 2:18-22" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week2Tuesday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 20);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Sm 16:1-13", Gospel = "Mk 2:23-28" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week2Wednesday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 21);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Sm 17:32-33, 37, 40-51", Gospel = "Mk 3:1-6" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week2Thursday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 22);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Sm 18:6-9; 19:1-7", Gospel = "Mk 3:7-12" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week2Friday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 23);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Sm 24:3-21", Gospel = "Mk 3:13-19" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week2Saturday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 24);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "2 Sm 1:1-4, 11-12, 19, 23-27", Gospel = "Mk 3:20-21" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2YearA_Week3Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 25);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 8:23—9:3", SecondReading = "1 Cor 1:10-13, 17", Gospel = "Mt 4:12-23" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2YearB_Week3Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2024, 1, 21);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jon 3:1-5, 10", SecondReading = "1 Cor 7:29-31", Gospel = "Mk 1:14-20" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2YearC_Week3Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2022, 1, 23);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Neh 8:2-4a, 5-6, 8-10", SecondReading = "1 Cor 12:12-30", Gospel = "Lk 1:1-4; 4:14-21" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week3Monday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 26);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "2 Sm 5:1-7, 10", Gospel = "Mk 3:22-30" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week3Tuesday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 27);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "2 Sm 6:12b-15, 17-19", Gospel = "Mk 3:31-35" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week3Wednesday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 28);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "2 Sm 7:4-17", Gospel = "Mk 4:1-22" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week3Thursday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 29);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "2 Sm 7:18-19, 24-29", Gospel = "Mk 4:21-25" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week3Friday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 30);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "2 Sm 11:1-4a, 5-10a, 13-17", Gospel = "Mk 4:26-34" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week3Saturday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 1, 31);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "2 Sm 12:1-7a, 10-17", Gospel = "Mk 4:35-41" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2YearA_Week4Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 2, 1);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Zep 2:3; 3:12-13", SecondReading = "1 Cor 1:26-31", Gospel = "Mt 5:1-12a" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2YearB_Week4Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2024, 1, 28);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Dt 18:15-20", SecondReading = "1 Cor 7:32-35", Gospel = "Mk 1:21-28" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2YearC_Week4Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2022, 1, 30);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jer 1:4-5, 17-19", SecondReading = "1 Cor 12:31—13:13", Gospel = "Lk 4:21-30" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week4Monday_ReturnValue()
        {
            DateTime day = new DateTime(2024, 1, 29);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "2 Sm 15:13-14, 30; 16:5-13", Gospel = "Mk 5:1-22" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week4Tuesday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 2, 3);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "2 Sm 18:9-10, 14b, 24-25a, 30—19:3", Gospel = "Mk 5:21-43" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week4Wednesday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 2, 4);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "2 Sm 24:2, 9-17", Gospel = "Mk 6:1-6" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week4Thursday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 2, 5);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Kgs 2:1-4, 10-12", Gospel = "Mk 6:7-13" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week4Friday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 2, 6);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Sir 47:2-11", Gospel = "Mk 6:14-29" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week4Saturday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 2, 7);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Kgs 3:4-13", Gospel = "Mk 6:30-34" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2YearA_Week5Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 2, 8);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 58:7-10", SecondReading = "1 Cor 2:1-5", Gospel = "Mt 5:13-16" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2YearB_Week5Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2024, 2, 4);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jb 7:1-4, 6-7", SecondReading = "1 Cor 9:16-19, 22-23", Gospel = "Mk 1:29-39" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2YearC_Week5Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2022, 2, 6);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 6:1-2a, 3-8", SecondReading = "1 Cor 15:1-11", Gospel = "Lk 5:1-11" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week5Monday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 2, 9);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Kgs 8:1-7, 9-13", Gospel = "Mk 6:53-56" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week5Tuesday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 2, 10);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Kgs 8:22-23, 27-30", Gospel = "Mk 7:1-13" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week5Wednesday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 2, 11);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Kgs 10:1-10", Gospel = "Mk 7:14-23" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week5Thursday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 2, 12);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Kgs 11:4-13", Gospel = "Mk 7:24-30" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week5Friday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 2, 13);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Kgs 11:29-32; 12:19", Gospel = "Mk 7:31-37" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week5Saturday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 2, 14);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Kgs 12:26-32; 13:33-34", Gospel = "Mk 8:1-10" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2YearA_Week6Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 2, 15);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Sir 15:16-21", SecondReading = "1 Cor 2:6-10", Gospel = "Mt 5:17-37" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2YearB_Week6Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2024, 2, 11);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Lv 13:1-2, 44-46", SecondReading = "1 Cor 10:31—11:1", Gospel = "Mk 1:40-45" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2YearC_Week6Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2022, 2, 13);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jer 17:5-8", SecondReading = "1 Cor 15:12, 16-20", Gospel = "Lk 6:17, 20-26" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week6Monday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 2, 16);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jas 1:1-11", Gospel = "Mk 8:11-13" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week6Tuesday_ReturnValue()
        {
            DateTime day = new DateTime(2026, 2, 17);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jas 1:12-18", Gospel = "Mk 8:14-21" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week6Wednesday_ReturnValue()
        {
            // 2038 is one of the years (A) that ordinary time prior to
            // Lent lasts over 8 weeks, so we will use these dates
            // for checks going forwards as needed.
            // 2000 will be used for year B
            // 2076 will be used for year C
            DateTime day = new DateTime(2038, 2, 17);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jas 1:19-27", Gospel = "Mk 8:22-26" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week6Thursday_ReturnValue()
        {
            DateTime day = new DateTime(2038, 2, 18);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jas 2:1-9", Gospel = "Mk 8:27-33" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week6Friday_ReturnValue()
        {
            DateTime day = new DateTime(2038, 2, 19);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jas 2:14-24, 26", Gospel = "Mk 8:34—9:1" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week6Saturday_ReturnValue()
        {
            DateTime day = new DateTime(2038, 2, 20);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jas 3:1-10", Gospel = "Mk 9:2-13" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2YearA_Week7Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2038, 2, 21);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Lv 19:1-2, 17-18", SecondReading = "1 Cor 3:16-23", Gospel = "Mt 5:38-48" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2YearB_Week7Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2000, 2, 20);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 43:18-19, 21-22, 24b-25", SecondReading = "2 Cor 1:18-22", Gospel = "Mk 2:1-12" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2YearC_Week7Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2076, 2, 23);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Sm 26:2, 7-9, 12-13, 22-23", SecondReading = "1 Cor 15:45-49", Gospel = "Lk 6:27-38" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week7Monday_ReturnValue()
        {
            DateTime day = new DateTime(2038, 2, 22);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jas 3:13-18", Gospel = "Mk 9:14-29" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week7Tuesday_ReturnValue()
        {
            DateTime day = new DateTime(2038, 2, 23);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jas 4:1-10", Gospel = "Mk 9:30-37" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week7Wednesday_ReturnValue()
        {
            DateTime day = new DateTime(2038, 2, 24);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jas 4:13-17", Gospel = "Mk 9:38-40" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week7Thursday_ReturnValue()
        {
            DateTime day = new DateTime(2038, 2, 25);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jas 5:1-6", Gospel = "Mk 9:41-50" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week7Friday_ReturnValue()
        {
            DateTime day = new DateTime(2038, 2, 26);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jas 5:9-12", Gospel = "Mk 10:1-12" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week7Saturday_ReturnValue()
        {
            DateTime day = new DateTime(2038, 2, 27);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jas 5:13-22", Gospel = "Mk 10:13-16" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2YearA_Week8Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2038, 2, 28);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 49:14-15", SecondReading = "1 Cor 4:1-5", Gospel = "Mt 6:24-34" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2YearB_Week8Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2000, 2, 27);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Hos 2:16b, 17b, 21-22", SecondReading = "2 Cor 3:1b-6", Gospel = "Mk 2:18-22" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2YearC_Week8Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2076, 3, 1);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Sir 27:5-8", SecondReading = "1 Cor 15:54-58", Gospel = "Lk 6:39-45" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week8Monday_ReturnValue()
        {
            DateTime day = new DateTime(2038, 3, 1);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Pt 1:3-9", Gospel = "Mk 10:17-27" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week8Tuesday_ReturnValue()
        {
            DateTime day = new DateTime(2038, 3, 2);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Pt 1:10-16", Gospel = "Mk 10:28-31" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week8Wednesday_ReturnValue()
        {
            DateTime day = new DateTime(2038, 3, 3);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Pt 1:18-25", Gospel = "Mk 10:32-45" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week8Thursday_ReturnValue()
        {
            DateTime day = new DateTime(2038, 3, 4);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Pt 2:2-5, 9-12", Gospel = "Mk 10:46-52" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week8Friday_ReturnValue()
        {
            DateTime day = new DateTime(2038, 3, 5);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Pt 4:7-13", Gospel = "Mk 11:11-26" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week8Saturday_ReturnValue()
        {
            DateTime day = new DateTime(2038, 3, 6);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jude 17, 20b-25", Gospel = "Mk 11:27-33" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2YearA_Week9Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2038, 3, 7);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Dt 11:18, 26-28, 32", SecondReading = "Rom 3:21-25, 28", Gospel = "Mt 7:21-27" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2YearB_Week9Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2000, 3, 5);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Dt 5:12-15", SecondReading = "2 Cor 4:6-11", Gospel = "Mk 2:23—3:6" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2YearC_Week9Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2076, 3, 8);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Kgs 8:41-43", SecondReading = "Gal 1:1-2, 6-10", Gospel = "Lk 7:1-10" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week9Monday_ReturnValue()
        {
            DateTime day = new DateTime(2038, 3, 8);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "2 Pt 1:2-7", Gospel = "Mk 12:1-12" }.XUnitComparer);
        }

        [Fact]
        public void GetOrdinaryTimeCycle2_Week9Tuesday_ReturnValue()
        {
            DateTime day = new DateTime(2038, 3, 9);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "2 Pt 3:12-15a, 17-18", Gospel = "Mk 12:13-17" }.XUnitComparer);
        }

        #endregion

        #endregion

        [Fact]
        public void GetStJosephFeastDay_NotSunday_ReturnValue()
        {
            DateTime day = new DateTime(2024, 3, 19);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "2 Sm 7:4-5a, 12-14a, 16", SecondReading = "Rom 4:13, 16-18, 22", Gospel = "Mt 1:16, 18-21, 24a" }.XUnitComparer);
        }

        [Fact]
        public void GetStJosephFeastDay_Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2017, 3, 20);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "2 Sm 7:4-5a, 12-14a, 16", SecondReading = "Rom 4:13, 16-18, 22", Gospel = "Mt 1:16, 18-21, 24a" }.XUnitComparer);
        }

        #region Lent

        [Fact]
        public void GetLent_AshWednesday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 3, 5);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jl 2:12-18", Gospel = "Mt 6:1-6, 16-18" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_AshWednesday1DayAfter_ReturnValue()
        {
            DateTime day = new DateTime(2025, 3, 6);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Dt 30:15-20", Gospel = "Lk 9:22-25" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_AshWednesday2DayAfter_ReturnValue()
        {
            DateTime day = new DateTime(2025, 3, 7);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 58:1-9a", Gospel = "Mt 9:14-15" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_AshWednesday3DayAfter_ReturnValue()
        {
            DateTime day = new DateTime(2025, 3, 8);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 58:9b-14", Gospel = "Lk 5:27-32" }.XUnitComparer);
        }

        [Fact]
        public void GetLentYearA_Week1Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2023, 2, 26);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Gn 2:7-9; 3:1-7", SecondReading = "Rom 5:12-19", Gospel = "Mt 4:1-11" }.XUnitComparer);
        }

        [Fact]
        public void GetLentYearB_Week1Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2024, 2, 18);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Gn 9:8-15", SecondReading = "1 Pt 3:18-22", Gospel = "Mk 1:12-15" }.XUnitComparer);
        }

        [Fact]
        public void GetLentYearC_Week1Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 3, 9);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Dt 26:4-10", SecondReading = "Rom 10:8-13", Gospel = "Lk 4:1-13" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week1Monday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 3, 10);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Lv 19:1-2, 11-18", Gospel = "Mt 25:31-46" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week1Tuesday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 3, 11);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 55:10-11", Gospel = "Mt 6:7-15" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week1Wednesday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 3, 12);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jon 3:1-10", Gospel = "Lk 11:29-32" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week1Thursday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 3, 13);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Est C:12, 14-16, 23-25", Gospel = "Mt 7:7-12" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week1Friday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 3, 14);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Ez 18:21-28", Gospel = "Mt 5:20-26" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week1Saturday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 3, 15);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Dt 26:16-19", Gospel = "Mt 5:43-48" }.XUnitComparer);
        }

        [Fact]
        public void GetLentYearA_Week2Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2023, 3, 5);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Gn 12:1-4a", SecondReading = "2 Tm 1:8b-10", Gospel = "Mt 17:1-9" }.XUnitComparer);
        }

        [Fact]
        public void GetLentYearB_Week2Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2024, 2, 25);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Gn 22:1-2, 9a, 10-13, 15-18", SecondReading = "Rom 8:31b-34", Gospel = "Mk 9:2-10" }.XUnitComparer);
        }

        [Fact]
        public void GetLentYearC_Week2Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 3, 16);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Gn 15:5-12, 17-18", SecondReading = "Phil 3:17–4:1", Gospel = "Lk 9:28b-36" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week2Monday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 3, 17);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Dn 9:4b-10", Gospel = "Lk 6:36-38" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week2Tuesday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 3, 18);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 1:10, 16-20", Gospel = "Mt 23:1-12" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week2Wednesday_ReturnValue()
        {
            DateTime day = new DateTime(2024, 2, 28);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jer 18:18-20", Gospel = "Mt 20:17-28" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week2Thursday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 3, 20);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jer 17:5-10", Gospel = "Lk 16:19-31" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week2Friday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 3, 21);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Gn 37:3-4, 12-13a, 17b-28a", Gospel = "Mt 21:33-43, 45-46" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week2Saturday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 3, 22);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Mi 7:14-15, 18-20", Gospel = "Lk 15:1-3, 11-32" }.XUnitComparer);
        }

        [Fact]
        public void GetLentYearA_Week3Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2023, 3, 12);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Ex 17:3-7", SecondReading = "Rom 5:1-2, 5-8", Gospel = "Jn 4:5-42" }.XUnitComparer);
        }

        [Fact]
        public void GetLentYearB_Week3Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2024, 3, 3);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Ex 20:1-17", SecondReading = "1 Cor 1:22-25", Gospel = "Jn 2:13-25" }.XUnitComparer);
        }

        [Fact]
        public void GetLentYearC_Week3Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 3, 23);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Ex 3:1-8a, 13-15", SecondReading = "1 Cor 10:1-6, 10-12", Gospel = "Lk 13:1-9" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week3Monday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 3, 24);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "2 Kgs 5:1-15a", Gospel = "Lk 4:24-30" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week3Tuesday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 3, 25);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Dn 3:25, 34-43", Gospel = "Mt 18:21-35" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week3Wednesday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 3, 26);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Dt 4:1, 5-9", Gospel = "Mt 5:17-19" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week3Thursday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 3, 27);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jer 7:23-28", Gospel = "Lk 11:14-23" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week3Friday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 3, 28);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Hos 14:2-10", Gospel = "Mk 12:28b-34" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week3Saturday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 3, 29);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Hos 6:1-6", Gospel = "Lk 18:9-14" }.XUnitComparer);
        }

        [Fact]
        public void GetLentYearA_Week4Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2023, 3, 19);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "1 Sm 16:1b, 6-7, 10-13a", SecondReading = "Eph 5:8-14", Gospel = "Jn 9:1-41" }.XUnitComparer);
        }

        [Fact]
        public void GetLentYearB_Week4Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2024, 3, 10);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "2 Chr 36:14-16, 19-23", SecondReading = "Eph 2:4-10", Gospel = "Jn 3:14-21" }.XUnitComparer);
        }

        [Fact]
        public void GetLentYearC_Week4Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 3, 30);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jos 5:9a, 10-12", SecondReading = "2 Cor 5:17-21", Gospel = "Lk 15:1-3, 11-32" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week4Monday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 3, 31);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 65:17-21", Gospel = "Jn 4:43-54" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week4Tuesday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 4, 1);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Ez 47:1-9, 12", Gospel = "Jn 5:1-3a, 5-16" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week4Wednesday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 4, 2);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 49:8-15", Gospel = "Jn 5:17-30" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week4Thursday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 4, 3);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Ex 32:7-14", Gospel = "Jn 5:31-47" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week4Friday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 4, 4);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Wis 2:1a, 12-22", Gospel = "Jn 7:1-2, 10, 25-30" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week4Saturday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 4, 5);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jer 11:18-20", Gospel = "Jn 7:40-53" }.XUnitComparer);
        }

        [Fact]
        public void GetLentYearA_Week5Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2023, 3, 26);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Ez 37:12-14", SecondReading = "Rom 8:8-11", Gospel = "Jn 11:1-45" }.XUnitComparer);
        }

        [Fact]
        public void GetLentYearB_Week5Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2024, 3, 17);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jer 31:31-34", SecondReading = "Heb 5:7-9", Gospel = "Jn 12:20-33" }.XUnitComparer);
        }

        [Fact]
        public void GetLentYearC_Week5Sunday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 4, 6);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 43:16-21", SecondReading = "Phil 3:8-14", Gospel = "Jn 8:1-11" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week5Monday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 4, 7);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Dn 13:1-9, 15-17, 19-30, 33-62", Gospel = "Jn 8:1-11" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week5Tuesday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 4, 8);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Nm 21:4-9", Gospel = "Jn 8:21-30" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week5Wednesday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 4, 9);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Dn 3:14-20, 91-92, 95", Gospel = "Jn 8:31-42" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week5Thursday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 4, 10);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Gn 17:3-9", Gospel = "Jn 8:51-59" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week5Friday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 4, 11);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Jer 20:10-13", Gospel = "Jn 10:31-42" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_Week5Saturday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 4, 12);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Ez 37:21-28", Gospel = "Jn 11:45-56" }.XUnitComparer);
        }

        [Fact]
        public void GetLentYearA_PalmSunday_ReturnValue()
        {
            DateTime day = new DateTime(2023, 4, 2);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.A, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 50:4-7", SecondReading = "Phil 2:6-11", Gospel = "Mt 26:14 – 27:66" }.XUnitComparer);
        }

        [Fact]
        public void GetLentYearB_PalmSunday_ReturnValue()
        {
            DateTime day = new DateTime(2024, 3, 24);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.B, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 50:4-7", SecondReading = "Phil 2:6-11", Gospel = "Mk 14:1 – 15:47" }.XUnitComparer);
        }

        [Fact]
        public void GetLentYearC_PalmSunday_ReturnValue()
        {
            DateTime day = new DateTime(2025, 4, 13);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(Models.Enums.Year.C, reading.Year);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 50:4-7", SecondReading = "Phil 2:6-11", Gospel = "Lk 22:14 – 23:56" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_PalmSundayMondayAfter_ReturnValue()
        {
            DateTime day = new DateTime(2025, 4, 14);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 42:1-7", Gospel = "Jn 12:1-11" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_PalmSundayTuesdayAfter_ReturnValue()
        {
            DateTime day = new DateTime(2025, 4, 15);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 49:1-6", Gospel = "Jn 13:21-33, 36-38" }.XUnitComparer);
        }

        [Fact]
        public void GetLent_PalmSundayWednesdayAfter_ReturnValue()
        {
            DateTime day = new DateTime(2025, 4, 16);
            DailyReading? reading = _bibleProvider.GetDailyReading(day);

            Assert.NotNull(reading);
            Assert.Equal(reading.XUnitComparer, new DailyReading { FirstReading = "Is 50:4-9a", Gospel = "Mt 26:14-25" }.XUnitComparer);
        }

        #endregion

    }
}
