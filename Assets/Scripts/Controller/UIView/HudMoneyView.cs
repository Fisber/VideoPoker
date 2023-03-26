using System;
using TMPro;
using UnityEngine;

namespace Controller.UIView
{
    /// <summary>
    /// this controller responsible for update current win ui and user balance ui 
    /// </summary>
    public class HudMoneyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI TotalMoney;
        [SerializeField] private TextMeshProUGUI CurrentWin;

        public void SetTotalMoney(long money)
        {
            TotalMoney.text = "$" + money;
        }

        public void ResetCurrentWin()
        {
            SetCurrentWin(0);
        }

        public void SetCurrentWin(long win)
        {
            CurrentWin.text = "$" + win;
        }
    }
}