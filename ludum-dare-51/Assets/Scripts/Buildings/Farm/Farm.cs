using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Farm : MonoBehaviour, INodeSlotObject
    {
        [SerializeField]
        private Node _node;
        [SerializeField]
        private EnergyProducer _producer;
        [SerializeField]
        private SpriteRenderer _sprite;
        [SerializeField]
        private FarmSettings _settings;

        public Node Node => _node;
        public EnergyProducer Producer => _producer;
        public Transform Base => transform;
		public Color Color => _sprite.color;

		public event Action OnDestruct;

		private void Start()
		{
            _producer.EnergyProduction = _settings.BaseEnergyGerneration;
        }

		private void OnDestroy()
		{
            OnDestruct?.Invoke();
        }
	}
}
