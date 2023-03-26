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
    /// </summary>
    public class StraightAndFlushCombination : ICheckCombination
    {
        private List<Types> Types = new List<Types>();

        private Dictionary<Suits, int> Suits = new Dictionary<Suits, int>();

        // this is for check if we have BroadwayCombination when A > K
        private List<Types> BroadwayCombination = new List<Types>
        {
            CardType.Ten, CardType.Jack, CardType.Queen, CardType.Jack, CardType.Ace
        };

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


            bool isFlush = Suits.Any(s => s.Value == 5);

            CombinationEnum combination = CombinationEnum.None;

            bool isStraight = CheckStraight(Types);

            if (isStraight)
            {
                combination = CombinationEnum.Straight;
            }

            if (isStraight && isFlush)
            {
                combination = CombinationEnum.StraightFlush;
            }

            if (isStraight == false && isFlush)
            {
                combination = CombinationEnum.Flush;
            }

            return combination;
        }

        private bool CheckStraight(List<Types> combination)
        {
            if (combination.Count != combination.Distinct().Count())
            {
                return false;
            }

            if (combination.Except(BroadwayCombination).Any())
            {
                return true;
            }

            if (combination.Last() - combination.First() == 4)
            {
                return true;
            }

            return false;
        }
    }
}