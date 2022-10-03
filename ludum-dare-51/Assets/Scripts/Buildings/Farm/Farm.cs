using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Farm : Building
    {
        [SerializeField]
        private EnergyProducer _producer;
        [SerializeField]
        private FarmSettings _settings;
        [SerializeField]
        private SpriteRenderer _indicatorSprite;
        public EnergyProducer Producer => _producer;

		private void Start()
		{
            _indicatorSprite.color = _settings.ColorSettings.SideColor;
            _sprite.color = _settings.ColorSettings.MainColor;
        }

		public override void Init(Node node, int level)
		{
			base.Init(node, level);
            _producer.SetNode(node);
            _producer.EnergyProduction = _settings.BaseEnergyGerneration;
        }
	}
}
