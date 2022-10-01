using System;
using Custom.Data;
using Custom.UI;
using Engine.DI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Custom.Logic.BattlePass
{
    public class PassReward : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private GameObject _buoughtMarker;
        [SerializeField] private Image _frame;
        [SerializeField] private Sprite _frameLocked;
        [SerializeField] private Sprite _frameUnlocked;
        [SerializeField] private TMP_Text _countText;
        [SerializeField] private Button _button;
        private ICastleInformant _castleInformant;
        private int _index;
        private bool _canBeBought;
        private bool _isBought;
        private RewardType _type;
        private IUIPanelsContainer _panelsContainer;
        private int _count;

        private void Start()
        {
            _castleInformant = DIContainer.AsSingle<ICastleInformant>();
            _panelsContainer = DIContainer.AsSingle<IUIPanelsContainer>();
        }

        public void SetUp(Sprite icon, bool isBought, bool canBeBought, int count,int index,RewardType type)
        {
            _countText.text = "" + count;
            _icon.sprite = icon;
            _canBeBought = canBeBought;
            _isBought = isBought;
            _type = type;
            _count = count;
            if (canBeBought)
            {
                if (isBought)
                {
                    _buoughtMarker.SetActive(true);
                    _frame.sprite = _frameLocked;
                }
                else
                {
                    _buoughtMarker.SetActive(false);
                    _frame.sprite = _frameUnlocked;
                }
            }
            else
            {
                _buoughtMarker.SetActive(false);
                _frame.sprite = _frameLocked;
            }

            _index = index;

        }

        private void Update()
        {
            if (_canBeBought&&!_isBought)
            {
                _button.interactable = true;
            }
            else
            {
                _button.interactable = false;
            }
        }

        public void Collect()
        {
            switch (_type)
            {
                case RewardType.Cards:
                    _panelsContainer.CardsPopUp.Active(false,false,false,true,0,null,_icon.sprite,_count);
                    break;
                case RewardType.Dimond:
                    _panelsContainer.DimondPopUp.Active(false,false,false,true,0,null,_icon.sprite,_count);
                    break;
                case RewardType.Money:
                    _panelsContainer.GoldPopUp.Active(false,false,false,true,0,null,_icon.sprite,_count);
                    break;
                case RewardType.GoldChest:
                    _panelsContainer.LootBox.Active(false,false,false,true,0,null,_icon.sprite,_count);
                    break;
                case RewardType.SilverChest:
                    _panelsContainer.LootBox.Active(false,false,false,true,0,null,_icon.sprite,_count);
                    break;
                case RewardType.WoodChest:
                    _panelsContainer.LootBox.Active(false,false,false,true,0,null,_icon.sprite,_count);
                    break;
            }
            Debug.Log("Collect");
            _castleInformant.PassData.isClaimRewards[_index] = true;
        }
    }
}
