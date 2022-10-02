using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Farm : MonoBehaviour
    {
        [SerializeField]
        private Node _node;
        public Node Node => _node;

        [SerializeField]
        private EnergyProducer _producer;
        public EnergyProducer Producer => _producer;

        [SerializeField]
        private FarmSettings _settings;

		private void Start()
		{
            _producer.EnergyProduction = _settings.BaseEnergyGerneration;
        }
	}
}
