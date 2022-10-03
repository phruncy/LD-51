using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField]
        private float _damage = 0.5f;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag =="Node")
            {
                DamageTaker damageTaker = collision.gameObject.GetComponentInParent<DamageTaker>();
                if (damageTaker)
                {
                    damageTaker.TakeDamage(_damage);
                }
            }
        }
    }
}
