using UnityEngine;

namespace Custom.Data
{
    public static class CastleDataExtension 
    {
        public static void ResetCastleData(this CastleData castleData, string fileName)
        {
            castleData.HP = new Engine.Data.FieldKey<int>("HP", fileName, castleData.initHP);
            castleData.MP = new Engine.Data.FieldKey<int>("MP", fileName, castleData.initMP);
            castleData.MaxHP = new Engine.Data.FieldKey<int>("HP", fileName, castleData.initHP);
            castleData.MaxMP = new Engine.Data.FieldKey<int>("MP", fileName, castleData.initMP);
        }

        public static void UnlockCastleData(this CastleData castleData, string fileName)
        {
            castleData.HP = new Engine.Data.FieldKey<int>("HP", fileName, 999999999);
            castleData.MP = new Engine.Data.FieldKey<int>("MP", fileName, 999999999);
            castleData.MaxHP = new Engine.Data.FieldKey<int>("HP", fileName, 999999999);
            castleData.MaxMP = new Engine.Data.FieldKey<int>("MP", fileName, 999999999);
        }
    }
}
