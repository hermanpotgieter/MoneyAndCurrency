using System;
using CodeFragments.MoneyAndCurrency.Rounding;

namespace CodeFragments.MoneyAndCurrency.RoundingStrategies
{
    internal class RoundingUpStrategy : RoundingStrategy
    {
        protected override decimal CalculateRoundedAmount(decimal amount, int decimalPlaces)
        {
            return Math.Ceiling(amount);
        }
    }
}
