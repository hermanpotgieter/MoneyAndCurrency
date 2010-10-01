namespace CodeFragments.MoneyAndCurrency.Rounding
{
    internal abstract class RoundingStrategy
    {
        internal Money Round(Money money, int decimalPlaces)
        {
            decimal roundedAmount = CalculateRoundedAmount(money.Amount, decimalPlaces);

            return new Money(money.Currency, roundedAmount, money.RoundingMode, money.DecimalPlaces);
        }

        protected abstract decimal CalculateRoundedAmount(decimal amount, int decimalPlaces);
    }
}
