using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class SelfDestructingEnemyKiller : MonoBehaviour
    {
		[SerializeField]
		private Transform _baseTransform;

		private void OnCollisionEnter2D(Collision2D collision)
		{
			Enemy enemy = collision.collider.GetComponent<Enemy>();
			if (enemy == null)
				return;
			enemy.Destructable.Destruct();
			Destroy(_baseTransform.gameObject);
		}
	}
}
