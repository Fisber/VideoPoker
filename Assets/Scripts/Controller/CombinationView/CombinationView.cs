using TMPro;
using UnityEngine;
using System.Collections.Generic;

namespace Combination
{
    /// <summary>
    /// this class responsible for showing all the combination on the table
    /// using CombinationData scriptable object 
    /// </summary>
    public class CombinationView : MonoBehaviour
    {
        [SerializeField] private CombinationData combinationData;
        [SerializeField] private List<TextMeshProUGUI> CombinationText;

        private void Start()
        {
            InitializeCombination();
        }

        private void InitializeCombination()
        {
            var combinations = combinationData.GetCombination();

            for (int i = 0; i < combinations.Length; i++)
            {
                CombinationText[i].text = combinations[i].ToString();
            }
        }
    }
}