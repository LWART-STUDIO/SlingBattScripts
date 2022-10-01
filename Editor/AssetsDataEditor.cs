using System;
using Custom.Data;
using Custom.Logic;
using Custom.Logic.Cards.Main;
using Custom.Logic.LevelProgress;
using editor;
using Engine.Attribute;
using Engine.Senser;
using Engine.Store;
using Engine.Money;
using UnityEngine;
using Main.Level;
using Engine;

namespace Main.Editor
{
    [TemplateSettings(k_FilePath, k_FileName)]
    public class AssetsDataEditor : ScriptableObject, IResetData, IUnlock
    {
        internal const string k_FilePath = "Assets/Settings/Editor/";
        internal const string k_FileName = "AssetsData";

        [SerializeField] protected StoreInfo[] m_StoreInfos;
        [SerializeField] protected SenserInfo[] m_SenserInfos;
        [SerializeField] protected MoneyInfo[] m_MoneyInfos;
        [SerializeField] protected LevelsSettings[] m_LevelsData;
        [SerializeField] protected CardData[] m_CardsData;
        [SerializeField] protected ExperianceData[] m_ExpData;
        [SerializeField] protected PassData[] m_PassData;
        [SerializeField] protected CastleData[] m_CastleData;
        [SerializeField] protected LevelProgressRewardData[] m_LevelProgressRewardData;

        public virtual void ResetData(int idData)
        {
            m_StoreInfos = SearchAndInvoke<StoreInfo>((info, i) => info.ResetStoreData($"Store{i}"));
            m_SenserInfos = SearchAndInvoke<SenserInfo>((info, i) => info.ResetSenserData($"Senser{i}"));
            m_MoneyInfos = SearchAndInvoke<MoneyInfo>((info, i) => info.ResetMoneyData($"Money{i}"));
            m_LevelsData = SearchAndInvoke<LevelsSettings>((info, i) => info.ReseLevelsData($"LevelsData{i}"));
            m_CardsData = SearchAndInvoke<CardData>((info, i) => info.ResetCardData($"CardData{i}"));
            m_ExpData = SearchAndInvoke<ExperianceData>((info, i) => info.ResetExpData($"ExpData{i}"));
            m_PassData = SearchAndInvoke<PassData>((info, i) => info.ResetExpData($"PassData{i}"));
            m_CastleData = SearchAndInvoke<CastleData>((info, i) => info.ResetCastleData($"CastleData{i}"));
            m_LevelProgressRewardData = SearchAndInvoke<LevelProgressRewardData>((info, i) => info.ResetLevelProgressRewardData($"LevelProgressRewardData{i}"));

        }

        public virtual void Unlock()
        {
            m_StoreInfos = SearchAndInvoke<StoreInfo>((info, i) => info.UnlockStoreData($"Store{i}"));
            m_MoneyInfos = SearchAndInvoke<MoneyInfo>((info, i) => info.UnlockMoneyData($"Money{i}"));
            m_CardsData = SearchAndInvoke<CardData>((info, i) => info.UnlockCardData($"CardData{i}"));
            m_ExpData = SearchAndInvoke<ExperianceData>((info, i) => info.UnlockExpData($"ExpData{i}"));
            m_PassData = SearchAndInvoke<PassData>((info, i) => info.UnlockExpData($"PassData{i}"));
            m_CastleData = SearchAndInvoke<CastleData>((info, i) => info.UnlockCastleData($"CastleData{i}"));
            m_LevelProgressRewardData = SearchAndInvoke<LevelProgressRewardData>((info, i) => info.UnlockLevelProgressRewardData($"LevelProgressRewardData{i}"));
        }

        public static T[] SearchAndInvoke<T>(Action<T, int> actions) where T : ScriptableObject
        {
            T[] ts = AssetUtility.FindScribtableObjectsOfType<T>();

            for (int i = 0; i < ts.Length; i++)
            {
                if (ts[i] == null || ts[i].Equals(null)) continue;
                actions.Invoke(ts[i], i);
            }

            ts.SaveObjectsOfType();
            return ts;
        }
    }
}
