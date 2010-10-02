using System;

namespace CodeFragments.MoneyAndCurrency.Rounding
{
    internal abstract class RoundingStrategy
    {
        internal Money Round(Money money, int decimalPlaces)
        {
            decimal amount = money.Amount;
            int factor = (int) Math.Pow(10, decimalPlaces);

            // split the amount into integral and fraction parts
            decimal integral = Math.Truncate(money.Amount);
            decimal fraction = amount-integral;

            // raise the fraction by the number of decimal places to which we want to round,
            // so that we can apply integer rounding
            decimal raisedFraction = Decimal.Multiply(fraction, factor);

            // pass the raisedFraction to a template method to do the rounding according to the RoundingStrategy
            decimal roundedFraction = CalculateRoundedAmount(raisedFraction);

            // shift the decimal to the left again, by the number of decimal places 
            decimal resultFraction = Decimal.Divide(roundedFraction, factor);

            // add the original integral and the rounded resultFraction back together
            decimal roundedAmount = integral + resultFraction;

            // return the result
            return new Money(money.Currency, roundedAmount, money.RoundingMode, (DecimalPlaces)money.DecimalPlaces);
        }

        protected internal abstract decimal CalculateRoundedAmount(decimal value);
    }
}