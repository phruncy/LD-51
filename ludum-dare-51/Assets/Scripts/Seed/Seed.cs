using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Seed : MonoBehaviour
    {
        [SerializeField]
        private SeedSettings _seedSettings;
        [SerializeField]
        private EnergyConsumer _energyConsumer;
        [SerializeField]
        private Node _node;
        [SerializeField]
        private MoveToTarget _moveToTarget;
        public MoveToTarget MoveToTarget => _moveToTarget;
        public Node Node => _node;

		private void Start()
		{
            _energyConsumer.SetRequiredEnergy(_seedSettings.GrowCosts);
        }
	}
}
