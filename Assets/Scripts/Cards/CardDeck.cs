using UnityEngine;
using Random = System.Random;
using System.Collections.Generic;


namespace Cards
{
    /// <summary>
    /// this scriptable object represent card deck 
    /// </summary>
    [CreateAssetMenu(menuName = "SO/CardDeck", fileName = "CardDeck")]
    public class CardDeck : ScriptableObject
    {
        [SerializeField] private List<CardData> Cards = new List<CardData>();

        private Random Random = new Random();

        // get random card 
        public CardData GetCard()
        {
            int selectedIndex = Random.Next(Cards.Count);

            while (Cards[selectedIndex].IsBusy)
            {
                selectedIndex = Random.Next(Cards.Count);
            }

            Cards[selectedIndex].IsBusy = true;

            return Cards[selectedIndex];
        }

        // reset cards
        public void RestDeck()
        {
            foreach (var card in Cards)
            {
                card.IsBusy = false;
            }
        }
    }
}