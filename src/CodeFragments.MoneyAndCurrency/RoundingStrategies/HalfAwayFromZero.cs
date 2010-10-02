using System;
using CodeFragments.MoneyAndCurrency.Rounding;

namespace CodeFragments.MoneyAndCurrency.RoundingStrategies
{
    /// <summary>
    /// Rounding a fraction part of 0.5 results in the nearest integer that is further from zero.
    /// </summary>
    /// <remarks>
    ///                     -1.7  -1.5  -1.3  -0.7  -0.5  -0.3   0   0.3  0.5  0.7  1.3  1.5  1.7
    ///                     ====  ====  ====  ====  ====  ====  ===  ===  ===  ===  ===  ===  ===
    /// HalfAwayFromZero     -2    -2    -1    -1    -1     0         0    1    1    1    2    2  
    /// </remarks>
    internal class HalfAwayFromZero : RoundingStrategy
    {
        protected internal override decimal CalculateRoundedAmount(decimal value)
        {
            // Add or subtract 0.5 depending on whether the value is positive  
            // or negative, and truncate the result.

            decimal result = (value + 0.5m * Math.Sign(value));
            return Math.Truncate(result);
        }
    }
}
