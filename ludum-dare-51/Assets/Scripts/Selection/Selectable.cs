using System;
using UnityEngine;

namespace LD51
{
    public class Selectable : MonoBehaviour
    {
		public event Action OnSelected;
		public event Action OnDeselected;
		public bool Selected { get; private set; } = false;
		

		internal void Deselect()
		{
			OnDeselected?.Invoke();
			Selected = false;
		}

		internal void Select()
		{
			OnSelected?.Invoke();
			Selected = true;
		}
	}
}
