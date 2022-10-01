using Engine;
using Engine.Data;
using UnityEngine;

namespace Custom.Data
{
    [CreateAssetMenu(fileName = "New PassData", menuName = "Add/PassData", order = 1)]
    public class PassData : ScriptableObject,IAsset
    {
        public PassReward[] PassRewards; 
        public FieldArray<bool> isClaimRewards;
        public bool[] initClaimRewards;

    }
}
