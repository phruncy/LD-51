using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigidbody;
        public Rigidbody2D Rigidbody => _rigidbody;
    }
}
