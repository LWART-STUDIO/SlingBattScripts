using Engine;
using Engine.Data;
using UnityEngine;

namespace Custom.Logic
{
    [CreateAssetMenu(fileName = "New Exp Data", menuName = "Add/Exp Data", order = 3)]
    public class ExperianceData:ScriptableObject,IAsset
    {
        [SerializeField] private AnimationCurve _curve;
        [SerializeField] private int[] maxEps;
        public FieldKey<int> Level;
        public FieldKey<int> Exp;
        public int MaxLevel;
        public int initLevel;
        public int initExp;
        public int maxExp=>maxEps[Level.value];
        public int minExp=>maxEps[Level.value-1];
        public int MAXEXP;

        [NaughtyAttributes.Button()]
        private void SetUpCurve()
        {
            _curve = new AnimationCurve();
            Keyframe[] frames = new Keyframe[MaxLevel];
            for (int index = 1; index < frames.Length+1; index++)
            {
                Keyframe curveKey = frames[index-1];
                curveKey.value = MAXEXP/MaxLevel*index;
                curveKey.time = index;
                _curve.AddKey(curveKey);
                Debug.Log($"Key {index}, Value {curveKey.value}, Time {curveKey.time} ");
            }
        }
        [NaughtyAttributes.Button()]
        private void SetUpArray()
        {
            maxEps = new int[MaxLevel];
            for (int index = 0; index < maxEps.Length; index++)
            {
                maxEps[index] = (int)_curve[index].value;
            }
            
        }

    }
}