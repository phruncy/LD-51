using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
	public class FarmNodeMenuTogglerOnSelect : MenuTogglerOnSelect
	{
		[SerializeField]
		private Farm _farm;

		protected override Menu GetMenu()
		{
			FarmNodeMenu result = FindObjectOfType<FarmNodeMenu>(true);
			result.Set(_farm);
			return result;
		}
	}
}
