namespace Models.UserModel
{
    /// <summary>
    /// this class responsible for manging user balance update it and store it 
    /// </summary>
    public class UserModel
    {
        private long CurrentMoneyAmount = 100;
        private long CurrentWinAmount;
        private int CurrentCredits = 1; // 1 2 5 10 15

        public const int AddedBalance = 100;
        public void DecreaseUserMoney()
        {
            if (CurrentCredits > CurrentMoneyAmount)
                return;

            CurrentMoneyAmount -= CurrentCredits;
        }

        public void SetCurrentCredits(int credit)
        {
            CurrentCredits = credit;
        }

        public void UpdateMoney()
        {
            CurrentMoneyAmount += CurrentWinAmount;
        }

        public void CalculateWinAmount(int bet)
        {
            CurrentWinAmount = bet * CurrentCredits;
        }

        public void AddMoney(long amount)
        {
            CurrentMoneyAmount += amount;
        }

        public bool CheckIfUserHasMoney()
        {
            return CurrentCredits <= CurrentMoneyAmount;
        }

        public long GetCurrentWin()
        {
            return CurrentWinAmount;
        }

        public long GetMoney()
        {
            return CurrentMoneyAmount;
        }
    }
}