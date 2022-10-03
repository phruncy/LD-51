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
        [SerializeField]
        private bool _changeColor = true;

        private RepeatingTimer _timer;

		private void Start()
		{
            _timer = FindObjectOfType<RepeatingTimer>();
        }

		private void Update()
		{
            float percentage = _timer.Percentage;
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
