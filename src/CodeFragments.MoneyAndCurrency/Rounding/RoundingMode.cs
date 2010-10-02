namespace CodeFragments.MoneyAndCurrency.Rounding
{
    /// <remarks>
    ///                      -1.7  -1.5  -1.3  -0.7  -0.5  -0.3   0   0.3  0.5  0.7  1.3  1.5  1.7
    ///                      ====  ====  ====  ====  ====  ====  ===  ===  ===  ===  ===  ===  ===
    /// HalfAwayFromZero     -2    -2    -1    -1    -1     0         0    1    1    1    2    2  
    ///
    /// HalfTowardZero       -2    -1    -1    -1     0     0         0    0    1    1    1    2
    /// 
    /// HalfToEven           -2    -2    -1    -1     0     0         0    0    1    1    2    2
    ///  
    /// HalfToOdd            -2    -1    -1    -1     1     0         0    1    1    1    1    2
    /// </remarks>
    public enum RoundingMode
    {
        HalfAwayFromZero,
        HalfToEven,
        HalfToOdd,
        HalfTowardZero,
    }
}
