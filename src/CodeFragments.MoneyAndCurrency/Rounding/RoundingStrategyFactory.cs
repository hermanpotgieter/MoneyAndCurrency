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
                case RoundingMode.Down:
                    {
                        return new RoundingDownStrategy();
                    }
                case RoundingMode.Up:
                    {
                        throw new NotImplementedException();
                    }
                case RoundingMode.TowardsZero:
                    {
                        throw new NotImplementedException();
                    }
                case RoundingMode.AwayFromZero:
                    {
                        throw new NotImplementedException();
                    }
                case RoundingMode.HalfUp:
                    {
                        throw new NotImplementedException();
                    }
                case RoundingMode.HalfDown:
                    {
                        throw new NotImplementedException();
                    }
                case RoundingMode.HalfAwayFromZero:
                    {
                        throw new NotImplementedException();
                    }
                case RoundingMode.HalfTowardZero:
                    {
                        throw new NotImplementedException();
                    }
                case RoundingMode.HalfToEven:
                    {
                        throw new NotImplementedException();
                    }
                case RoundingMode.HalfToOdd:
                    {
                        throw new NotImplementedException();
                    }
            }
            throw new NotImplementedException();
        }
    }
}