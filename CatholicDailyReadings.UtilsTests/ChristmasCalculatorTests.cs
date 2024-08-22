using CatholicDailyReadings.Utils;

namespace CatholicDailyReadings.UtilsTests
{
    public class ChristmasCalculatorTests
    {
        private readonly ChristmasCalculator _christmasCalculator;

        public ChristmasCalculatorTests()
        {
            _christmasCalculator = new ChristmasCalculator();
        }

        [Fact]
        public void Calculate_2021HolyFamily_ReturnSuccess()
        {
            DateTime holyFamily = _christmasCalculator.CalculateFeastOfTheHolyFamily(2021);
            DateTime expected = new DateTime(2021, 12, 26);

            Assert.Equal(holyFamily, expected);
        }

        [Fact]
        public void Calculate_2022HolyFamily_ReturnSuccess()
        {
            DateTime holyFamily = _christmasCalculator.CalculateFeastOfTheHolyFamily(2022);
            DateTime expected = new DateTime(2023, 1, 1);

            Assert.Equal(holyFamily, expected);
        }

        [Fact]
        public void Calculate_2023HolyFamily_ReturnSuccess()
        {
            DateTime holyFamily = _christmasCalculator.CalculateFeastOfTheHolyFamily(2023);
            DateTime expected = new DateTime(2023, 12, 31);

            Assert.Equal(holyFamily, expected);
        }

        [Fact]
        public void Calculate_2024HolyFamily_ReturnSuccess()
        {
            DateTime holyFamily = _christmasCalculator.CalculateFeastOfTheHolyFamily(2024);
            DateTime expected = new DateTime(2024, 12, 29);

            Assert.Equal(holyFamily, expected);
        }

        [Fact]
        public void Calculate_2025HolyFamily_ReturnSuccess()
        {
            DateTime holyFamily = _christmasCalculator.CalculateFeastOfTheHolyFamily(2025);
            DateTime expected = new DateTime(2025, 12, 28);

            Assert.Equal(holyFamily, expected);
        }

        [Fact]
        public void Calculate_2026HolyFamily_ReturnSuccess()
        {
            DateTime holyFamily = _christmasCalculator.CalculateFeastOfTheHolyFamily(2026);
            DateTime expected = new DateTime(2026, 12, 27);

            Assert.Equal(holyFamily, expected);
        }

        [Fact]
        public void Calculate_2021Ephiphany_ReturnSuccess()
        {
            DateTime ephiphany = _christmasCalculator.CalculateEphiphanyOfOurLord(2021);
            DateTime expected = new DateTime(2021, 1, 3);

            Assert.Equal(ephiphany, expected);
        }

        [Fact]
        public void Calculate_2022Ephiphany_ReturnSuccess()
        {
            DateTime ephiphany = _christmasCalculator.CalculateEphiphanyOfOurLord(2022);
            DateTime expected = new DateTime(2022, 1, 2);

            Assert.Equal(ephiphany, expected);
        }

        [Fact]
        public void Calculate_2023Ephiphany_ReturnSuccess()
        {
            DateTime ephiphany = _christmasCalculator.CalculateEphiphanyOfOurLord(2023);
            DateTime expected = new DateTime(2023, 1, 8);

            Assert.Equal(ephiphany, expected);
        }

        [Fact]
        public void Calculate_2024Ephiphany_ReturnSuccess()
        {
            DateTime ephiphany = _christmasCalculator.CalculateEphiphanyOfOurLord(2024);
            DateTime expected = new DateTime(2024, 1, 7);

            Assert.Equal(ephiphany, expected);
        }

        [Fact]
        public void Calculate_2025Ephiphany_ReturnSuccess()
        {
            DateTime ephiphany = _christmasCalculator.CalculateEphiphanyOfOurLord(2025);
            DateTime expected = new DateTime(2025, 1, 5);

            Assert.Equal(ephiphany, expected);
        }

        [Fact]
        public void Calculate_2026Ephiphany_ReturnSuccess()
        {
            DateTime ephiphany = _christmasCalculator.CalculateEphiphanyOfOurLord(2026);
            DateTime expected = new DateTime(2026, 1, 4);

            Assert.Equal(ephiphany, expected);
        }

        [Fact]
        public void Calculate_2021Baptism_ReturnSuccess()
        {
            DateTime baptism = _christmasCalculator.CalculateBaptismOfTheLord(2021);
            DateTime expected = new DateTime(2021, 1, 10);

            Assert.Equal(baptism, expected);
        }

        [Fact]
        public void Calculate_2022Baptism_ReturnSuccess()
        {
            DateTime baptism = _christmasCalculator.CalculateBaptismOfTheLord(2022);
            DateTime expected = new DateTime(2022, 1, 9);

            Assert.Equal(baptism, expected);
        }

        [Fact]
        public void Calculate_2023Baptism_ReturnSuccess()
        {
            DateTime baptism = _christmasCalculator.CalculateBaptismOfTheLord(2023);
            DateTime expected = new DateTime(2023, 1, 9);

            Assert.Equal(baptism, expected);
        }

        [Fact]
        public void Calculate_2024Baptism_ReturnSuccess()
        {
            DateTime baptism = _christmasCalculator.CalculateBaptismOfTheLord(2024);
            DateTime expected = new DateTime(2024, 1, 8);

            Assert.Equal(baptism, expected);
        }

        [Fact]
        public void Calculate_2025Baptism_ReturnSuccess()
        {
            DateTime baptism = _christmasCalculator.CalculateBaptismOfTheLord(2025);
            DateTime expected = new DateTime(2025, 1, 12);

            Assert.Equal(baptism, expected);
        }

        [Fact]
        public void Calculate_2026Baptism_ReturnSuccess()
        {
            DateTime baptism = _christmasCalculator.CalculateBaptismOfTheLord(2026);
            DateTime expected = new DateTime(2026, 1, 11);

            Assert.Equal(baptism, expected);
        }
    }
}
