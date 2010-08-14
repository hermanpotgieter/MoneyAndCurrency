using System;

namespace CodeFragments.MoneyAndCurrency
{
    public class Money : IEquatable<Money>
    {
        protected Money()
        {
        }

        public Money(string currencyCode, decimal amount)
        {
            CurrencyCode = currencyCode;
            Amount = amount;
        }

        public string CurrencyCode { get; private set; }

        public decimal Amount { get; private set; }

        public bool Equals(Money other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Equals(other.CurrencyCode, CurrencyCode) && other.Amount == Amount;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == typeof (Money) && Equals((Money) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (CurrencyCode.GetHashCode()*397) ^ Amount.GetHashCode();
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
    }
}