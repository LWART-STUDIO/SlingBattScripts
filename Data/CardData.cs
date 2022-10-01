using Battle.Char;
using Engine;
using Engine.Data;
using UnityEngine;

namespace Custom.Data
{
    [CreateAssetMenu(fileName = "New Card Data", menuName = "Add/Cards/Card Data", order = 3)]
    public class CardData : ScriptableObject,IAsset
    {
        public string CardName;
        [NaughtyAttributes.ShowAssetPreview]
        public GameObject CardPrefab;
        [NaughtyAttributes.ShowAssetPreview]
        public GameObject SpawnObject;

        public GameObject InventoryCardPrefab;

        public FieldKey<int> CountOfCards;
        public FieldKey<int> Level;
        public FieldKey<bool> InInvenory;
       // public FighterSettings FighterSettings;
        public int initLevel;
        public int initCount;
        public bool initInInventory;
        public DefenderSettings DefenderSettings;
    }
}
