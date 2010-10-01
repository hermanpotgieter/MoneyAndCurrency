using CodeFragments.MoneyAndCurrency.Currencies;
using CodeFragments.MoneyAndCurrency.Rounding;
using NUnit.Framework;

namespace CodeFragments.MoneyAndCurrency.Tests
{
    [TestFixture]
    public class MoneyConstructorTests
    {
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
            Money money = new Money("ZAR", 0, RoundingMode.TowardsZero);

            Assert.IsNotNull(money);
            Assert.That(money.RoundingMode == RoundingMode.TowardsZero);
            Assert.That(money.DecimalPlaces == 2);
        }

        [Test]
        public void Constructor_CurrencyCode_Amount_RoundingMode_DecimalPlaces()
        {
            Money money = new Money("ZAR", 0, RoundingMode.TowardsZero, 3);

            Assert.IsNotNull(money);
            Assert.That(money.RoundingMode == RoundingMode.TowardsZero);
            Assert.That(money.DecimalPlaces == 3);
        }

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
            Money money = new Money(Currency.ZAR, 0, RoundingMode.TowardsZero);

            Assert.IsNotNull(money);
            Assert.That(money.RoundingMode == RoundingMode.TowardsZero);
            Assert.That(money.DecimalPlaces == 2);
        }

        [Test]
        public void Constructor_Currency_Amount_RoundingMode_DecimalPlaces()
        {
            Money money = new Money(Currency.ZAR, 0, RoundingMode.TowardsZero, 3);

            Assert.IsNotNull(money);
            Assert.That(money.RoundingMode == RoundingMode.TowardsZero);
            Assert.That(money.DecimalPlaces == 3);
        }
    }
}
