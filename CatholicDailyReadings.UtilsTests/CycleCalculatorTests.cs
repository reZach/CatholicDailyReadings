using CatholicDailyReadings.Models.Enums;
using CatholicDailyReadings.Utils;

namespace CatholicDailyReadings.UtilsTests
{
    public class CycleCalculatorTests
    {
        private readonly CycleCalculator _cycleCalculator;

        public CycleCalculatorTests()
        {
            _cycleCalculator = new CycleCalculator();
        }

        [Fact]
        public void CalculateYear_2021_ReturnB()
        {
            Year year = _cycleCalculator.CalculateYear(new DateTime(2021, 12, 25));
            Year expected = Year.B;

            Assert.Equal(year, expected);
        }

        [Fact]
        public void CalculateYear_2022_ReturnC()
        {
            Year year = _cycleCalculator.CalculateYear(new DateTime(2022, 12, 25));
            Year expected = Year.C;

            Assert.Equal(year, expected);
        }

        [Fact]
        public void CalculateYear_2023_ReturnA()
        {
            Year year = _cycleCalculator.CalculateYear(new DateTime(2023, 12, 25));
            Year expected = Year.A;

            Assert.Equal(year, expected);
        }

        [Fact]
        public void CalculateYear_2024_ReturnB()
        {
            Year year = _cycleCalculator.CalculateYear(new DateTime(2024, 12, 25));
            Year expected = Year.B;

            Assert.Equal(year, expected);
        }

        [Fact]
        public void CalculateYear_2025_ReturnC()
        {
            Year year = _cycleCalculator.CalculateYear(new DateTime(2025, 12, 25));
            Year expected = Year.C;

            Assert.Equal(year, expected);
        }

        [Fact]
        public void CalculateYear_2026_ReturnA()
        {
            Year year = _cycleCalculator.CalculateYear(new DateTime(2026, 12, 25));
            Year expected = Year.A;

            Assert.Equal(year, expected);
        }

        [Fact]
        public void CalculateCycle_2021_Return1()
        {
            Cycle cycle = _cycleCalculator.CalculateCycle(new DateTime(2021, 12, 25));
            Cycle expected = Cycle.One;

            Assert.Equal(cycle, expected);
        }

        [Fact]
        public void CalculateCycle_2022_Return2()
        {
            Cycle cycle = _cycleCalculator.CalculateCycle(new DateTime(2022, 12, 25));
            Cycle expected = Cycle.Two;

            Assert.Equal(cycle, expected);
        }

        [Fact]
        public void CalculateCycle_2023_Return1()
        {
            Cycle cycle = _cycleCalculator.CalculateCycle(new DateTime(2023, 12, 25));
            Cycle expected = Cycle.One;

            Assert.Equal(cycle, expected);
        }

        [Fact]
        public void CalculateCycle_2024_Return2()
        {
            Cycle cycle = _cycleCalculator.CalculateCycle(new DateTime(2024, 12, 25));
            Cycle expected = Cycle.Two;

            Assert.Equal(cycle, expected);
        }

        [Fact]
        public void CalculateCycle_2025_Return1()
        {
            Cycle cycle = _cycleCalculator.CalculateCycle(new DateTime(2025, 12, 25));
            Cycle expected = Cycle.One;

            Assert.Equal(cycle, expected);
        }

        [Fact]
        public void CalculateCycle_2026_Return2()
        {
            Cycle cycle = _cycleCalculator.CalculateCycle(new DateTime(2026, 12, 25));
            Cycle expected = Cycle.Two;

            Assert.Equal(cycle, expected);
        }
    }
}