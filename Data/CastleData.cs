using Engine;
using Engine.Data;
using UnityEngine;

namespace Custom.Data
{
    [CreateAssetMenu(fileName = "New Castle Data", menuName = "Add/Castle Data", order = 3)]
    public class CastleData : ScriptableObject,IAsset
    {
        public FieldKey<int> HP;
        public FieldKey<int> MaxHP;
        public FieldKey<int> MP;
        public FieldKey<int> MaxMP;

        public int initHP;
        public int initMP;
    }
}
