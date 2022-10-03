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

        private void Start()
        {
            _consumer.OnPogress += UpdateView;
            _consumer.OnRequiredEnergyChanged += UpdateView;
            UpdateView();
        }

		private void OnDestroy()
        {
            _consumer.OnPogress -= UpdateView;
            _consumer.OnRequiredEnergyChanged -= UpdateView;
        }

        private void UpdateView()
        {
            float percentage = _consumer.Progress;
            ChangeColor(percentage);
            _target.localScale = _targetSizeObject.localScale * percentage;
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
