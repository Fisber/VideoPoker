
using Bets;
using Cards;
using Models;
using NUnit.Framework;
using Types = Cards.Types;
using System.Collections.Generic;

public class TestCombination
{
    /// <summary>
    /// test  combination
    /// </summary>
    /// 
    Card Card1 = new Card();
    Card Card2 = new Card();
    Card Card3 = new Card();
    Card Card4 = new Card();
    Card Card5 = new Card();

    private void CheckCombination(List<Card> cards, WinCombinations target)
    {
        var finalCombination = new FinalCombination();
        var combination = finalCombination.GetFinalCombination(cards);

        Assert.That(combination == target);
    }
    
    [Test]
    public void TestJacksOrBetter()
    {
        Card1.SetSuits(Suits.Clubs);
        Card1.SetCardType(Types.Jack);
    
        Card2.SetSuits(Suits.Diamond);
        Card2.SetCardType(Types.Jack);
    
        Card3.SetSuits(Suits.Hearts);
        Card3.SetCardType(Types.Seven);
    
        Card4.SetSuits(Suits.Hearts);
        Card4.SetCardType(Types.Four);
    
        Card5.SetSuits(Suits.Spades);
        Card5.SetCardType(Types.Eight);
    
        List<Card> Combination = new List<Card>
        {
            Card1, Card2, Card3, Card4, Card5,
        };
    
        CheckCombination(Combination, WinCombinations.JacksOrBetter);
    
    }

    [Test]
    public void TestTowPairCombination()
    {
        
        Card1.SetSuits(Suits.Clubs);
        Card1.SetCardType(Types.Ace);

        Card2.SetSuits(Suits.Diamond);
        Card2.SetCardType(Types.Ace);

        Card3.SetSuits(Suits.Hearts);
        Card3.SetCardType(Types.King);

        Card4.SetSuits(Suits.Hearts);
        Card4.SetCardType(Types.King);

        Card5.SetSuits(Suits.Spades);
        Card5.SetCardType(Types.Eight);

        List<Card> Combination = new List<Card>
        {
            Card1, Card2, Card3, Card4, Card5,
        };
        
        CheckCombination(Combination, WinCombinations.TwoPair);
    }
    
    [Test]
    public void TestTreeOfKindCombination()
    {
        
        Card1.SetSuits(Suits.Clubs);
        Card1.SetCardType(Types.Ace);

        Card2.SetSuits(Suits.Diamond);
        Card2.SetCardType(Types.Ace);

        Card3.SetSuits(Suits.Hearts);
        Card3.SetCardType(Types.Ace);

        Card4.SetSuits(Suits.Hearts);
        Card4.SetCardType(Types.King);

        Card5.SetSuits(Suits.Spades);
        Card5.SetCardType(Types.Eight);

        List<Card> Combination = new List<Card>
        {
            Card1, Card2, Card3, Card4, Card5,
        };
        
        CheckCombination(Combination, WinCombinations.ThreeOfAKind);
    }
    
    [Test]
    public void TestFourOfKindCombination()
    {
        
        Card1.SetSuits(Suits.Clubs);
        Card1.SetCardType(Types.Ace);

        Card2.SetSuits(Suits.Diamond);
        Card2.SetCardType(Types.Ace);

        Card3.SetSuits(Suits.Hearts);
        Card3.SetCardType(Types.Ace);

        Card4.SetSuits(Suits.Hearts);
        Card4.SetCardType(Types.King);

        Card5.SetSuits(Suits.Spades);
        Card5.SetCardType(Types.Ace);

        List<Card> Combination = new List<Card>
        {
            Card1, Card2, Card3, Card4, Card5,
        };
        
        CheckCombination(Combination, WinCombinations.FourOfAKind);
    }
    
    [Test]
    public void TestStraightBroadwayCombination()
    {
        
        Card1.SetSuits(Suits.Clubs);
        Card1.SetCardType(Types.Ten);

        Card2.SetSuits(Suits.Diamond);
        Card2.SetCardType(Types.Jack);

        Card3.SetSuits(Suits.Hearts);
        Card3.SetCardType(Types.Queen);

        Card4.SetSuits(Suits.Hearts);
        Card4.SetCardType(Types.King);

        Card5.SetSuits(Suits.Spades);
        Card5.SetCardType(Types.Ace);

        List<Card> Combination = new List<Card>
        {
            Card1, Card2, Card3, Card4, Card5,
        };
        
        CheckCombination(Combination, WinCombinations.Straight);
    }
    
    [Test]
    public void TestDescendingStraightCombination()
    {
        
        Card1.SetSuits(Suits.Clubs);
        Card1.SetCardType(Types.Five);

        Card2.SetSuits(Suits.Diamond);
        Card2.SetCardType(Types.Four);

        Card3.SetSuits(Suits.Hearts);
        Card3.SetCardType(Types.Three);

        Card4.SetSuits(Suits.Hearts);
        Card4.SetCardType(Types.Tow);

        Card5.SetSuits(Suits.Spades);
        Card5.SetCardType(Types.Ace);

        List<Card> Combination = new List<Card>
        {
            Card1, Card2, Card3, Card4, Card5,
        };
        
        CheckCombination(Combination, WinCombinations.Straight);
    }
    
    [Test]
    public void TestIncorrectStraightCombination()
    {
        
        Card1.SetSuits(Suits.Clubs);
        Card1.SetCardType(Types.Ace);

        Card2.SetSuits(Suits.Diamond);
        Card2.SetCardType(Types.Four);

        Card3.SetSuits(Suits.Hearts);
        Card3.SetCardType(Types.Three);

        Card4.SetSuits(Suits.Hearts);
        Card4.SetCardType(Types.Tow);

        Card5.SetSuits(Suits.Spades);
        Card5.SetCardType(Types.Five);

        List<Card> Combination = new List<Card>
        {
            Card1, Card2, Card3, Card4, Card5,
        };
        
        CheckCombination(Combination, WinCombinations.None);
    }
    
    [Test]
    public void TestStraightCombination()
    {
        
        Card1.SetSuits(Suits.Clubs);
        Card1.SetCardType(Types.Ace);

        Card2.SetSuits(Suits.Diamond);
        Card2.SetCardType(Types.Four);

        Card3.SetSuits(Suits.Hearts);
        Card3.SetCardType(Types.Three);

        Card4.SetSuits(Suits.Hearts);
        Card4.SetCardType(Types.Tow);

        Card5.SetSuits(Suits.Spades);
        Card5.SetCardType(Types.Five);

        List<Card> Combination = new List<Card>
        {
            Card1, Card2, Card3, Card4, Card5,
        };
        
        CheckCombination(Combination, WinCombinations.None);
    }
    
    [Test]
    public void TestFlushStraightCombination()
    {
        
        Card1.SetSuits(Suits.Clubs);
        Card1.SetCardType(Types.Five);

        Card2.SetSuits(Suits.Clubs);
        Card2.SetCardType(Types.Six);

        Card3.SetSuits(Suits.Clubs);
        Card3.SetCardType(Types.Seven);

        Card4.SetSuits(Suits.Clubs);
        Card4.SetCardType(Types.Eight);

        Card5.SetSuits(Suits.Clubs);
        Card5.SetCardType(Types.Nine);

        List<Card> Combination = new List<Card>
        {
            Card1, Card2, Card3, Card4, Card5,
        };
        
        CheckCombination(Combination, WinCombinations.StraightFlush);
    }
    
    [Test]
    public void TestFlushCombination()
    {
        
        Card1.SetSuits(Suits.Clubs);
        Card1.SetCardType(Types.Five);

        Card2.SetSuits(Suits.Clubs);
        Card2.SetCardType(Types.Ten);

        Card3.SetSuits(Suits.Clubs);
        Card3.SetCardType(Types.Nine);

        Card4.SetSuits(Suits.Clubs);
        Card4.SetCardType(Types.Ace);

        Card5.SetSuits(Suits.Clubs);
        Card5.SetCardType(Types.Seven);

        List<Card> Combination = new List<Card>
        {
            Card1, Card2, Card3, Card4, Card5,
        };
        
        CheckCombination(Combination, WinCombinations.Flush);
    }
    
    [Test]
    public void TestFullHouseCombination()
    {
        
        Card1.SetSuits(Suits.Clubs);
        Card1.SetCardType(Types.Five);

        Card2.SetSuits(Suits.Hearts);
        Card2.SetCardType(Types.Five);

        Card3.SetSuits(Suits.Clubs);
        Card3.SetCardType(Types.Nine);

        Card4.SetSuits(Suits.Hearts);
        Card4.SetCardType(Types.Nine);

        Card5.SetSuits(Suits.Diamond);
        Card5.SetCardType(Types.Nine);

        List<Card> Combination = new List<Card>
        {
            Card1, Card2, Card3, Card4, Card5,
        };
        
        CheckCombination(Combination, WinCombinations.FullHouse);
    }
}