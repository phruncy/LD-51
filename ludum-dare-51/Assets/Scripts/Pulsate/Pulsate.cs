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
        private float _duration = 1;

        private float _currentTime = 0;
        private Vector3 _startScale;
        private float _intensity = 1;

		private void Start()
		{
            _startScale = _target.localScale;
        }

        public void StartPulse(float delay)
		{
            StartCoroutine(DoPulsate(delay));
		}

        public void SetIntensity(float value)
		{
            _intensity = value;
        }

        private IEnumerator DoPulsate(float delay)
		{
            _currentTime = 0;
            yield return new WaitForSeconds(delay);
            while(_currentTime < _duration)
			{
                _currentTime = _currentTime + Time.deltaTime;
                float scaleValue = _curve.Evaluate(_currentTime / _duration);
                float factor = 1 + (scaleValue - 1) * _intensity;
                _target.localScale = _startScale * factor;
                yield return 0;
            }
        }
	}
}
