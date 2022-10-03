using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
	public class SlotNodeMenu : RadialMenu
	{
		[SerializeField]
		private List<NodeSlotMenuOption> _options = new List<NodeSlotMenuOption>();

		private NodeSlot _slot;

		protected override List<NodeSlotMenuOption> GetOptions()
		{
			SetupOptions();
			return _options;
		}

		private void Start()
		{
			gameObject.SetActive(false);
		}

		public void Set(NodeSlot slot)
		{
			_slot = slot;
			SetupOptions();
		}

		private void SetupOptions()
		{
			foreach (NodeSlotMenuOption option in _options)
			{
				option.Setup(_slot);
				option.DismissAction = Dismiss;
			}
		}
	}
}
