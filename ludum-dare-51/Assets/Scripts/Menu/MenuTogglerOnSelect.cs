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
			_selectable.OnSelected += Show;
			_selectable.OnDeselected += Hide;
		}

		protected abstract Menu GetMenu();

		private void OnDestroy()
		{
			_selectable.OnSelected -= Show;
			_selectable.OnDeselected -= Hide;
		}

		private void Show()
		{
			_menu = GetMenu();
			_menu.Show(Camera.main.WorldToScreenPoint(_selectable.transform.position));
			_menu.OnDismiss += OnDismiss;
			_menu.OnHide += OnHide;
		}

		private void Hide()
		{
			_menu.Hide();
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
