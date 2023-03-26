using System;
using UnityEngine;


namespace Cards
{
    /// <summary>
    /// this class responsible for card logical and ui representation
    /// by using this class in scriptable object I was a ble to create a cards Deck
    /// </summary>
    [Serializable]
    public class CardData 
    {
            [SerializeField] private Sprite CardSuit;
            [SerializeField] private Card Card;
            
            // this used for mark that is card already part of Deal hand or substitution cards
            // reset after  hand is done 
            [NonSerialized]public bool IsBusy;

            public Card GetCard()
            {
                return Card;
            }

            public Sprite GetCardSuit()
            {
                return CardSuit;
            }
        
    }
}