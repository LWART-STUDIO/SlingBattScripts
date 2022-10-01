using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Custom.Logic.BattlePass
{
    public class CountBouble : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Sprite _done;
        [SerializeField] private Sprite _unDone;
        [SerializeField] private Image _image;
        

        public void SetUp(string text,bool done)
        {
            if (done)
            {
                _image.sprite = _done;
            }
            else
            {
                _image.sprite = _unDone;
            }
            _text.text = text;
        }
    }
}
