using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Controller.UIView
{
    public class BetButtonsView : MonoBehaviour
    {
        [SerializeField] private Button DealButton;
        [SerializeField] private TextMeshProUGUI DealButtonText;
   
        [SerializeField] private Button BetAddMoney;
        [SerializeField] private Button BetsOne;
        [SerializeField] private Button BetsTow;
        [SerializeField] private Button BetsFive;
        [SerializeField] private Button BetsTen;
        [SerializeField] private Button BetsFifteen;
        [SerializeField] private GameObject[] SelectedBetIndicators;
        [SerializeField] private GameObject PopUpCanvase;

        public void ShowNoMoneyPopup()
        {
            PopUpCanvase.SetActive(true);
        }
        public void ChangeDealText()
        {
            DealButtonText.text = DealButtonText.text.ToLower() == "deal" ? "Draw" : "Deal";
        }

        public bool IsDealRound()
        {
            return String.Equals(DealButtonText.text, "Deal", StringComparison.CurrentCultureIgnoreCase);
        }

        public void OnBetAddMoney(Action action)
        {
            BetAddMoney.onClick.AddListener(() => action());
        }

        public void OnDealButton(Action action)
        {
            DealButton.onClick.AddListener(() => action());
        }


        public void OnBetOne(Action action)
        {
            BetsOne.onClick.AddListener(() => action());
            BetsOne.onClick.AddListener(() => DisableAllIndicatorsExcept(0));
        }

        public void OnBetTow(Action action)
        {
            BetsTow.onClick.AddListener(() => action());
            BetsTow.onClick.AddListener(() => DisableAllIndicatorsExcept(1));
        }

        public void OnBetsFive(Action action)
        {
            BetsFive.onClick.AddListener(() => action());
            BetsFive.onClick.AddListener(() => DisableAllIndicatorsExcept(2));

        }

        public void OnBetsTen(Action action)
        {
            BetsTen.onClick.AddListener(() => action());
            BetsTen.onClick.AddListener(() => DisableAllIndicatorsExcept(3));

        }
        
        public void OnBetsFifteen(Action action)
        {
            BetsFifteen.onClick.AddListener(() => action());
            BetsFifteen.onClick.AddListener(() => DisableAllIndicatorsExcept(4));

        }

        public void EnableButtons(bool enable)
        {
        
            BetsFive.interactable = enable;
            BetsOne.interactable = enable;
            BetsTen.interactable = enable;
            BetsTow.interactable = enable;
            BetsFifteen.interactable = enable;
            BetAddMoney.interactable = enable;
        }

        private void DisableAllIndicatorsExcept(int index)
        {
            for (int i = 0; i < SelectedBetIndicators.Length; i++)
            {
                SelectedBetIndicators[i].SetActive(i == index);
            }
        }
    }
}