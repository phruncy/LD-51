using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Heart : MonoBehaviour
    {
        [SerializeField]
        private Pulsate _pulsate;
        [SerializeField]
        private EnergyProducer _energyProducer;
        [SerializeField]
        private HeartSettings _heartSettings;
        [SerializeField]
        private Node _node;

        public Pulsate Pulsate => _pulsate;
        public Node Node => _node;

		private void Start()
		{
            _energyProducer.EnergyProduction = _heartSettings.BaseEnergyPerTick;
        }
	}
}
