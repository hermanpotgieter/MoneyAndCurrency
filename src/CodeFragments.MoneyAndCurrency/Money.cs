using System;
using CodeFragments.MoneyAndCurrency.Currencies;
using CodeFragments.MoneyAndCurrency.Rounding;

namespace CodeFragments.MoneyAndCurrency
{
    [Serializable]
    public class Money : IEquatable<Money>
    {
        private const RoundingMode defaultRoundingMode = RoundingMode.HalfToEven;

        public Currency Currency { get; private set; }

        public decimal Amount { get; private set; }

        public RoundingMode RoundingMode { get; private set; }

        public int DecimalPlaces { get; private set; }

        protected Money() {}

        // constructors using string currencyCode

        public Money(string currencyCode, decimal amount)
            : this(Currency.FromIso3LetterCode(currencyCode), amount) {}

        public Money(string currencyCode, decimal amount, RoundingMode roundingMode)
            : this(Currency.FromIso3LetterCode(currencyCode), amount, roundingMode) {}

        public Money(string currencyCode, decimal amount, DecimalPlaces decimalPlaces)
            : this(Currency.FromIso3LetterCode(currencyCode), amount, decimalPlaces) {}

        public Money(string currencyCode, decimal amount, RoundingMode roundingMode, DecimalPlaces decimalPlaces)
            : this(Currency.FromIso3LetterCode(currencyCode), amount, roundingMode, decimalPlaces) {}

        // constructors using static Currency

        public Money(Currency currency, decimal amount)
            : this(currency, amount, defaultRoundingMode) {}

        public Money(Currency currency, decimal amount, DecimalPlaces decimalPlaces)
            : this(currency, amount, defaultRoundingMode, decimalPlaces) {}

        public Money(Currency currency, decimal amount, RoundingMode roundingMode)
            : this(currency, amount, roundingMode, (DecimalPlaces) currency.DecimalPlaces) {}

        public Money(Currency currency, decimal amount, RoundingMode roundingMode, DecimalPlaces decimalPlaces)
        {
            Currency = currency;
            Amount = amount;
            RoundingMode = roundingMode;
            DecimalPlaces = (int) decimalPlaces;
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
            return obj.GetType() == typeof (Money) && Equals((Money) obj);
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
