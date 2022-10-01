using Engine.Data;

namespace Custom.Logic.LevelProgress
{
    public static class LevelProgressExtension
    {
        public static void ResetLevelProgressRewardData(this LevelProgressRewardData levelProgressRewardData, string fileName)
        {
            if (levelProgressRewardData.initRewardClaiamed != null &&
                levelProgressRewardData.initRewardClaiamed.Length != 0)
            {
                levelProgressRewardData.RewardClaiamed = new FieldArray<bool>("Level", fileName,
                    levelProgressRewardData.initRewardClaiamed.Length);
                for (int i = 0; i < levelProgressRewardData.initRewardClaiamed.Length; i++)
                {
                    levelProgressRewardData.RewardClaiamed[i] = levelProgressRewardData.initRewardClaiamed[i];
                }
            }

        }

        public static void UnlockLevelProgressRewardData(this LevelProgressRewardData levelProgressRewardData, string fileName)
        {
            if (levelProgressRewardData.initRewardClaiamed != null &&
                levelProgressRewardData.initRewardClaiamed.Length != 0)
            {
                levelProgressRewardData.RewardClaiamed = new FieldArray<bool>("Level", fileName,
                    levelProgressRewardData.initRewardClaiamed.Length);
                
                for (int i = 0; i < levelProgressRewardData.initRewardClaiamed.Length; i++)
                {
                    levelProgressRewardData.RewardClaiamed[i] = true;
                }
            }
        }
    }
}