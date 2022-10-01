using System;
using System.Collections.Generic;
using Custom.Data;
using Engine.DI;
using UnityEngine;
using UnityEngine.UI;

namespace Custom.Logic.BattlePass
{
    public class BattlePassControl : MonoBehaviour
    {
        [SerializeField] private GameObject _rewardPrefab;
        [SerializeField] private PassData _passData;
        [SerializeField] private PassSlyderControl _slyderControl;
        [SerializeField] private List<PassReward> _passRewards;
        [SerializeField] private Sprite _moneySprite;
        [SerializeField] private Sprite _woodChestSprite;
        [SerializeField] private Sprite _silverChestSprite;
        [SerializeField] private Sprite _goldChestSprite;
        [SerializeField] private Sprite _dimondSprite;
        [SerializeField] private Sprite _cardsSprite;
        [SerializeField] private RectTransform _content;
        private ICastleInformant _castleInformant;

        private void OnEnable()
        {
            _content.localPosition =new Vector3(0,-99999);
        }

        public void Start()
        {
            _castleInformant = DIContainer.AsSingle<ICastleInformant>();
            for (int index = 0; index < _passData.PassRewards.Length; index++)
            {
                var passReward = _passData.PassRewards[index];
                PassReward pReward = Instantiate(_rewardPrefab, transform).GetComponent<PassReward>();
                bool canBevought;
                switch (passReward.RewardType)
                {
                    case RewardType.Money:
                        canBevought = _castleInformant.ExperianceData.Level.value >= (index + 1);
                        pReward.SetUp(_moneySprite,_passData.isClaimRewards[index],canBevought,_passData.PassRewards[index].count,index,RewardType.Money);
                        break;
                    case RewardType.GoldChest:
                        canBevought = _castleInformant.ExperianceData.Level.value >= (index + 1);
                        pReward.SetUp(_goldChestSprite,_passData.isClaimRewards[index],canBevought,_passData.PassRewards[index].count,index,RewardType.GoldChest);
                        break;
                    case RewardType.SilverChest:
                        canBevought = _castleInformant.ExperianceData.Level.value >= (index + 1);
                        pReward.SetUp(_silverChestSprite,_passData.isClaimRewards[index],canBevought,_passData.PassRewards[index].count,index,RewardType.SilverChest);
                        break;
                    case RewardType.WoodChest:
                        canBevought = _castleInformant.ExperianceData.Level.value >= (index + 1);
                        pReward.SetUp(_woodChestSprite,_passData.isClaimRewards[index],canBevought,_passData.PassRewards[index].count,index,RewardType.WoodChest);
                        break;
                    case RewardType.Dimond:
                        canBevought = _castleInformant.ExperianceData.Level.value >= (index + 1);
                        pReward.SetUp(_dimondSprite,_passData.isClaimRewards[index],canBevought,_passData.PassRewards[index].count,index,RewardType.Dimond);
                        break;
                    case RewardType.Cards:
                        canBevought = _castleInformant.ExperianceData.Level.value >= (index + 1);
                        pReward.SetUp(_cardsSprite,_passData.isClaimRewards[index],canBevought,_passData.PassRewards[index].count,index,RewardType.Cards);
                        break;
                }
                
                _passRewards.Add(pReward);
            }

            _slyderControl.SetUp(_passRewards.Count);
        }

        public void Update()
        {
            for (int index = 0; index < _passRewards.Count; index++)
            {
                var pReward = _passRewards[index];
                bool canBevought;
                switch (_passData.PassRewards[index].RewardType)
                {
                    case RewardType.Money:
                        canBevought = _castleInformant.ExperianceData.Level.value >= (index + 1);
                        pReward.SetUp(_moneySprite,_passData.isClaimRewards[index],canBevought,_passData.PassRewards[index].count,index,RewardType.Money);
                        break;
                    case RewardType.GoldChest:
                        canBevought = _castleInformant.ExperianceData.Level.value >= (index + 1);
                        pReward.SetUp(_goldChestSprite,_passData.isClaimRewards[index],canBevought,_passData.PassRewards[index].count,index,RewardType.GoldChest);
                        break;
                    case RewardType.SilverChest:
                        canBevought = _castleInformant.ExperianceData.Level.value >= (index + 1);
                        pReward.SetUp(_silverChestSprite,_passData.isClaimRewards[index],canBevought,_passData.PassRewards[index].count,index,RewardType.SilverChest);
                        break;
                    case RewardType.WoodChest:
                        canBevought = _castleInformant.ExperianceData.Level.value >= (index + 1);
                        pReward.SetUp(_woodChestSprite,_passData.isClaimRewards[index],canBevought,_passData.PassRewards[index].count,index,RewardType.WoodChest);
                        break;
                    case RewardType.Dimond:
                        canBevought = _castleInformant.ExperianceData.Level.value >= (index + 1);
                        pReward.SetUp(_dimondSprite,_passData.isClaimRewards[index],canBevought,_passData.PassRewards[index].count,index,RewardType.Dimond);
                        break;
                    case RewardType.Cards:
                        canBevought = _castleInformant.ExperianceData.Level.value >= (index + 1);
                        pReward.SetUp(_cardsSprite,_passData.isClaimRewards[index],canBevought,_passData.PassRewards[index].count,index,RewardType.Cards);
                        break;
                }
            }
            _slyderControl.SetCountUpdate();
        }
    }
}
