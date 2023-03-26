using System;
using Cards;
using UnityEngine;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Controller
{
    /// <summary>
    /// this class is where the visual and some of logical meat of the card deal and draw
    /// happend 
    /// </summary>
    public class CardsTable : MonoBehaviour
    {
        [SerializeField] private CardDeck CardDeck;
        [SerializeField] private CardView[] Cards;

        private List<CardData> InitialCards = new List<CardData>();
        private List<CardData> SubstiuteCards = new List<CardData>();

        private bool IsDeal = true;
        private const int DelayConst = 200;
        private const int CardAnimationLength = 500;

        public event Action<List<CardData>> OnHandComplete;

        // deal card method 
        // reset cardDeck <SO cardDeck>
        // reset generated cards lists 
        // generate new card
        // assign card sprite to a table card and animate them 
        
        public void DealCards()
        {
            IsDeal = true;
            ResetCardsDeck();
            InitialCards.Clear();
            SubstiuteCards.Clear();
            GenerateDealCards();
            int skipIndex = 0;
            foreach (var card in Cards)
            {
                AssignAndAnimateCards(card, skipIndex++);
            }
        }

        // draw card some meat happens 
        // we substitute only unholding cards
        // play draw animation and idle animation
        public void SubstituteCards()
        {
            IsDeal = false;
            int skipIndex = 0;
            foreach (var card in Cards)
            {
                if (card.IsHolding())
                {
                    UpdateHoldView(card);
                    card.IdleFront();
                    continue;
                }

                SubstituteCardsData(card);
                AssignAndAnimateCards(card, skipIndex++);
            }

            CalculateTimeAfterDraw(skipIndex);
        }

        // generate deal cards and same amount of sabstitute cards
        private void GenerateDealCards()
        {
            for (int i = 0; i < Cards.Length; i++)
            {
                InitialCards.Add(CardDeck.GetCard());
                SubstiuteCards.Add(CardDeck.GetCard());
            }
        }

        private void ResetCardsDeck()
        {
            CardDeck.RestDeck();
        }

        // remove hold
        private void UpdateHoldView(CardView card)
        {
            card.ChangeHoldView();
        }
        
        private void SubstituteCardsData(CardView card)
        {
            InitialCards[card.GetIndex()] = SubstiuteCards[card.GetIndex()];
        }

        // animate cards sequentially 
        private void AssignAndAnimateCards(CardView card, int index)
        {
            int delay = DelayConst * index + 10; // 10 for avoid over lap 
            card.SetNewSuit(InitialCards[card.GetIndex()].GetCardSuit());
            card.FlipBack();

            if (IsDeal)
            {
                card.FlipCardWithDelay(delay);
                return;
            }

            card.FlipCardWithDelayDraw(delay);
        }

        // calculate time for calling after draw call back 
        private async void CalculateTimeAfterDraw(int flipedCards)
        {
            int delay = DelayConst * flipedCards;
            int flipCardDuration = CardAnimationLength;

            await Task.Delay(delay + flipCardDuration);

            OnHandComplete?.Invoke(InitialCards);
        }
    }
}