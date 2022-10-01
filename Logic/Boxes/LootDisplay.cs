using Custom.Logic.PopUps;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Custom.Logic.Boxes
{
    public class LootDisplay:MonoBehaviour
    {
        [SerializeField] private Image _image;
        private INextLoot _nextLogic;
        public void SetUp(INextLoot lootBoxMain,Sprite sprite)
        {
            _nextLogic = lootBoxMain;
            _image.sprite = sprite;
            transform.DOScale(0, 0.2f).From();
        }

        public void Next()
        {
            _nextLogic.ShowNext();
            Destroy(gameObject);
        }
    }
}