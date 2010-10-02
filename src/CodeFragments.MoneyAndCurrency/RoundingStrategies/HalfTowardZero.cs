using System;
using CodeFragments.MoneyAndCurrency.Rounding;

namespace CodeFragments.MoneyAndCurrency.RoundingStrategies
{
    /// <summary>
    /// Rounding a fraction part of 0.5 results in the nearest integer that is closer to zero.
    /// </summary>
    /// <remarks>
    ///                     -1.7  -1.5  -1.3  -0.7  -0.5  -0.3   0   0.3  0.5  0.7  1.3  1.5  1.7
    ///                     ====  ====  ====  ====  ====  ====  ===  ===  ===  ===  ===  ===  ===
    /// HalfTowardZero       -2    -1    -1    -1     0     0         0    0    1    1    1    2
    /// </remarks>
    internal class HalfTowardZero : RoundingStrategy
    {
        protected internal override decimal CalculateRoundedAmount(decimal value)
        {
            // If value is positive, subtract 0.5 and take the next greater integer. 
            // If value is negative, add 0.5 and take the next smaller integer.  

            decimal result = value >= 0 ? Math.Ceiling(value - 0.5m) : Math.Floor(value + 0.5m);
            return Math.Truncate(result);
        }
    }
}
