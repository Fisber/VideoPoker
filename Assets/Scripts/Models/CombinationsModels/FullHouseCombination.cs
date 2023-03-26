using System.Collections.Generic;
using Bets;
using Cards;

namespace Models
{
    /// <summary>
    /// this class check if we get full house combination
    /// logic : Dictionary with Types and int
    /// if we have only tow element in Dictionary that means that we have a full house 
    /// </summary>
    public class FullHouseCombination : ICheckCombination
    {
        private Dictionary<Types, int> Types = new Dictionary<Types, int>();

        public CombinationEnum CheckCombination(List<Card> cards)
        {
            Types.Clear();
            
            foreach (var card in cards)
            {
                if (Types.ContainsKey(card.GetCardType()))
                {
                    Types[card.GetCardType()] += 1;
                }
                else
                {
                    Types[card.GetCardType()] = 1;
                }
            }

            if (Types.Count == 2)
            {
                return CombinationEnum.FullHouse;
            }

            return CombinationEnum.None;
        }
    }
}