using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
	public abstract class Menu : MonoBehaviour
	{
		public event Action OnDismiss;
		public event Action OnHide;

		public abstract void Show(Vector3 position);
		public abstract void Show();

		public void Hide()
		{
			DoHide();
			OnHide?.Invoke();
		}

		protected abstract void DoHide();

		protected void Dismiss()
		{
			OnDismiss?.Invoke();
		}
	}
}
