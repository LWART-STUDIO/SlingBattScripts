using System;
using System.Collections.Generic;
using Custom.UI;
using Engine.DI;
using UnityEngine;
using UnityEngine.UI;

namespace Custom.Logic.BattlePass
{
    public class PassSlyderControl : MonoBehaviour
    {

        [SerializeField] private SliderControl _sliderControl;
        [SerializeField] private Transform _spawnPoints;
        [SerializeField] private GameObject _CountPrefab;
        private float _height;
        private ICastleInformant _castleInformant;
        private List<CountBouble> _counts;

        public void SetUp(int count)
        {
            _counts = new List<CountBouble>();
            _castleInformant = DIContainer.AsSingle<ICastleInformant>();
           _height= gameObject.GetComponent<RectTransform>().rect.height;
           for (int i = 0; i < count; i++)
           {
             RectTransform trans=  Instantiate(_CountPrefab, new Vector3(0, 0, 0),Quaternion.identity ,_spawnPoints).GetComponent<RectTransform>();
             trans.localPosition = new Vector3((_height / count)*i, 0, 0);
             CountBouble coun=trans.GetComponent<CountBouble>();
             bool done;
             done = i <= _castleInformant.ExperianceData.Level.value-1;
             coun.SetUp($"{i+1}",done);
             _counts.Add(coun);
           }
           
        }

        public void SetCountUpdate()
        {
            for (int index = 0; index < _counts.Count; index++)
            {
                CountBouble countBouble = _counts[index];
                bool done;
                done = index <= _castleInformant.ExperianceData.Level.value - 1;
                countBouble.SetUp($"{index + 1}", done);
            }
        }

        private void Update()
        {
           _sliderControl.minValue = _castleInformant.ExperianceData.initExp;
           _sliderControl.maxValue = _castleInformant.ExperianceData.MAXEXP;
           _sliderControl.currentValue = _castleInformant.ExperianceData.Exp.value;

        }
    }
}
