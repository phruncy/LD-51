using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Selection : MonoBehaviour
    {
		[SerializeField]
		private EscapeHandler _escapeHandler;

		public event Action OnSelect;
		public Selectable Selected { get; private set; }

		private void Start()
		{
			_escapeHandler = FindObjectOfType<EscapeHandler>();
		}

		public void Select(Selectable selectable)
		{
			Deselect();
			Selected = selectable;
			if (Selected != null)
			{
				Selected.Select();
				if (_escapeHandler.Contains(Deselect))
					_escapeHandler.Remove(Deselect);
				_escapeHandler.Add(Deselect);
				OnSelect?.Invoke();
			}
			
		}

		public void Deselect()
		{
			if (Selected != null)
				Selected.Deselect();
			Selected = null;
			if (_escapeHandler.Contains(Deselect))
				_escapeHandler.Remove(Deselect);
		}
	}
}
