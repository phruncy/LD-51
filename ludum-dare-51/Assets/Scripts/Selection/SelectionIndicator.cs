using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class SelectionIndicator : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _sprite;
        [SerializeField]
        private Selectable _selectable;
		[SerializeField]
		private float _showTime = 0.2f;
		[SerializeField]
		private float _hideTime = 0.2f;
		[SerializeField]
		private bool _shownOnStart = false;

		private float _currentTime = float.PositiveInfinity;
		private bool _show;

		private void Start()
		{
            _selectable.OnSelected += ShowIndicator;
            _selectable.OnDeselected += HideIndicator;
			_show = _selectable.Selected;
			UpdateAlpha(_shownOnStart ? 1 : 0);
		}

		private void OnDestroy()
		{
			_selectable.OnSelected -= ShowIndicator;
			_selectable.OnDeselected -= HideIndicator;
		}

		private void Update()
		{
			TryDoShow();
			TryDoHide();
		}

		private void TryDoShow()
		{
			if(_show)
				UpdateIndicator(_showTime, 1, 0);
		}

		private void TryDoHide()
		{
			if(!_show)
				UpdateIndicator(_hideTime, 0, 1);
		}

		private void UpdateIndicator(float targetTime, float targetValue, float formerValue)
		{
			if (_currentTime < targetTime)
			{
				_currentTime += Time.deltaTime;

				if (_currentTime >= targetTime)
				{
					UpdateAlpha(targetValue);
				}
				else
				{
					UpdateAlpha(Mathf.Lerp(formerValue, targetValue, _currentTime / targetTime));
				}
			}
		}

		private void HideIndicator()
		{
			_show = false;
			_currentTime = 0;
		}

		private void ShowIndicator()
		{
			_show = true;
			_currentTime = 0;
		}

		private void UpdateAlpha(float value)
		{
			Color c = _sprite.color;
			_sprite.color = new Color(c.r, c.g, c.b, value);
		}
	}
}
