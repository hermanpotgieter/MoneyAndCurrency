using System;
using NUnit.Framework;

namespace CodeFragments.MoneyAndCurrency.Tests
{
    [TestFixture]
    public class MoneyEqualityTests
    {
        #region Equality ==

        [Test]
        public void Equals_SameInstance_True()
        {
            Money money1 = new Money("ZAR", 100);
            Money money2 = money1;

            Assert.AreSame(money1, money2);
            Assert.That(money1 == money2, Is.True);
        }

        [Test]
        public void Equals_SameCurrencyAndAmount_True()
        {
            Money money1 = new Money("ZAR", 100);
            Money money2 = new Money("ZAR", 100);

            Assert.AreNotSame(money1, money2);
            Assert.That(money1 == money2, Is.True);
        }

        [Test]
        public void Equals_DifferentCurrencySameAmount_False()
        {
            Money money1 = new Money("ZAR", 100);
            Money money2 = new Money("USD", 100);

            Assert.That(money1 == money2, Is.False);
        }

        [Test]
        public void Equals_SameCurrencyDifferentAmount_False()
        {
            Money money1 = new Money("ZAR", 100);
            Money money2 = new Money("ZAR", 100.01m);

            Assert.That(money1 == money2, Is.False);
        }
        #endregion

        #region Inequality !=

        [Test]
        public void NotEquals_SameInstance_False()
        {
            Money money1 = new Money("ZAR", 100);
            Money money2 = money1;

            Assert.AreSame(money1, money2);
            Assert.That(money1 != money2, Is.False);
        }

        [Test]
        public void NotEquals_SameCurrencyAndAmount_False()
        {
            Money money1 = new Money("ZAR", 100);
            Money money2 = new Money("ZAR", 100);

            Assert.AreNotSame(money1, money2);
            Assert.That(money1 != money2, Is.False);
        }

        [Test]
        public void NotEquals_DifferentCurrencySameAmount_True()
        {
            Money money1 = new Money("ZAR", 100);
            Money money2 = new Money("USD", 100);

            Assert.That(money1 != money2, Is.True);
        }

        [Test]
        public void NotEquals_SameCurrencyDifferentAmount_True()
        {
            Money money1 = new Money("ZAR", 100);
            Money money2 = new Money("ZAR", 100.01m);

            Assert.That(money1 != money2, Is.True);
        }

        #endregion

        #region Less than <

        [Test]
        public void LessThan_DifferentCurrencies_ThrowsInvalidOperationException()
        {
            Money money1 = new Money("ZAR", 1);
            Money money2 = new Money("USD", 1);

            bool result = false;
            Assert.IsFalse(result);
            Assert.Throws<InvalidOperationException>(() => { result = money1 > money2; });
        }

        [Test]
        public void LessThan_EqualOperands_False()
        {
            Money money1 = new Money("ZAR", 1);
            Money money2 = new Money("ZAR", 1);

            Assert.That(money1 < money2, Is.False);
        }

        [Test]
        public void LessThan_LeftOperandIsGreater_False()
        {
            Money left = new Money("ZAR", 2);
            Money right = new Money("ZAR", 1);

            Assert.That(left < right, Is.False);
        }

        [Test]
        public void LessThan_LeftOperandIsSmaller_True()
        {
            Money left = new Money("ZAR", 1);
            Money right = new Money("ZAR", 2);

            Assert.That(left < right, Is.True);
        }

        #endregion

        #region Greater than >

        [Test]
        public void GreaterThan_DifferentCurrencies_ThrowsInvalidOperationException()
        {
            Money money1 = new Money("ZAR", 1);
            Money money2 = new Money("USD", 1);

            bool result = false;
            Assert.IsFalse(result);
            Assert.Throws<InvalidOperationException>(() => { result = money1 > money2; });
        }

        [Test]
        public void GreaterThan_EqualOperands_False()
        {
            Money money1 = new Money("ZAR", 1);
            Money money2 = new Money("ZAR", 1);

            Assert.That(money1 > money2, Is.False);
        }

        [Test]
        public void GreaterThan_LeftOperandIsSmaller_False()
        {
            Money left = new Money("ZAR", 1);
            Money right = new Money("ZAR", 2);

            Assert.That(left > right, Is.False);
        }

        [Test]
        public void GreaterThan_LeftOperandIsGreater_True()
        {
            Money left = new Money("ZAR", 2);
            Money right = new Money("ZAR", 1);

            Assert.That(left > right, Is.True);
        }

        #endregion

        #region Less than or equals <=

        [Test]
        public void LessThanOrEquals_DifferentCurrencies_ThrowsInvalidOperationException()
        {
            Money money1 = new Money("ZAR", 1);
            Money money2 = new Money("USD", 1);

            bool result = false;
            Assert.IsFalse(result);
            Assert.Throws<InvalidOperationException>(() => { result = money1 <= money2; });
        }

        [Test]
        public void LessThanOrEquals_EqualOperands_True()
        {
            Money money1 = new Money("ZAR", 1);
            Money money2 = new Money("ZAR", 1);

            Assert.That(money1 <= money2, Is.True);
        }

        [Test]
        public void LessThanOrEquals_LeftOperandIsSmaller_True()
        {
            Money left = new Money("ZAR", 1);
            Money right = new Money("ZAR", 2);

            Assert.That(left <= right, Is.True);
        }

        [Test]
        public void LessThanOrEquals_LeftOperandIsGreater_False()
        {
            Money left = new Money("ZAR", 2);
            Money right = new Money("ZAR", 1);

            Assert.That(left <= right, Is.False);
        }

        #endregion

        #region Greater than or equals >=

        [Test]
        public void GreaterThanOrEquals_DifferentCurrencies_ThrowsInvalidOperationException()
        {
            Money money1 = new Money("ZAR", 1);
            Money money2 = new Money("USD", 1);

            bool result = false;
            Assert.IsFalse(result);
            Assert.Throws<InvalidOperationException>(() => { result = money1 >= money2; });
        }

        [Test]
        public void GreaterThanOrEquals_EqualOperands_True()
        {
            Money money1 = new Money("ZAR", 1);
            Money money2 = new Money("ZAR", 1);

            Assert.That(money1 >= money2, Is.True);
        }

        [Test]
        public void GreaterThanOrEquals_LeftOperandIsSmaller_False()
        {
            Money left = new Money("ZAR", 1);
            Money right = new Money("ZAR", 2);

            Assert.That(left >= right, Is.False);
        }

        [Test]
        public void GreaterThanOrEquals_LeftOperandIsGreater_True()
        {
            Money left = new Money("ZAR", 2);
            Money right = new Money("ZAR", 1);

            Assert.That(left >= right, Is.True);
        }

        #endregion
    }
}