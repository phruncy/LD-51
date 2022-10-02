using System;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class SingleHitDestructor : MonoBehaviour
    {
        public event Action OnHit;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Node")
                InitializeDestruction();


        }

        private void InitializeDestruction()
        {
            OnHit?.Invoke();
            Destroy(transform.gameObject);
        }
    }
}
