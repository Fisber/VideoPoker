using System.Collections.Generic;
using System.Linq;
using Bets;
using Cards;

namespace Models
{
    /// <summary>
    /// this class responible for check 2 pairs 3 of kind 4 of kind
    /// logic :
    ///         2 pairs : if we have in the Dictionary 2 elements with value 2 then it is 2 pair.
    ///         3 of kind : if we have elements with value 3 then it is 3 of kind.
    ///         4 of kind : if we have elements with value 4 then it is 4 of kind. 
    /// </summary>
    public class PairsCombination : ICheckCombination
    {
        private Dictionary<Types, int> CardsPairs = new Dictionary<Types, int>();

        public WinCombinations CheckCombination(List<Card> cards)
        {
            CardsPairs.Clear();
            
            foreach (var card in cards)
            {
                if (CardsPairs.ContainsKey(card.GetCardType()))
                {
                    CardsPairs[card.GetCardType()] += 1;
                }
                else
                {
                    CardsPairs[card.GetCardType()] = 1;
                }
            }

            int max = CardsPairs.Max(s => s.Value);
            int towPairs = CardsPairs.Count(s => s.Value > 1);

            WinCombinations combination = WinCombinations.None;
            
            //one pair
            // if (max == 2)
            // {
            //     combination = CombinationEnum.OnePair;
            // }

            if (towPairs == 2)
            {
                combination = WinCombinations.TwoPair;
            }

            if (max == 3)
            {
                combination = WinCombinations.ThreeOfAKind;
            }

            if (max == 4)
            {
                combination = WinCombinations.FourOfAKind;
            }

            return combination;
        }
    }
}