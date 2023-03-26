using Bets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BetsView
{
    /// <summary>
    /// this is visual representation of each bet table 
    /// </summary>
    public class BetView : MonoBehaviour
    {
        [SerializeField] private BetsData Bets;
        [SerializeField] private TextMeshProUGUI[] BetText;
        [SerializeField] private Image SelectionIndecator;

        // change bet table back color
        public void CheckSelected(int index)
        {
            if (index != Bets.GetBetTableIndex())
            {
                ResetTextColor();
            }

            SetSelectedTableColor(index == Bets.GetBetTableIndex());
        }

        public int[] GetBets()
        {
            return Bets.GetBets();
        }

        public void ResetTextColor()
        {
            foreach (var text in BetText)
            {
                text.color = Color.white;
            }
        }

        // set color for win combination bet 
        public void SetTextColor(int index)
        {
            BetText[index].color = Color.green;
        }
        
        private void Start()
        {
            InitializeBetTable();
        }

        private void InitializeBetTable()
        {
            var bets = Bets.GetBets();

            for (int i = 0; i < BetText.Length; i++)
            {
                BetText[i].text = bets[i].ToString();
            }
            
            CheckSelected(0);
        }

        private void SetSelectedTableColor(bool selected)
        {
            SelectionIndecator.color = selected ? Color.grey : Color.white;
        }
    }
}