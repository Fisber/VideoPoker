using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
    /// <summary>
    /// this class is responsible about cards on the card table representations
    /// each card has index
    /// there is 4 animation for cards
    ///     back animation
    ///     deal animation
    ///     deal draw animation
    ///     idle front
    /// </summary>
    public class CardView : MonoBehaviour
    {
        [SerializeField] private int Index;
        [SerializeField] private Animator Animator;
        [SerializeField] private GameObject HoldView;
        [SerializeField] private Image Suit;

        private string FlipBackClip = "CardFlipBack";
        private string FlipCardClip = "CardFlip";
        private string FlipCardDraw = "CardFlipDraw";
        private string IdleCardFront = "IdleFrontDraw";

        private bool IsHoldCard;

        public void SetNewSuit(Sprite suit)
        {
            Suit.sprite = suit;
        }

        public void ChangeHoldView()
        {
            IsHoldCard = !IsHoldCard;
            HoldView.SetActive(IsHoldCard);
        }

        public bool IsHolding()
        {
            return IsHoldCard;
        }

        public int GetIndex()
        {
            return Index;
        }

        public void FlipBack()
        {
            Animator.Play(FlipBackClip);
        }

        public void IdleFront()
        {
            Animator.Play(IdleCardFront);
        }

        public async void FlipCardWithDelayDraw(int delay)
        {
            await Task.Delay(delay);

            Animator.Play(FlipCardDraw);
        }

        public async void FlipCardWithDelay(int delay)
        {
            await Task.Delay(delay);

            Animator.Play(FlipCardClip);
        }
    }
}