using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
	public class FarmNodeMenu : RadialMenu
	{
		[SerializeField]
		private RadialMenuOption _upgradeButton;
		[SerializeField]
		private RadialMenuOption _buildTowerButton;
		private List<RadialMenuOption> _options;

		private Farm _farm;

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
				_upgradeButton,
				_buildTowerButton
			};
		}

		public void Set(Farm farm)
		{
			_farm = farm;
			SetupOptions();
		}

		private void SetupOptions()
		{
			_upgradeButton.Setup(() => Upgrade(_farm));
			_buildTowerButton.Setup(() => BuildTower(_farm));
		}

		private void Upgrade(Farm farm)
		{
			Debug.Log($"Upgrade {farm.name}");
			Dismiss();
		}

		private void BuildTower(Farm farm)
		{
			Debug.Log($"Build {farm.name}");
			Dismiss();
		}
	}
}
