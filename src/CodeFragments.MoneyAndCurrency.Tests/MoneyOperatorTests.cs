using System;
using NUnit.Framework;

namespace CodeFragments.MoneyAndCurrency.Tests
{
    [TestFixture]
    public class MoneyOperatorTests
    {
        #region Addition +

        [Test]
        public void Addition_SameCurrency_SumOfAmounts()
        {
            Money money1 = new Money("ZAR", 10.01m);
            Money money2 = new Money("ZAR", 20.02m);
            Money expected = new Money("ZAR", 30.03m);

            Money actual = money1 + money2;

            Assert.That(actual == expected);
        }

        [Test]
        public void Addition_DifferentCurrencies_ThrowsInvalidOperationException()
        {
            Money money1 = new Money("ZAR", 1);
            Money money2 = new Money("USD", 2);

            Money result = null;
            Assert.IsNull(result);
            Assert.Throws<InvalidOperationException>(() => { result = money1 + money2; });
        }

        #endregion

        #region Subtraction -

        [Test]
        public void Subtraction_SameCurrency_DifferenceOfAmounts()
        {
            Money money1 = new Money("ZAR", 30.03m);
            Money money2 = new Money("ZAR", 20.02m);
            Money expected = new Money("ZAR", 10.01m);

            Money actual = money1 - money2;

            Assert.That(actual == expected);
        }

        [Test]
        public void Subtraction_DifferentCurrencies_ThrowsInvalidOperationException()
        {
            Money money1 = new Money("ZAR", 1);
            Money money2 = new Money("USD", 2);

            Money result = null;
            Assert.IsNull(result);
            Assert.Throws<InvalidOperationException>(() => { result = money1 - money2; });
        }

        #endregion

        #region Multiplication *

        [Test]
        public void Multiplication_SameCurrency_ProductOfAmounts()
        {
            Money money1 = new Money("ZAR", 1.1m);
            Money money2 = new Money("ZAR", 1.1m);
            Money expected = new Money("ZAR", 1.21m);

            Money actual = money1 * money2;

            Assert.That(actual == expected);
        }

        [Test]
        public void Multiplication_DifferentCurrencies_ThrowsInvalidOperationException()
        {
            Money money1 = new Money("ZAR", 1);
            Money money2 = new Money("USD", 2);

            Money result = null;
            Assert.IsNull(result);
            Assert.Throws<InvalidOperationException>(() => { result = money1 * money2; });
        }

        #endregion

        #region Division /

        [Test]
        public void Division_SameCurrency_Quotient()
        {
            Money divisor = new Money("ZAR", 6);
            Money dividend = new Money("ZAR", 3);
            Money expected = new Money("ZAR", 2);

            Money actual = divisor / dividend;

            Assert.That(actual == expected);
        }

        [Test]
        public void Division_DifferentCurrencies_ThrowsInvalidOperationException()
        {
            Money money1 = new Money("ZAR", 1);
            Money money2 = new Money("USD", 2);

            Money result = null;
            Assert.IsNull(result);
            Assert.Throws<InvalidOperationException>(() => { result = money1 / money2; });
        }

        #endregion

        #region Modulus %

        [Test]
        public void Modulus_SameCurrency_Remainder()
        {
            Money divisor = new Money("ZAR", 5);
            Money dividend = new Money("ZAR", 2);
            Money expected = new Money("ZAR", 1);

            Money actual = divisor % dividend;

            Assert.That(actual == expected);
        }

        [Test]
        public void Modulus_DifferentCurrencies_ThrowsInvalidOperationException()
        {
            Money money1 = new Money("ZAR", 1);
            Money money2 = new Money("USD", 2);

            Money result = null;
            Assert.IsNull(result);
            Assert.Throws<InvalidOperationException>(() => { result = money1 % money2; });
        }

        #endregion
    }
}