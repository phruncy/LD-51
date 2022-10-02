using System;
using UnityEngine;

namespace LD51
{
    public class MoveToTarget : MonoBehaviour
    {
        [SerializeField]
        private float _timeToTarget = 1;
        [SerializeField]
        private AnimationCurve _curve = AnimationCurve.Linear(0, 0, 1, 1);
        [SerializeField]
        private bool _useLocal;

        public Vector3 Target { get; set; }
        public event Action OnTargetReached;
        private float _currentTime = 0;
        private Vector3 _startPos;

		private void Start()
		{
            _currentTime = _timeToTarget;
        }

		// Update is called once per frame
		void Update()
        {
            Vector3 position = _useLocal ? transform.localPosition : transform.position;
            if (_currentTime >= _timeToTarget)
			{
                if (position != Target)
                {
                    _currentTime = 0;
                    _startPos = position;
                }
                else
				{
                    SetPosition(Target);
                    OnTargetReached?.Invoke();
                }
            }
            else
			{
                _currentTime += Time.deltaTime;
                Vector3 distanceVector = Target - _startPos;
                SetPosition(_startPos + _curve.Evaluate(_currentTime / _timeToTarget) * distanceVector);
            }
        }

		private void SetPosition(Vector3 value)
		{
            if (_useLocal)
                transform.localPosition = value;
            else
                transform.position = value;
        }
	}
}
