using System.Collections.Generic;
using Bets;
using Cards;

namespace Models
{
    public interface ICheckCombination
    {
        public CombinationEnum CheckCombination(List<Card> cards);
    }
}