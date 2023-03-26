namespace Bets
{
    /// <summary>
    /// this enum hold all the combination in the game
    /// form less priority to the higher one
    /// </summary>
    public enum CombinationEnum
    {
        None,
        JacksOrBetter,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        FiveOfKind,  // not sure if this is releated to video poker !!
    }
}