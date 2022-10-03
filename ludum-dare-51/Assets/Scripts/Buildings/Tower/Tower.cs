using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Tower : MonoBehaviour
    {
        [SerializeField]
        private Node _node;
        [SerializeField]
        private EnergyConsumer _consumer;
        [SerializeField]
        private TowerSettings _towerSettings;

        public int Level { get; set; } = 0;
        public int TargetLevel { get; set; } = 1;

		private void Start()
		{
            _consumer.SetRequiredEnergy(_towerSettings.Levels[0].Ammonition * _towerSettings.EngeryPerAmonition);
        }
	}
}
