using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace LD51
{
    public class RadialMenuOption : MonoBehaviour
    {
		[SerializeField]
		private Button _button;
		private UnityAction _currentAction;

		public void Show()
		{
			transform.gameObject.SetActive(true);
		}

		public void Hide()
		{
			transform.gameObject.SetActive(false);
		}

		public void Setup(UnityAction action)
		{
			if (_currentAction != null)
				_button.onClick.RemoveListener(_currentAction);
			_currentAction = action;
			if(_currentAction != null)
				_button.onClick.AddListener(_currentAction);
		}
	}
}
