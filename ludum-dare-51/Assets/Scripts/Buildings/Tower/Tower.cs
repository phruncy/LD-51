using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public TowerLevelSettings LevelSettings => _towerSettings.Levels[Level];
        private List<Enemy> _enemiesInRange = new List<Enemy>();

		public event Action OnRangeChanged;

		public float Range => LevelSettings.Distance;
        public int ShotsLeft => _consumer.ProvidedEnergy / _towerSettings.EngeryPerAmonition;

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

        public void AddEnemy(Enemy enemy)
        {
            _enemiesInRange.Add(enemy);
        }

        public void Remove(Enemy enemy)
        {
            _enemiesInRange.Remove(enemy);
        }

        public void ReduceShots()
		{
            _consumer.Reduce(_towerSettings.EngeryPerAmonition);
        }

        internal Enemy GetClosestEnemy()
        {
            return _enemiesInRange.OrderBy(e => (e.transform.position - transform.position).magnitude).FirstOrDefault();
        }
    }
}
