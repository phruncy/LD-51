using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Pulsate : MonoBehaviour
    {
        [SerializeField]
        private AnimationCurve _curve;
        [SerializeField]
        private Transform _target;
        [SerializeField]
        private float _interterval = 1;

        private float _currentTime = 0;
        private Vector3 _startScale;

		private void Start()
		{
            _startScale = _target.localScale;
        }

		private void Update()
		{
            _currentTime = (_currentTime + Time.deltaTime) % _interterval;
            float scaleValue = _curve.Evaluate(_currentTime / _interterval % 1);
            _target.localScale = _startScale * scaleValue;
        }
	}
}
