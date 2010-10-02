using System.Collections.Generic;
using System.Linq;
using CodeFragments.MoneyAndCurrency.Rounding;
using CodeFragments.MoneyAndCurrency.RoundingStrategies;
using CodeFragments.MoneyAndCurrency.Tests.RoundingTestCases;
using NUnit.Framework;

namespace CodeFragments.MoneyAndCurrency.Tests.RoundingTests
{
    [TestFixture]
    public class RoundingStrategyTests
    {
        [Test]
        [TestCaseSource("CreateTestCasesForHalfAwayFromZero")]
        public void HalfAwayFromZeroTestCases(decimal value, decimal expected)
        {
            RoundingStrategy roundingStrategy = new HalfAwayFromZero();

            decimal actual = roundingStrategy.CalculateRoundedAmount(value);

            Assert.That(actual == expected);
        }

        [Test]
        [TestCaseSource("CreateTestCasesForHalfToEven")]
        public void HalfToEvenTestCases(decimal value, decimal expected)
        {
            RoundingStrategy roundingStrategy = new HalfToEven();

            decimal actual = roundingStrategy.CalculateRoundedAmount(value);

            Assert.That(actual == expected);
        }

        [Test]
        [TestCaseSource("CreateTestCasesForHalfToOdd")]
        public void HalfToOddTestCases(decimal value, decimal expected)
        {
            RoundingStrategy roundingStrategy = new HalfToOdd();

            decimal actual = roundingStrategy.CalculateRoundedAmount(value);

            Assert.That(actual == expected);
        }

        [Test]
        [TestCaseSource("CreateTestCasesForHalfTowardZero")]
        public void HalfToWardZeroTestCases(decimal value, decimal expected)
        {
            RoundingStrategy roundingStrategy = new HalfTowardZero();

            decimal actual = roundingStrategy.CalculateRoundedAmount(value);

            Assert.That(actual == expected);
        }

        protected static IEnumerable<object[]> CreateTestCasesForHalfAwayFromZero()
        {
            return RoundingTestCases.HalfAwayFromZeroTestCases.strategyCases.Select(testCase => new object[] { testCase.Key, testCase.Value });
        }

        protected static IEnumerable<object[]> CreateTestCasesForHalfToEven()
        {
            return RoundingTestCases.HalfToEvenTestCases.strategyCases.Select(testCase => new object[] { testCase.Key, testCase.Value });
        }

        protected static IEnumerable<object[]> CreateTestCasesForHalfToOdd()
        {
            return RoundingTestCases.HalfToOddTestCases.strategyCases.Select(testCase => new object[] { testCase.Key, testCase.Value });
        }

        protected static IEnumerable<object[]> CreateTestCasesForHalfTowardZero()
        {
            return HalfTowardZeroTestCases.strategyCases.Select(testCase => new object[] { testCase.Key, testCase.Value });
        }
    }
}