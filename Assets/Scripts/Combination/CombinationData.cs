using Bets;
using UnityEngine;

namespace Combination
{
    /// <summary>
    /// this screptable object used as holder for all combination plus
    /// it used for ui representation also 
    /// </summary>
    [CreateAssetMenu(menuName = "SO/CombinationData",fileName = "CombinationData")]
    public class CombinationData : ScriptableObject
    {
        [SerializeField] private CombinationEnum[] CombinationEnums;

        public CombinationEnum[] GetCombination()
        {
            return CombinationEnums;
        }

        public CombinationEnum GetAtIndex(int index)
        {
            return CombinationEnums[index];
        }
    }
}