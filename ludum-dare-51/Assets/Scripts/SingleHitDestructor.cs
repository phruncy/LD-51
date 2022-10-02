using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class SingleHitDestructor : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Node")
                InitializeDestruction();
        }

        private void InitializeDestruction()
        {
            Destroy(transform.gameObject);
        }
    }
}
