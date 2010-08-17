using System;
using NUnit.Framework;

namespace CodeFragments.MoneyAndCurrency.Tests
{
    [TestFixture]
    public class MoneyTests
    {
        [Test]
        public void New_CurrencyCodeAndAmount_Money()
        {
            Money money = new Money("ZAR", 0);
            Assert.IsNotNull(money);
        }

        [Test]
        public void New_CurrencyTypeAndAmount_Money()
        {
            Money money = new Money(Currency.ZAR, 0);
            Assert.IsNotNull(money);
        }

        // Equality ==

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

        // Inequality !=

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

        // Less than <

        [Test]
        public void LessThan_DifferentCurrencies_ThrowsInvalidOperationException()
        {
            Money money1 = new Money("ZAR", 1);
            Money money2 = new Money("USD", 1);

            Assert.Throws<InvalidOperationException>(() => { bool result = money1 < money2; });
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

        // Greater than >

        [Test]
        public void GreaterThan_DifferentCurrencies_ThrowsInvalidOperationException()
        {
            Money money1 = new Money("ZAR", 1);
            Money money2 = new Money("USD", 1);

            Assert.Throws<InvalidOperationException>(() => { bool result = money1 > money2; });
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

        // Less than or equals <=

        [Test]
        public void LessThanOrEquals_DifferentCurrencies_ThrowsInvalidOperationException()
        {
            Money money1 = new Money("ZAR", 1);
            Money money2 = new Money("USD", 1);

            Assert.Throws<InvalidOperationException>(() => { bool result = money1 <= money2; });
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

        // Greater than or equals >=

        [Test]
        public void GreaterThanOrEquals_DifferentCurrencies_ThrowsInvalidOperationException()
        {
            Money money1 = new Money("ZAR", 1);
            Money money2 = new Money("USD", 1);

            Assert.Throws<InvalidOperationException>(() => { bool result = money1 >= money2; });
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

        // Addition +

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

            Assert.Throws<InvalidOperationException>(() => { Money result = money1 + money2; });
        }

        // Subtraction -

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

            Assert.Throws<InvalidOperationException>(() => { Money result = money1 - money2; });
        }

        // Multiplication *

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

            Assert.Throws<InvalidOperationException>(() => { Money result = money1 * money2; });
        }

        // Division /

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

            Assert.Throws<InvalidOperationException>(() => { Money result = money1 / money2; });
        }

        // Modulus %

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

            Assert.Throws<InvalidOperationException>(() => { Money result = money1 % money2; });
        }
    }
}