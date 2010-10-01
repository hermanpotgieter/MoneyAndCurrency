using System;
using CodeFragments.MoneyAndCurrency.Rounding;

namespace CodeFragments.MoneyAndCurrency.RoundingStrategies
{
    internal class RoundingDownStrategy : RoundingStrategy
    {
        protected override decimal CalculateRoundedAmount(decimal amount, int decimalPlaces)
        {
            return Math.Floor(amount);
        }
    }
}
