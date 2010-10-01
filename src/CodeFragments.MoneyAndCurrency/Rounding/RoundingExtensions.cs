namespace CodeFragments.MoneyAndCurrency.Rounding
{
    public static class RoundingExtensions
    {
        public static Money Round(this Money money)
        {
            return money.Round(money.RoundingMode, money.Currency.DecimalPlaces);
        }

        public static Money Round(this Money money, RoundingMode roundingMode, int decimalPlaces)
        {
            RoundingStrategy roundingStrategy = RoundingStrategyFactory.GetRoundingStrategy(roundingMode);

            return roundingStrategy.Round(money, decimalPlaces);
        }
    }
}
