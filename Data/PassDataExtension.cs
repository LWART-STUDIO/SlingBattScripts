using Engine.Data;

namespace Custom.Data
{
    public static class PassDataExtension
    {
        public static void ResetExpData(this PassData passData, string fileName)
        {
            if (passData.PassRewards != null && passData.PassRewards.Length != 0)
            {
                passData.isClaimRewards = new FieldArray<bool>("RewardClaimed", fileName, passData.PassRewards.Length);
            }

        }

        public static void UnlockExpData(this PassData passData, string fileName)
        {
            if (passData.PassRewards != null && passData.PassRewards.Length != 0)
            {
                passData.isClaimRewards = new FieldArray<bool>("RewardClaimed", fileName, passData.PassRewards.Length);
                
                for (int i = 0; i < passData.PassRewards.Length; i++)
                {
                    passData.isClaimRewards[i] = true;
                }
            }

        }
    }
}