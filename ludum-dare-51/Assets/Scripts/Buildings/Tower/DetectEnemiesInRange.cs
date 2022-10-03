using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LD51
{
    public class DetectEnemiesInRange : MonoBehaviour
    {
        [SerializeField]
        private Tower _tower;

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.tag != "Enemy")
				return;
			Enemy enemy = collision.GetComponent<Enemy>();
			if (enemy != null)
				_tower.AddEnemy(enemy);
		}

		private void OnTriggerExit2D(Collider2D collision)
		{
			if (collision.tag != "Enemy")
				return;
			Enemy enemy = collision.GetComponent<Enemy>();
			if (enemy != null)
				_tower.Remove(enemy);
		}
	}
}
