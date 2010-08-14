using System.Collections.Generic;

namespace CodeFragments.MoneyAndCurrency
{
    public partial class Currency
    {
        // ReSharper disable InconsistentNaming

        public static Currency BWP { get; private set; }

        public static Currency USD { get; private set; }

        public static Currency XDR { get; private set; }

        public static Currency ZAR { get; private set; }

        // ReSharper restore InconsistentNaming

        private static IEnumerable<Currency> CreateCurrencyList()
        {
            List<Currency> currencies = new List<Currency>
                                            {
                                                {BWP = new Currency("BWP", 72, "Pula", 2)},
                                                {USD = new Currency("USD", 840, "United States Dollar", 2)},
                                                {XDR = new Currency("XDR", 999, "SDR - International Monetary Fund", 0)},
                                                {ZAR = new Currency("ZAR", 710, "Rand", 2)},
                                            };
            return currencies.AsReadOnly();
        }
    }
}