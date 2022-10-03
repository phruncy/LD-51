using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class NodeSlotColorLerper : MonoBehaviour
    {
        [SerializeField]
        private NodeSlot _slot;
        [SerializeField]
        private float _lerpTime = 0.2f;
        [SerializeField]
        private Color _defaultColor = Color.black;

        private float _currentTime;
        private Color _startColor;
        private Color _targetColor;

		private void Start()
		{
            _currentTime = _lerpTime;
            _startColor = _slot.Node.Color;
            _targetColor = GetTargetColor();
        }

		private void Update()
		{
            Color targetColor = GetTargetColor();

            if(_targetColor != targetColor)
			{
                _currentTime = 0;
                _startColor = _slot.Node.Color;
                _targetColor = targetColor;
            }

            if(_currentTime < _lerpTime)
			{
                _currentTime += Time.deltaTime;
                float progress = _currentTime / _lerpTime;
                _slot.Node.SetColor(Color.Lerp(_startColor, _targetColor, progress));
            }
        }

        private Color GetTargetColor()
		{
            return _slot.Content != null ? _slot.Content.Color : _defaultColor;
        }
	}
}
