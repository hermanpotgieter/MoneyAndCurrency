using CodeFragments.MoneyAndCurrency.Currencies;
using CodeFragments.MoneyAndCurrency.Rounding;
using NUnit.Framework;

namespace CodeFragments.MoneyAndCurrency.Tests.MoneyTests
{
    [TestFixture]
    public class MoneyConstructorTests
    {
        // constructors using string currencyCode

        [Test]
        public void Constructor_CurrencyCode_Amount()
        {
            Money money = new Money("ZAR", 0);

            Assert.IsNotNull(money);
            Assert.That(money.RoundingMode == RoundingMode.HalfToEven);
            Assert.That(money.DecimalPlaces == 2);
        }

        [Test]
        public void Constructor_CurrencyCode_Amount_RoundingMode()
        {
            Money money = new Money("ZAR", 0, RoundingMode.HalfAwayFromZero);

            Assert.IsNotNull(money);
            Assert.That(money.RoundingMode == RoundingMode.HalfAwayFromZero);
            Assert.That(money.DecimalPlaces == 2);
        }

        [Test]
        public void Constructor_CurrencyCode_Amount_DecimalPlaces()
        {
            Money money = new Money("ZAR", 0, DecimalPlaces.Three);

            Assert.IsNotNull(money);
            Assert.That(money.RoundingMode == RoundingMode.HalfToEven);
            Assert.That(money.DecimalPlaces == 3);
        }

        [Test]
        public void Constructor_CurrencyCode_Amount_RoundingMode_DecimalPlaces()
        {
            Money money = new Money("ZAR", 0, RoundingMode.HalfAwayFromZero, DecimalPlaces.Three);

            Assert.IsNotNull(money);
            Assert.That(money.RoundingMode == RoundingMode.HalfAwayFromZero);
            Assert.That(money.DecimalPlaces == 3);
        }

        // constructors using static Currency

        [Test]
        public void Constructor_Currency_Amount()
        {
            Money money = new Money(Currency.ZAR, 0);

            Assert.IsNotNull(money);
            Assert.That(money.RoundingMode == RoundingMode.HalfToEven);
            Assert.That(money.DecimalPlaces == 2);
        }

        [Test]
        public void Constructor_Currency_Amount_RoundingMode()
        {
            Money money = new Money(Currency.ZAR, 0, RoundingMode.HalfAwayFromZero);

            Assert.IsNotNull(money);
            Assert.That(money.RoundingMode == RoundingMode.HalfAwayFromZero);
            Assert.That(money.DecimalPlaces == 2);
        }

        [Test]
        public void Constructor_Currency_Amount_DecimalPlaces()
        {
            Money money = new Money(Currency.ZAR, 0, DecimalPlaces.Three);

            Assert.IsNotNull(money);
            Assert.That(money.RoundingMode == RoundingMode.HalfToEven);
            Assert.That(money.DecimalPlaces == 3);
        }

        [Test]
        public void Constructor_Currency_Amount_RoundingMode_DecimalPlaces()
        {
            Money money = new Money(Currency.ZAR, 0, RoundingMode.HalfAwayFromZero, DecimalPlaces.Three);

            Assert.IsNotNull(money);
            Assert.That(money.RoundingMode == RoundingMode.HalfAwayFromZero);
            Assert.That(money.DecimalPlaces == 3);
        }
    }
}