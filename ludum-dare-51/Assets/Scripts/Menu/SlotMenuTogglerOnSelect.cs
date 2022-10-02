using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
	public class SlotMenuTogglerOnSelect : MenuTogglerOnSelect
	{
		[SerializeField]
		private NodeSlot _slot;

		protected override Menu GetMenu()
		{
			SlotNodeMenu result = FindObjectOfType<SlotNodeMenu>(true);
			result.Set(_slot);
			return result;
		}
	}
}
