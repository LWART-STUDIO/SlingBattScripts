using System.Collections.Generic;
using Custom.Data;
using Engine.DI;
using UnityEngine;

namespace Custom.Logic.Cards.Main
{
    public class CardDataContainer : MonoBehaviour,IDependency,ICardDataContainer
    {
        [SerializeField] private List<CardData> _cardDatas;
        public List<CardData> CardDatas => _cardDatas;

        public void Inject()
        {
            DIContainer.RegisterAsSingle<ICardDataContainer>(this);
        }
    }

    public interface ICardDataContainer
    {
        public List<CardData> CardDatas { get; }
    }
}