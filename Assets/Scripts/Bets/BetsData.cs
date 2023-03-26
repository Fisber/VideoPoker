using UnityEngine;

namespace Bets
{/// <summary>
 /// BetsData is ScriptableObject that contains table bets 
 /// </summary>
    [CreateAssetMenu(menuName = "SO/BetsData", fileName = "BetsData")]
    public class BetsData : ScriptableObject
    {
        [SerializeField] private int[] Bets;
        [SerializeField] private int BetTableIndex;

        public int[] GetBets()
        {
            return Bets;
        }

        public int GetBetTableIndex()
        {
            return BetTableIndex;
        }
    }
}