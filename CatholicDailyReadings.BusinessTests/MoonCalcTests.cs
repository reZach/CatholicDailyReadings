using CatholicDailyReadings.Business;

namespace CatholicDailyReadings.BusinessTests
{
    public class MoonCalcTests
    {
        private readonly MoonCalculator _moonCalc;

        public MoonCalcTests()
        {
            _moonCalc = new MoonCalculator();
        }

        [Fact]
        public void GetEaster_2021_ReturnApril4()
        {
            DateTime easter = _moonCalc.GetEaster(2021);
            DateTime expected = new DateTime(2021, 4, 4);

            Assert.Equal(easter, expected);
        }

        [Fact]
        public void GetEaster_2022_ReturnApril17()
        {
            DateTime easter = _moonCalc.GetEaster(2022);
            DateTime expected = new DateTime(2022, 4, 17);

            Assert.Equal(easter, expected);
        }

        [Fact]
        public void GetEaster_2023_ReturnApril9()
        {
            DateTime easter = _moonCalc.GetEaster(2023);
            DateTime expected = new DateTime(2023, 4, 9);

            Assert.Equal(easter, expected);
        }

        [Fact]
        public void GetEaster_2024_ReturnMarch31()
        {
            DateTime easter = _moonCalc.GetEaster(2024);
            DateTime expected = new DateTime(2024, 3, 31);

            Assert.Equal(easter, expected);
        }

        [Fact]
        public void GetEaster_2025_ReturnApril20()
        {
            DateTime easter = _moonCalc.GetEaster(2025);
            DateTime expected = new DateTime(2025, 4, 20);

            Assert.Equal(easter, expected);
        }

        [Fact]
        public void GetEaster_2026_ReturnApril5()
        {
            DateTime easter = _moonCalc.GetEaster(2026);
            DateTime expected = new DateTime(2026, 4, 5);

            Assert.Equal(easter, expected);
        }

        [Fact]
        public void GetLent_2021_ReturnFeburary17()
        {
            DateTime lent = _moonCalc.GetLent(2021);
            DateTime expected = new DateTime(2021, 2, 17);

            Assert.Equal(lent, expected);
        }

        [Fact]
        public void GetLent_2022_ReturnMarch2()
        {
            DateTime lent = _moonCalc.GetLent(2022);
            DateTime expected = new DateTime(2022, 3, 2);

            Assert.Equal(lent, expected);
        }

        [Fact]
        public void GetLent_2023_ReturnFebruary22()
        {
            DateTime lent = _moonCalc.GetLent(2023);
            DateTime expected = new DateTime(2023, 2, 22);

            Assert.Equal(lent, expected);
        }

        [Fact]
        public void GetLent_2024_ReturnFebruary14()
        {
            DateTime lent = _moonCalc.GetLent(2024);
            DateTime expected = new DateTime(2024, 2, 14);

            Assert.Equal(lent, expected);
        }

        [Fact]
        public void GetLent_2025_ReturnMarch5()
        {
            DateTime lent = _moonCalc.GetLent(2025);
            DateTime expected = new DateTime(2025, 3, 5);

            Assert.Equal(lent, expected);
        }

        [Fact]
        public void GetLent_2026_ReturnFebruary18()
        {
            DateTime lent = _moonCalc.GetLent(2026);
            DateTime expected = new DateTime(2026, 2, 18);

            Assert.Equal(lent, expected);
        }
    }
}