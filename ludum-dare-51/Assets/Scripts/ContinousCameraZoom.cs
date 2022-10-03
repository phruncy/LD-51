using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class ContinousCameraZoom : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;
        [SerializeField]
        private AnimationCurve _curve = AnimationCurve.Linear(0,0,1,1);
        [SerializeField]
        private float _maxZoom = 12f;
        [SerializeField]
        private float _secondsTillMaxZoom = 600;
        private float _startZoom;
        private float _currentTime = 0;

		private void Start()
		{
            _startZoom = _camera.orthographicSize;
        }

		private void Update()
		{
            _currentTime += Time.deltaTime;
            float delta = _maxZoom - _startZoom;
            float progress = _currentTime / _secondsTillMaxZoom;
            _camera.orthographicSize = _startZoom + delta * _curve.Evaluate(progress);
        }
	}
}
