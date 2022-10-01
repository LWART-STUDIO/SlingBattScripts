using Engine;
using Engine.Data;
using UnityEngine;

namespace Custom.Logic.LevelProgress
{
    [CreateAssetMenu(fileName = "New Level Progress Reward Data", menuName = "Add/Level Progress Reward Data", order = 3)]
    public class LevelProgressRewardData : ScriptableObject,IAsset
    {
        public FieldArray<bool> RewardClaiamed;
        public bool[] initRewardClaiamed;
    }

}