using System;
using CodeFragments.MoneyAndCurrency.RoundingStrategies;

namespace CodeFragments.MoneyAndCurrency.Rounding
{
    internal class RoundingStrategyFactory
    {
        public static RoundingStrategy GetRoundingStrategy(RoundingMode roundingMode)
        {
            switch (roundingMode)
            {
                case RoundingMode.HalfAwayFromZero:
                    {
                        return new HalfAwayFromZero();
                    }
                case RoundingMode.HalfToEven:
                    {
                        return new HalfToEven();
                    }
                case RoundingMode.HalfToOdd:
                    {
                        return new HalfToOdd();
                    }
                case RoundingMode.HalfTowardZero:
                    {
                        return new HalfTowardZero();
                    }
            }
            throw new NotImplementedException();
        }
    }
}