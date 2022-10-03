using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Seed : MonoBehaviour
    {
        public event Action OnDestruction; 

        [SerializeField]
        private SeedSettings _seedSettings;
        [SerializeField]
        private EnergyConsumer _energyConsumer;
        [SerializeField]
        private Node _node;
        [SerializeField]
        private SeedToTargetMover _moveToTarget;
        public SeedToTargetMover MoveToTarget => _moveToTarget;
        public EnergyConsumer EnergyConsumer => _energyConsumer;
        public Node Node => _node;

		private void Start()
		{
            _energyConsumer.SetRequiredEnergy(_seedSettings.GrowCosts);
            _energyConsumer.SetPriority(_seedSettings.Priority);
        }

        private void OnDestroy()
        {
            OnDestruction?.Invoke();
        }
    }
}
