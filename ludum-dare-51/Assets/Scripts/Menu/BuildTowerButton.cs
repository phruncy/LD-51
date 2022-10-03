using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class BuildTowerButton : BuildMenuOption
    {
        [SerializeField]
        private TowerSettings _settings;

        protected override ConstructionSettings ConstructionSettings => _settings.Levels[0].ConstructionSettings;
        protected override BuildingType BuildingType => BuildingType.Tower;
		protected override NodeColorSettings Colors => _settings.ColorSettings;
	}
}
