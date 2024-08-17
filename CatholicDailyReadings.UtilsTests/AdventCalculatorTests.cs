using CatholicDailyReadings.Utils;

namespace CatholicDailyReadings.UtilsTests
{
    public class AdventCalculatorTests
    {
        private readonly AdventCalculator _adventCalculator;

        public AdventCalculatorTests()
        {
            _adventCalculator = new AdventCalculator();
        }

        [Fact]
        public void Calculate_2021_ReturnNovember28()
        {
            DateTime advent = _adventCalculator.Calculate(2021);
            DateTime expected = new DateTime(2021, 11, 28);

            Assert.Equal(advent, expected);
        }

        [Fact]
        public void Calculate_2022_ReturnNovember27()
        {
            DateTime advent = _adventCalculator.Calculate(2022);
            DateTime expected = new DateTime(2022, 11, 27);

            Assert.Equal(advent, expected);
        }

        [Fact]
        public void Calculate_2023_ReturnDecember3()
        {
            DateTime advent = _adventCalculator.Calculate(2023);
            DateTime expected = new DateTime(2023, 12, 3);

            Assert.Equal(advent, expected);
        }

        [Fact]
        public void Calculate_2024_ReturnDecember1()
        {
            DateTime advent = _adventCalculator.Calculate(2024);
            DateTime expected = new DateTime(2024, 12, 1);

            Assert.Equal(advent, expected);
        }

        [Fact]
        public void Calculate_2025_ReturnNovember30()
        {
            DateTime advent = _adventCalculator.Calculate(2025);
            DateTime expected = new DateTime(2025, 11, 30);

            Assert.Equal(advent, expected);
        }

        [Fact]
        public void Calculate_2026_ReturnNovember29()
        {
            DateTime advent = _adventCalculator.Calculate(2026);
            DateTime expected = new DateTime(2026, 11, 29);

            Assert.Equal(advent, expected);
        }
    }
}