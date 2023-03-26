using System;
using UnityEngine;

namespace Cards
{
    /// <summary>
    /// this class is a basic card representation with out card ui
    /// </summary>
    [Serializable]
    public class Card
    {
        [SerializeField] private Suits CardSuit;
        [SerializeField] private Types CardType;
        
        // SetSuits used for test 
        public void SetSuits(Suits suits)
        {
            CardSuit = suits;
        } 
        // SetCardType used for test        
        public void SetCardType(Types type)
        {
            CardType = type;
        }

        public Suits GetCardSuits()
        {
            return CardSuit;
        }
        
        public Types GetCardType()
        {
            return CardType;
        }
    }
}