using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class BuildingFactory : MonoBehaviour
    {
		[SerializeField]
		private Farm _farmPrefab;
		[SerializeField]
		private Tower _towerPrefab;

        public void Create(BuildingType type, int level, NodeSlot slot)
		{
			Building building = CreateInternal(type);
			Init(building, level, slot);
		}

		private Building CreateInternal(BuildingType type)
		{
			switch (type)
			{
				case BuildingType.Farm:
					return CreateFarm();
				case BuildingType.Tower:
					return CreateTower();
				case BuildingType.None:
					throw new ArgumentException();
				default:
					throw new NotImplementedException();
			}
		}

		private Tower CreateTower()
		{
			return Instantiate(_towerPrefab);
		}

		private Farm CreateFarm()
		{
			return Instantiate(_farmPrefab);
		}

		private void Init(Building building, int level, NodeSlot slot)
		{
			building.Init(slot.Node, level);
			slot.SetContent(building);
		}
	}
}
