using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class MoveToTarget : MonoBehaviour
    {
        [SerializeField]
        private float _timeToTarget = 1;
        [SerializeField]
        private AnimationCurve _curve = AnimationCurve.Linear(0, 0, 1, 1);

        public Vector3 Target { get; set; }
        private float _currentTime = 0;
        private Vector3 _startPos;

		private void Start()
		{
            _currentTime = _timeToTarget;
        }

		// Update is called once per frame
		void Update()
        {
            if (_currentTime >= _timeToTarget)
			{
                if (transform.position != Target)
                {
                    _currentTime = 0;
                    _startPos = transform.position;
                }
                else
				{
                    transform.position = Target;
                }
            }
            else
			{
                _currentTime += Time.deltaTime;
                Vector3 distanceVector = Target - _startPos;
                transform.position = _startPos + _curve.Evaluate(_currentTime / _timeToTarget) * distanceVector;
            }
        }
    }
}
