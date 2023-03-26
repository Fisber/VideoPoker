using Bets;
using BetsView;
using VContainer;
using VContainer.Unity;
using Models.UserModel;
using Controller.UIView;

namespace Controller
{
    // this entry point responsible about binding UI with logic <click buttons,update money .. >
    public class BetButtonUiInitializer : IStartable
    {
        [Inject] private BetButtonsView BetButtonsView;

        [Inject] private HudMoneyView HudMoneyView;

        [Inject] private UserModel UserModel;

        [Inject] private BetsTable BetsTable;
        
        [Inject] private BetsConst BetsConst;

        public void Start()
        {
            BetButtonsView.OnBetAddMoney(AddMoney);
            BetButtonsView.OnBetOne(SetOneDollarBet);
            BetButtonsView.OnBetTow(SetTowDollarBet);
            BetButtonsView.OnBetsFive(SetFiveDollarBet);
            BetButtonsView.OnBetsTen(SetTenDollarBet);
            BetButtonsView.OnBetsFifteen(SetFifteenDollarBet);
        }
        
        // add balance 
        private void AddMoney()
        {
            UserModel.AddMoney(UserModel.AddedBalance);
            HudMoneyView.SetTotalMoney(UserModel.GetMoney());
        }

        // change bet to the 1 $ 
        private void SetOneDollarBet()
        {
            BetsTable.SetBet(BetsConst.FirstPayTableIndex);
            UserModel.SetCurrentCredits(BetsConst.OneDollarBet);
        }
        
        // change bet to the 2 $ 
        private void SetTowDollarBet()
        {
            BetsTable.SetBet(BetsConst.SecondPayTableIndexx);
            UserModel.SetCurrentCredits(BetsConst.TowDollarBet);
        }

        // change bet to the 5 $ 
        private void SetFiveDollarBet()
        {
            BetsTable.SetBet(BetsConst.ThirdPayTableIndex);
            UserModel.SetCurrentCredits(BetsConst.FiveDollarBet);
        }

        // change bet to the 10 $ 
        private void SetTenDollarBet()
        {
            BetsTable.SetBet(BetsConst.FourthPayTableIndex);
            UserModel.SetCurrentCredits(BetsConst.TenDollarBet);
        }

        // change bet to the 15 $ 
        private void SetFifteenDollarBet()
        {
            BetsTable.SetBet(BetsConst.FifthPayTableIndex);
            UserModel.SetCurrentCredits(BetsConst.FifteenDollarBet);
        }
    }
}