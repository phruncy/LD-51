using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LD51
{
    public class ToggleSelectionOnClick : MonoBehaviour, IPointerClickHandler
    {
		[SerializeField]
		private Selectable _selectable;
		Selection _selection;

		private void Start()
		{
			_selection = FindObjectOfType<Selection>();
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (_selection.Selected != _selectable)
				_selection.Select(_selectable);
			else
				_selection.Deselect();
		}
	}
}
