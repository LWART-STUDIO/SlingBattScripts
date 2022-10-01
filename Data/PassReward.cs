using UnityEngine;

namespace Custom.Data
{
    [CreateAssetMenu(fileName = "New PassReward", menuName = "Add/PassReward", order = 1)]
    public class PassReward:ScriptableObject
    {
        public RewardType RewardType;
        public int count;
    }
}