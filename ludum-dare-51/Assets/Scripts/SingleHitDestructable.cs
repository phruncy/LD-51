using System;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class SingleHitDestructable : Destructable
    {
        public event Action OnHit;
        [SerializeField]
        private List<string> _expectedColliderTags = new List<string>();

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_expectedColliderTags.Count == 0 ||
                _expectedColliderTags.Contains(collision.gameObject.tag))
                Destruct();
        }

		public override void Destruct()
        {
            OnHit?.Invoke();
            base.Destruct();
		}
	}
}
