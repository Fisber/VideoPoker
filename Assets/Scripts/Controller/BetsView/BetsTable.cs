using UnityEngine;

namespace BetsView
{
    /// <summary>
    /// BetsTable is a Controller responseble for showing selected bets table and managing
    /// bets table 
    /// </summary>
    public class BetsTable : MonoBehaviour
    {
        [SerializeField] private BetView[] BetsViews;

        private int BetTableIndex;
        
        // the bet from the table and used it in win calculation 
        // also set win bet color 
        public int GetWinBet(int combinationIndex)
        {
           var bets = BetsViews[BetTableIndex].GetBets();
           BetsViews[BetTableIndex].SetTextColor(combinationIndex);
           return bets[combinationIndex];
        }

        // reset bets color 
        public void RestBetsColor()
        {
            BetsViews[BetTableIndex].ResetTextColor();
        }

        // select table 
        public void SetBet(int selectedBet)
        {
            BetTableIndex = selectedBet;
            foreach (var bet in BetsViews)
            {
                bet.CheckSelected(selectedBet);
            }
        }
        
    }
}