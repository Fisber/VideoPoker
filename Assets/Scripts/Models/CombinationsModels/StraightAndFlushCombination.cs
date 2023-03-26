using System;
using Bets;
using Cards;
using System.Linq;
using System.Collections.Generic;
using CardType = Cards.Types;

namespace Models
{
    /// <summary>
    /// this model responsible for checkin flush Straight and Straight flush
    /// logic : flush we check if we have 5 amount of the same suit in the Dictionary
    /// logic : Straight a bit tricky I consider Straight is A 2 3 4 5 . . . 10 J Q K A
    /// so we have to make 2 checks for condition where A = 1 and where is when A  > K
    /// if A > K it is called BroadwayCombination
    /// </summary>
    public class StraightAndFlushCombination : ICheckCombination
    {
        private List<Types> Types = new List<Types>();

        private Dictionary<Suits, int> Suits = new Dictionary<Suits, int>();

        //BroadwayCombination when A > K
        private List<Types> BroadwayCombination = new List<Types>
        {
            CardType.Ten, CardType.Jack, CardType.Queen, CardType.King, CardType.Ace
        };

        private bool IsFlush;
        private bool IsStraight;

        public CombinationEnum CheckCombination(List<Card> cards)
        {
            Types.Clear();
            Suits.Clear();

            foreach (var card in cards)
            {
                Types.Add(card.GetCardType());

                if (Suits.ContainsKey(card.GetCardSuits()))
                {
                    Suits[card.GetCardSuits()] += 1;
                }
                else
                {
                    Suits[card.GetCardSuits()] = 1;
                }
            }


            CombinationEnum combination = CombinationEnum.None;

             IsStraight = CheckStraight();
             IsFlush = CheckFlush();

            if (IsStraight)
            {
                combination = CombinationEnum.Straight;
            }

            if (IsStraight && IsFlush)
            {
                combination = CombinationEnum.StraightFlush;
            }

            if (IsStraight == false && IsFlush)
            {
                combination = CombinationEnum.Flush;
            }

            return combination;
        }

        private bool CheckFlush()
        {
            // only one suit with five incremental <Clubs,5>
            return Suits.Count == 1;
        }

        private bool CheckStraight()
        {
            if (Types.Count != Types.Distinct().Count())
            {
                return false;
            }

            // check BroadwayCombination 
            if (Types.Except(BroadwayCombination).Any() == false)
            {
                return true;
            }

            //1-2-3-4-5 - > 5-1 , 4-2 , 4-1 == 2+1 == element in the middle <3>
            bool condition = Math.Abs(Types[4] - Types[0]) == 4;
            condition = condition && Math.Abs(Types[3] - Types[1]) == 2;
            condition = condition && Math.Abs((int) Types[3] - 1)
                == Math.Abs((int) Types[1] + 1);

            if (condition)
            {
                return true;
            }

            return false;
        }
    }
}