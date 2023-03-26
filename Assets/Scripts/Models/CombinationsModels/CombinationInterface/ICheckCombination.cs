using System.Collections.Generic;
using Bets;
using Cards;

namespace Models
{
    public interface ICheckCombination
    {
        public WinCombinations CheckCombination(List<Card> cards);
    }
}