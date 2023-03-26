using Bets;
using Cards;
using System.Linq;
using System.Collections.Generic;

namespace Models
{
    /// <summary>
    /// this model responsible for checking win combination 
    /// </summary>
    public class FinalCombination
    {
        // there several combination check Strategy
        // which we have to check, and because result is CombinationEnum 
        // the combination with higher priority will overwrite combination with lower once
        private List<ICheckCombination> CombinationsStratgies = new List<ICheckCombination>
        {
            new JacksOrBetterCombination(),
            new PairsCombination(),
            new StraightAndFlushCombination(),
            new FullHouseCombination(),
        };

        public WinCombinations GetFinalCombination(List<CardData> Cards)
        {
            List<Card> cards = Cards.Select(card => card.GetCard()).ToList();

            return GetFinalCombination(cards);
        }
        
        public WinCombinations GetFinalCombination(List<Card> Cards)
        {
            WinCombinations combination = WinCombinations.None;

            foreach (var strategy in CombinationsStratgies)
            {
                var currentCombination = strategy.CheckCombination(Cards);

                if (currentCombination > combination)
                {
                    combination = currentCombination;
                }
            }
            
            return combination;
        }
    }
}