
using Bets;
using Cards;
using System.Collections.Generic;

namespace Models
{
    /// <summary>
    /// Highcard or Jacks or better
    /// logic : if we have 2 or more card of J Q K the it is jack or beater 
    /// </summary>
    public class HighCardCombination : ICheckCombination
    {
        public CombinationEnum CheckCombination(List<Card> cards)
        {
            int highCards = 0;

            foreach (var card in cards)
            {
                if ( card.GetCardType() > Types.Ten)
                {
                    highCards++;
                }
            }

            return highCards >= 2 ? CombinationEnum.JacksOrBetter : CombinationEnum.None;
        }
    }
}