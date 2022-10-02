using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class EnergyConsumerColorizer : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _sprite;
        [SerializeField]
        private Gradient _colorChange;
        [SerializeField]
        private EnergyConsumer _consumer;
        [SerializeField]
        private float _lerpTime = 0.2f;

        private float _currentRealtime = 0;
        private float _targetTime = 0;
        private float _startTime = 0;

        private void Start()
        {
            _consumer.OnPogress += UpdateView;
            _consumer.OnRequiredEnergyChanged += UpdateView;
            _startTime = _consumer.Progress;
            _sprite.color = _colorChange.Evaluate(_startTime);
            UpdateView();
        }

		private void OnDestroy()
        {
            _consumer.OnPogress -= UpdateView;
            _consumer.OnRequiredEnergyChanged -= UpdateView;
        }

		private void Update()
		{
            if (_currentRealtime >= _lerpTime)
                return;

            _currentRealtime += Time.deltaTime;
            float lerpPercentage = _currentRealtime / _lerpTime;
            float time = Mathf.Lerp(_startTime, _targetTime, lerpPercentage);
            _sprite.color = _colorChange.Evaluate(time);

            if (_currentRealtime >= _lerpTime)
			{
                _startTime = _targetTime;
            }
        }

		private void UpdateView()
        {
            _targetTime = _consumer.Progress;
            _currentRealtime = 0;
        }
    }
}
