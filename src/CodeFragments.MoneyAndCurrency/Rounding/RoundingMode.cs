namespace CodeFragments.MoneyAndCurrency.Rounding
{
    public enum RoundingMode
    {
        //(or take the floor, or round towards minus infinity): q is the largest integer that does not exceed y. 
        Down,

        //(or take the ceiling, or round towards plus infinity): q is the smallest integer that is not less than y. 
        Up,

        //(or truncate, or round away from infinity): q is the integer part of y, without its fraction digits. 
        TowardsZero,

        //(or round towards infinity): if y is an integer, q is y; else q is the integer that is closest to 0 and is such that y is between 0 and q. 
        AwayFromZero,

        // tie-breaking

        HalfUp,
        HalfDown,
        HalfAwayFromZero,
        HalfTowardZero,

        HalfToEven,
        HalfToOdd
    }
}
