using System;
using System.Runtime.Serialization;

namespace CodeFragments.MoneyAndCurrency.Currencies
{
    [Serializable]
    public class CurrencyNotFoundException : ArgumentException
    {
        internal CurrencyNotFoundException()
        {
        }

        internal CurrencyNotFoundException(string message)
            : base(message)
        {
        }

        internal CurrencyNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        internal CurrencyNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        internal CurrencyNotFoundException(string message, string paramName)
            : base(message, paramName)
        {
        }

        internal CurrencyNotFoundException(string message, string paramName, Exception innerException)
            : base(message, paramName, innerException)
        {
        }
    }
}