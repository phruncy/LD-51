using System;
using UnityEngine;

namespace LD51
{
    public abstract class MenuTogglerOnSelect : MonoBehaviour
    {
		[SerializeField]
		private Selectable _selectable;
		private Menu _menu;
		private Selection _selection;

		private void Start()
		{
			_selection = FindObjectOfType<Selection>();
			_menu = GetMenu();
			_selectable.OnSelected += Show;
			_selectable.OnDeselected += _menu.Hide;
		}

		protected abstract Menu GetMenu();

		private void OnDestroy()
		{
			_selectable.OnSelected -= Show;
			_selectable.OnDeselected -= _menu.Hide;
		}

		private void Show()
		{
			_menu.Show(_selectable.transform.position);
			_menu.OnDismiss += OnDismiss;
			_menu.OnHide += OnHide;
		}

		private void OnDismiss()
		{
			_selection.Deselect();
		}

		private void OnHide()
		{
			_menu.OnHide -= OnHide;
			_menu.OnDismiss -= OnDismiss;
		}
	}
}
