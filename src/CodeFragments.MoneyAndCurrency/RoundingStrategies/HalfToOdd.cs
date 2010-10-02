using System;
using CodeFragments.MoneyAndCurrency.Rounding;

namespace CodeFragments.MoneyAndCurrency.RoundingStrategies
{
    /// <summary>
    /// Rounding a fraction part of 0.5 results in the nearest ODD integer.
    /// </summary>
    /// <remarks>
    ///                     -1.7  -1.5  -1.3  -0.7  -0.5  -0.3   0   0.3  0.5  0.7  1.3  1.5  1.7
    ///                     ====  ====  ====  ====  ====  ====  ===  ===  ===  ===  ===  ===  ===
    /// HalfToOdd            -2    -1    -1    -1     1     0         0    1    1    1    1    2
    /// </remarks>
    internal class HalfToOdd : RoundingStrategy
    {
        protected internal override decimal CalculateRoundedAmount(decimal value)
        {
            // First round half toward positive infinity.
            decimal result = Math.Floor(value + 0.5m);

            // If the fraction part of the original value is 0.5 
            // and the result of rounding is even, subtract 1.  
            if (value - Math.Floor(value) == 0.5m && result % 2 == 0)
            {
                result -= 1;
            }

            return result;
        }
    }
}