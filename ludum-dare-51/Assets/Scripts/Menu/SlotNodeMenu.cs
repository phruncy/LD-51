using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
	public class SlotNodeMenu : RadialMenu
	{
		[SerializeField]
		private RadialMenuOption _farmButton;
		[SerializeField]
		private RadialMenuOption _towerButton;
		private List<RadialMenuOption> _options;

		private NodeSlot _slot;

		protected override List<RadialMenuOption> GetOptions()
		{
			SetupOptions();
			return _options;
		}

		private void Start()
		{
			gameObject.SetActive(false);
			_options = new List<RadialMenuOption>
			{
				_farmButton,
				_towerButton
			};
		}

		public void Set(NodeSlot slot)
		{
			_slot = slot;
			SetupOptions();
		}

		private void SetupOptions()
		{
			_farmButton.Setup(() => Upgrade(_slot));
			_towerButton.Setup(() => BuildTower(_slot));
		}

		private void Upgrade(NodeSlot slot)
		{
			Debug.Log($"Upgrade {slot.name}");
			Dismiss();
		}

		private void BuildTower(NodeSlot farm)
		{
			Debug.Log($"Build {farm.name}");
			Dismiss();
		}
	}
}
