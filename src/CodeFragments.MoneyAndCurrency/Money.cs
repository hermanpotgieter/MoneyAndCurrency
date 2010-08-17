using System;

namespace CodeFragments.MoneyAndCurrency
{
    public class Money : IEquatable<Money>
    {
        protected Money() {}

        public Money(string currencyCode, decimal amount)
            : this(Currency.FromIso3LetterCode(currencyCode), amount) {}

        public Money(Currency currency, decimal amount)
        {
            Currency = currency;
            Amount = amount;
        }

        public Currency Currency { get; private set; }

        public decimal Amount { get; private set; }

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

        private static void GuardAgainstCurrencyMismatch(Money left, Money right)
        {
            if (!(left.Currency.Equals(right.Currency)))
            {
                throw new InvalidOperationException("Cannot perform arithmetic on Money with different Currency.");
            }
        }

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
    }
}
