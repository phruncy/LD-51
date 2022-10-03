using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Tower : Building
    {
        [SerializeField]
        private EnergyConsumer _consumer;
        [SerializeField]
        private TowerSettings _towerSettings;
        [SerializeField]
        private SpriteRenderer _indicatorSprite;

        private TowerLevelSettings LevelSettings => _towerSettings.Levels[Level];

        public event Action OnRangeChanged;
        public float Range => LevelSettings.Distance;

        private void Start()
		{
            _indicatorSprite.color = _towerSettings.ColorSettings.SideColor;
            _sprite.color = _towerSettings.ColorSettings.MainColor;
        }

        public override void Init(Node node, int level)
        {
            base.Init(node, level);
            _consumer.SetRequiredEnergy(_towerSettings.Levels[level - 1].Ammonition * _towerSettings.EngeryPerAmonition);
            _consumer.SetNode(node);
            _consumer.SetPriority(_towerSettings.ConsumptionPrio);
            _consumer.Provide(_consumer.RequiredEnergy);
            OnRangeChanged?.Invoke();
        }
    }
}
