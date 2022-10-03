using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class AttackEnemiesInRange : MonoBehaviour
    {
        [SerializeField]
        private Tower _tower;

		private float _timerTillNextShot = 0;

		private void Update()
		{
			if (_timerTillNextShot <= 0)
				TryShoot();
			if (_timerTillNextShot > 0)
				_timerTillNextShot -= Time.deltaTime;
		}

		private void TryShoot()
		{
			if (_tower.ShotsLeft <= 0)
				return;
			Enemy closest = _tower.GetClosestEnemy();
			if (closest == null)
				return;
			_timerTillNextShot = _tower.LevelSettings.Delay;
			_tower.ReduceShots();
		}
	}
}
