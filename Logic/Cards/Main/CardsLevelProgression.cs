using Engine.DI;
using UnityEngine;

namespace Custom.Logic.Cards.Main
{
    public class CardsLevelProgression : MonoBehaviour,IDependency
    {
        [SerializeField] private AnimationCurve _curve;
        [SerializeField] private int _maxLevel;
        [SerializeField] private int _maxCardPerLevel;
        [SerializeField] private int[] _cardsPerLevel;
        public int[] CardsPerLevel => _cardsPerLevel;

        [NaughtyAttributes.Button()]
        private void SetUpCurve()
        {
            _curve = new AnimationCurve();
            Keyframe[] frames = new Keyframe[_maxLevel];
            for (int index = 0; index < frames.Length; index++)
            {
                Keyframe curveKey = frames[index];
                curveKey.value = _maxCardPerLevel/(_maxCardPerLevel-index) ;
                curveKey.time = index;
                _curve.AddKey(curveKey);
                Debug.Log($"Key {index}, Value {curveKey.value}, Time {curveKey.time} ");
            }
        }
        [NaughtyAttributes.Button()]
        private void SetUpArray()
        {
            _cardsPerLevel = new int[_maxLevel];
            for (int index = 0; index < _cardsPerLevel.Length; index++)
            {
                _cardsPerLevel[index] = (int)_curve[index].value;
            }
            
        }

        public void Inject()
        {
            DIContainer.RegisterAsSingle(this);
        }
    }
}
