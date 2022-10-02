using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Grow : MonoBehaviour
    {
        [SerializeField]
        private Transform _transform;
        [SerializeField]
        private AnimationCurve _growthFactor;
        [SerializeField]
        private float _maxSize = 5;
        [SerializeField]
        private float _growthPerSecond = 0.15f;

        public Transform Transform => _transform;
        public float MaxSize => _maxSize;


		private void Update()
		{
            float deltaTime = Time.deltaTime;
            float scalePercentage = _transform.localScale.x / _maxSize;
            float delta = _growthFactor.Evaluate(scalePercentage) * _growthPerSecond * deltaTime;
            _transform.localScale += Vector3.one * delta;
        }
	}
}
