using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LD51
{
    public class EnergyProvider : MonoBehaviour
    {
        private EnergyController _controller;
        private RepeatingTimer _timer;
		private Tree _tree;

		[SerializeField]
		private EnergyPath _pathPrefab;
		[SerializeField]
		private Energy _energyPrefab;
		[SerializeField]
		private EnergySettings _settings;

		private void Start()
		{
			_timer = FindObjectOfType<RepeatingTimer>();
			_controller = FindObjectOfType<EnergyController>();
			_tree = FindObjectOfType<Tree>();
			_timer.OnFinished += ProvideEnergy;
		}

		private void OnDestroy()
		{
			_timer.OnFinished -= ProvideEnergy;
		}

		private void ProvideEnergy()
		{
			List<EnergyController.EnergyTarget> targets = _controller.GetEnergyTargets();
			Debug.Log($"Energy sent {targets.Sum(t => t.EnergyAmount)}");
			foreach (EnergyController.EnergyTarget target in targets)
			{
				CreateEnergy(target);
			}
		}

		private void CreateEnergy(EnergyController.EnergyTarget target)
		{
			List<Node> waypoints = _tree.GetBranchesFromHeartTo(target.Consumer.Node).Select(b => b.Node).ToList();
			EnergyPath path = Instantiate(_pathPrefab);
			Energy energy = Instantiate(_energyPrefab);
			energy.Init(target.EnergyAmount);
			path.Init(waypoints, target, energy, _settings.EnergySpeed);
		}
	}
}
