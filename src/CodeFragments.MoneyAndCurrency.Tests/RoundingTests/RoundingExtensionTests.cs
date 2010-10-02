using System;
using System.Collections.Generic;
using System.Linq;
using CodeFragments.MoneyAndCurrency.Rounding;
using CodeFragments.MoneyAndCurrency.Tests.RoundingTestCases;
using NUnit.Framework;

namespace CodeFragments.MoneyAndCurrency.Tests.RoundingTests
{
    [TestFixture]
    public class RoundingExtensionTests
    {
        [Test]
        [TestCaseSource("CreateTestCasesForRoundingModes")]
        public void Round_no_arguments_using_Money_defaults(RoundingMode roundingMode, DecimalPlaces decimalPlaces, decimal value, decimal expected)
        {
            Money money = new Money("ZAR", value, roundingMode, decimalPlaces);
            Money actual = money.Round();
            Assert.That(actual.Amount == expected);
        }

        [Test]
        [TestCaseSource("CreateTestCasesForRoundingModes")]
        public void Round_RoundingMode_using_Money_DecimalPlaces(RoundingMode roundingMode, DecimalPlaces decimalPlaces, decimal value, decimal expected)
        {
            // specify different RoundingMode for Money ctor to ensure the argument value is used
            RoundingMode moneyMode = roundingMode == 0 ? roundingMode + 1 : roundingMode - 1;
            Money money = new Money("ZAR", value, moneyMode, decimalPlaces);

            Money actual = money.Round(roundingMode);
            Assert.That(actual.Amount == expected);
        }

        [Test]
        [TestCaseSource("CreateTestCasesForRoundingModes")]
        public void Round_DecimalPlaces_using_Money_RoundingMode(RoundingMode roundingMode, DecimalPlaces decimalPlaces, decimal value, decimal expected)
        {
            // specify different DecimalPlaces for Money ctor to ensure the argument value is used
            Money money = new Money("ZAR", value, roundingMode, DecimalPlaces.Nine);

            Money actual = money.Round(decimalPlaces);
            Assert.That(actual.Amount == expected);
        }

        [Test]
        [TestCaseSource("CreateTestCasesForRoundingModes")]
        public void Round_DecimalPlaces_RoundingMode(RoundingMode roundingMode, DecimalPlaces decimalPlaces, decimal value, decimal expected)
        {
            // specify different RoundingMode for Money ctor to ensure the argument value is used
            RoundingMode moneyMode = roundingMode == 0 ? roundingMode + 1 : roundingMode - 1;

            // specify different DecimalPlaces for Money ctor to ensure the argument value is used
            Money money = new Money("ZAR", value, moneyMode, DecimalPlaces.Nine);

            Money actual = money.Round(roundingMode, decimalPlaces);
            Assert.That(actual.Amount == expected);
        }

        protected static IEnumerable<object[]> CreateTestCasesForRoundingModes()
        {
            return from RoundingMode roundingMode in Enum.GetValues(typeof(RoundingMode))
                   from DecimalPlaces decimalPlaces in Enum.GetValues(typeof(DecimalPlaces))
                   from testCase in GetTestCaseDictionary(roundingMode)
                   let baseFactor = (decimal) Math.Pow(10, (double) (decimalPlaces - 1))
                   let value = decimalPlaces == 0 ? 0 : testCase.Key/baseFactor
                   let expected = decimalPlaces == 0 ? 0 : testCase.Value/baseFactor
                   select new object[] {roundingMode, decimalPlaces, value, expected};
        }

        private static IEnumerable<KeyValuePair<decimal, decimal>> GetTestCaseDictionary(RoundingMode roundingMode)
        {
            switch (roundingMode)
            {
                case RoundingMode.HalfAwayFromZero:
                    {
                        return HalfAwayFromZeroTestCases.extensionMethodCases;
                    }
                case RoundingMode.HalfToEven:
                    {
                        return HalfToEvenTestCases.extensionMethodCases;
                    }
                case RoundingMode.HalfToOdd:
                    {
                        return HalfToOddTestCases.extensionMethodCases;
                    }
                case RoundingMode.HalfTowardZero:
                    {
                        return HalfTowardZeroTestCases.extensionMethodCases;
                    }
            }
            return null;
        }
    }
}