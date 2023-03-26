using Bets;
using Cards;
using Models;
using BetsView;
using VContainer;
using VContainer.Unity;
using Models.UserModel;
using Controller.UIView;
using System.Collections.Generic;

namespace Controller
{
    /// <summary>
    /// this class initialize game flow and bind deferent part of the togather
    /// </summary>
    public class GameFlowInitializer : IStartable
    {
        [Inject] private BetsTable BetsTable;
        [Inject] private CardsTable CardsTable;
        [Inject] private UserModel UserModel;
        [Inject] private HudMoneyView HudMoneyView;
        [Inject] private BetButtonsView BetButtonsView;
        [Inject] private FinalCombination FinalCombination;

        private bool IsDealRound = true;
        
        public void Start()
        {
            // assign  action for Deal button  
            BetButtonsView.OnDealButton(ClickDealButton);
            // subscribe to on hand flow complete
            CardsTable.OnHandComplete += ShowHandWinAmount;
            CardsTable.OnHandComplete += ReleaseButtons;

            UpdateUI();
        }

        // this will enable buttons again 
        private void ReleaseButtons(List<CardData> Obj)
        {
          BetButtonsView.EnableButtons(true);
        }

        // we get the card combination from cardTable 
        // and pass it throw finalCombination class which will 
        // determine what combination do we get 
        // then we get the bet for this win combination 
        // and pass it to the UserCredits model which will calculate the win 
        // and update user balance
        private void ShowHandWinAmount(List<CardData> cardsData)
        {
            var combination = FinalCombination.GetFinalCombination(cardsData);

            if (combination == CombinationEnum.None)
            {
                return;
            }

            int bet = BetsTable.GetWinBet((int) combination - 1);
            
            UserModel.CalculateWinAmount(bet);
            UserModel.UpdateMoney();

            UpdateUI();
        }

        private void UpdateUI()
        {
            HudMoneyView.SetTotalMoney(UserModel.GetMoney());
            HudMoneyView.SetCurrentWin(UserModel.GetCurrentWin());
        }

        // on Deal button clicked 
        // we check if we have enough balance 
        // then if it is deal then we will decress the balance 
        // update win ui 
        // update balance 
        // change text on deal button 
        // disable ui as you start a hand 
        private void ClickDealButton()
        {
            if (UserModel.CheckIfUserHasMoney() == false)
            {
                BetButtonsView.ShowNoMoneyPopup();
             // show message 
                return;
            }
            
            if (IsDealRound)
            {
                IsDealRound = false;
                UserModel.DecreaseUserMoney();
                HudMoneyView.SetTotalMoney(UserModel.GetMoney());
                HudMoneyView.ResetCurrentWin();
                CardsTable.DealCards();
                BetButtonsView.ChangeDealText();
                BetsTable.RestBetsColor();
                BetButtonsView.EnableButtons(false);
            }
            else
            {
                IsDealRound = true;
                CardsTable.SubstituteCards();
                BetButtonsView.ChangeDealText();
            }
        }
    }
}