using System;
using CodeFragments.MoneyAndCurrency.Currencies;
using CodeFragments.MoneyAndCurrency.Rounding;

namespace CodeFragments.MoneyAndCurrency
{
    public class Money : IEquatable<Money>
    {
        public Currency Currency { get; private set; }

        public decimal Amount { get; private set; }

        public RoundingMode RoundingMode { get; private set; }

        public int DecimalPlaces { get; private set; }

        protected Money() { }

        public Money(string currencyCode, decimal amount)
            : this(Currency.FromIso3LetterCode(currencyCode), amount) { }

        public Money(string currencyCode, decimal amount, RoundingMode roundingMode)
            : this(Currency.FromIso3LetterCode(currencyCode), amount, roundingMode) { }

        public Money(string currencyCode, decimal amount, RoundingMode roundingMode, int decimalplaces)
            : this(Currency.FromIso3LetterCode(currencyCode), amount, roundingMode, decimalplaces) { }

        public Money(Currency currency, decimal amount)
            : this(currency, amount, RoundingMode.HalfToEven) { }

        public Money(Currency currency, decimal amount, RoundingMode roundingMode)
            : this(currency, amount, roundingMode, currency.DecimalPlaces) { }

        public Money(Currency currency, decimal amount, RoundingMode roundingMode, int decimalplaces)
        {
            Currency = currency;
            Amount = amount;
            RoundingMode = roundingMode;
            DecimalPlaces = decimalplaces;
        }

        public bool Equals(Money other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(other.Currency, Currency) && other.Amount == Amount;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return obj.GetType() == typeof(Money) && Equals((Money)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Currency.GetHashCode() * 397) ^ Amount.GetHashCode();
            }
        }

        public static bool operator ==(Money left, Money right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Money left, Money right)
        {
            return !Equals(left, right);
        }

        // ReSharper disable UnusedParameter.Local
        private static void GuardAgainstCurrencyMismatch(Money left, Money right)
        {
            if (!(left.Currency.Equals(right.Currency)))
            {
                throw new InvalidOperationException("Cannot perform arithmetic on Money with different Currency.");
            }
        }
        // ReSharper restore UnusedParameter.Local

        public static bool operator <(Money left, Money right)
        {
            GuardAgainstCurrencyMismatch(left, right);

            return left.Amount < right.Amount;
        }

        public static bool operator >(Money left, Money right)
        {
            GuardAgainstCurrencyMismatch(left, right);

            return left.Amount > right.Amount;
        }

        public static bool operator <=(Money left, Money right)
        {
            GuardAgainstCurrencyMismatch(left, right);

            return left.Amount <= right.Amount;
        }

        public static bool operator >=(Money left, Money right)
        {
            GuardAgainstCurrencyMismatch(left, right);

            return left.Amount >= right.Amount;
        }

        public static Money operator +(Money left, Money right)
        {
            GuardAgainstCurrencyMismatch(left, right);

            decimal result = left.Amount + right.Amount;
            return new Money(left.Currency, result);
        }

        public static Money operator -(Money left, Money right)
        {
            GuardAgainstCurrencyMismatch(left, right);

            decimal result = left.Amount - right.Amount;
            return new Money(left.Currency, result);
        }

        public static Money operator *(Money left, Money right)
        {
            GuardAgainstCurrencyMismatch(left, right);

            decimal result = left.Amount * right.Amount;
            return new Money(left.Currency, result);
        }

        public static Money operator /(Money left, Money right)
        {
            GuardAgainstCurrencyMismatch(left, right);

            decimal result = left.Amount / right.Amount;
            return new Money(left.Currency, result);
        }

        public static Money operator %(Money left, Money right)
        {
            GuardAgainstCurrencyMismatch(left, right);

            decimal result = left.Amount % right.Amount;
            return new Money(left.Currency, result);
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", Currency.Iso3LetterCode, Amount);
        }

        public string ToString(string format)
        {
            return Amount.ToString(format);
        }

        public string ToWords()
        {
            throw new NotImplementedException();
        }
    }
}
