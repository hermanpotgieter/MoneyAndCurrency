using System.Collections.Generic;

namespace CodeFragments.MoneyAndCurrency.Tests.RoundingTestCases
{
    public class HalfToOddTestCases
    {
        internal static IDictionary<decimal, decimal> strategyCases
            = new SortedDictionary<decimal, decimal>
                  {
                      {-2.5m, -3m},
                      {-2.3m, -2m},
                      {-1.7m, -2m},
                      {-1.5m, -1m},
                      {-1.3m, -1m},
                      {-0.7m, -1m},
                      {-0.5m, -1m},
                      {-0.3m, -0m},
                      {0.3m, 0m},
                      {0.5m, 1m},
                      {0.7m, 1m},
                      {1.3m, 1m},
                      {1.5m, 1m},
                      {1.7m, 2m},
                      {2.3m, 2m},
                      {2.5m, 3m},
                  };

        internal static IDictionary<decimal, decimal> extensionMethodCases
            = new SortedDictionary<decimal, decimal>
                  {
                      {-0.25m, -0.3m},
                      {-0.23m, -0.2m},
                      {-0.17m, -0.2m},
                      {-0.15m, -0.1m},
                      {-0.13m, -0.1m},
                      {-0.07m, -0.1m},
                      {-0.05m, -0.1m},
                      {-0.03m, -0.0m},
                      {0.03m, 0.0m},
                      {0.05m, 0.1m},
                      {0.07m, 0.1m},
                      {0.13m, 0.1m},
                      {0.15m, 0.1m},
                      {0.17m, 0.2m},
                      {0.23m, 0.2m},
                      {0.25m, 0.3m},
                  };
    }
}