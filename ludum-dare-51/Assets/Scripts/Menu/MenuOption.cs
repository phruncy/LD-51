using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LD51
{
    public abstract class MenuOption : MonoBehaviour
	{
		[SerializeField]
		private Button _button;
		public Action DismissAction { get; set; }


		protected virtual void Start()
		{
			_button.onClick.AddListener(OnClick);
		}

		protected virtual void OnDestroy()
		{
			_button.onClick.RemoveListener(OnClick);
		}

		public void Show()
		{
			transform.gameObject.SetActive(true);
		}

		public void Hide()
		{
			transform.gameObject.SetActive(false);
		}

		private void OnClick()
		{
			DoOnClick();
			DismissAction?.Invoke();
		}

		protected abstract void DoOnClick();
	}
}
