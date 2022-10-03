using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
	public class BuildFarmButton : BuildMenuOption
	{
		[SerializeField]
		private FarmSettings _settings;

		protected override ConstructionSettings ConstructionSettings => _settings.ConstructionSettings;
		protected override BuildingType BuildingType => BuildingType.Farm;
		protected override NodeColorSettings Colors => _settings.ColorSettings;
	}
}
