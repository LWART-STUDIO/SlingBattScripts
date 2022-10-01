using Custom.Logic;

namespace Custom.Data
{
    public static class ExpDataExtension
    {
        public static void ResetExpData(this ExperianceData expData, string fileName)
        {
            expData.Level = new Engine.Data.FieldKey<int>("Level", fileName, expData.initLevel);
            expData.Exp = new Engine.Data.FieldKey<int>("Exp", fileName, expData.initExp);

        }

        public static void UnlockExpData(this ExperianceData expData, string fileName)
        {
            expData.Level = new Engine.Data.FieldKey<int>("Level", fileName, 30);
            expData.Exp = new Engine.Data.FieldKey<int>("Exp", fileName, 100000000);

        }
    }
}