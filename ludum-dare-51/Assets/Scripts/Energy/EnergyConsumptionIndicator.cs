using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class EnergyConsumptionIndicator : MonoBehaviour
    {
        [SerializeField]
        private Transform _target;
        [SerializeField]
        private Transform _targetSizeObject;
        [SerializeField]
        private SpriteRenderer _indicator;
        [SerializeField]
        private Gradient _colorChange;
        [SerializeField]
        private EnergyConsumer _consumer;
        [SerializeField]
        private bool _changeColor = true;
        [SerializeField]
        private float _lerpTime = 0.2f;

        private float _currentTime;
        private float _currentPercentage;
        private float _startPercentage;
        private float _targetPercentage;

        private void Start()
        {
            UpdateView();
        }

		private void Update()
		{
            UpdateView();
        }

		private void UpdateView()
        {
            float targetPercentage = _consumer.Progress;

            if (_targetPercentage != targetPercentage)
            {
                _currentTime = 0;
                _startPercentage = _currentPercentage;
                _targetPercentage = targetPercentage;
            }

            if (_currentTime < _lerpTime)
            {
                _currentTime += Time.deltaTime;
                float progress = _currentTime / _lerpTime;
                _currentPercentage = Mathf.Lerp(_startPercentage, _targetPercentage, progress);
                ChangeColor(_currentPercentage);
                _target.localScale = _targetSizeObject.localScale * _currentPercentage;
            }

           
        }

		private void ChangeColor(float percentage)
		{
            if (!_changeColor)
                return;
            Color color = _colorChange.Evaluate(percentage);
            _indicator.color = color;
        }
    }
}
