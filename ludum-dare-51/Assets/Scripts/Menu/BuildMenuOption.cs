using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LD51
{
    public abstract class BuildMenuOption : NodeSlotMenuOption
    {
		[SerializeField]
		private Image _image;
		protected abstract ConstructionSettings ConstructionSettings { get; }
		protected abstract NodeColorSettings Colors { get; }
		protected abstract BuildingType BuildingType { get; }

		private ConstructionSiteFactory _constructionSiteFactory;
		private BuildingFactory _buildingFactory;

		protected override void Start()
		{
			base.Start();
			_image.color = Colors.MainColor;
			_constructionSiteFactory = FindObjectOfType<ConstructionSiteFactory>();
			_buildingFactory = FindObjectOfType<BuildingFactory>();
		}

		protected override void DoClickAction(NodeSlot slot)
		{
			_constructionSiteFactory.Create(slot, () => CreateBuilding(slot), ConstructionSettings, Colors);
		}

		private void CreateBuilding(NodeSlot slot)
		{
			_buildingFactory.Create(BuildingType, 1, slot);
		}
	}
}
