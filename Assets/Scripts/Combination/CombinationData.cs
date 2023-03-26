using Bets;
using UnityEngine;

namespace Combination
{
    /// <summary>
    /// this ScriptableObject  used as holder for all combination plus
    /// it used for ui representation also 
    /// </summary>
    [CreateAssetMenu(menuName = "SO/CombinationData",fileName = "CombinationData")]
    public class CombinationData : ScriptableObject
    {
        [SerializeField] private WinCombinations[] CombinationEnums;

        public WinCombinations[] GetCombination()
        {
            return CombinationEnums;
        }

    }
}