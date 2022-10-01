using UnityEngine;

namespace Custom.Logic.Boxes
{
    [System.Serializable]
    public struct Loot
    {
        [NaughtyAttributes.ShowAssetPreview()]
        public Sprite Sprite;
        [NaughtyAttributes.ShowAssetPreview()]
        public GameObject Object;

        public string ItemType;
        public string ItemName;
        public int ItemValue;
    }
}