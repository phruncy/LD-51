using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class HeartImpulse : MonoBehaviour
    {
        [SerializeField]
        private Transform _target;
        [SerializeField]
        private Transform _targetSizeObject;
        [SerializeField]
        private SpriteRenderer _indicator;
        [SerializeField]
        private Gradient _colorChange;

        private RepeatingTimer _timer;

		private void Start()
		{
            _timer = FindObjectOfType<RepeatingTimer>();
        }

		private void Update()
		{
            float percentage = _timer.Percentage;
            Color color = _colorChange.Evaluate(percentage);
            _indicator.color = color;
            _target.localScale = _targetSizeObject.localScale * percentage;
        }
	}
}
