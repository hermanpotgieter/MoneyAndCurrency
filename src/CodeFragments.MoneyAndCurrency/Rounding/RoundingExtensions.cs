namespace CodeFragments.MoneyAndCurrency.Rounding
{
    public static class RoundingExtensions
    {
        public static Money Round(this Money money)
        {
            return money.Round(money.RoundingMode, (DecimalPlaces) money.DecimalPlaces);
        }

        public static Money Round(this Money money, RoundingMode roundingMode)
        {
            return money.Round(roundingMode, (DecimalPlaces)money.DecimalPlaces);
        }

        public static Money Round(this Money money, DecimalPlaces decimalPlaces)
        {
            return money.Round(money.RoundingMode, decimalPlaces);
        }

        public static Money Round(this Money money, RoundingMode roundingMode, DecimalPlaces decimalPlaces)
        {
            RoundingStrategy strategy = RoundingStrategyFactory.GetRoundingStrategy(roundingMode);

            return strategy.Round(money, (int) decimalPlaces);
        }
    }
}
