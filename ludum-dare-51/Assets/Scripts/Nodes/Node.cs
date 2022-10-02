using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Node : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _sprite;
        [SerializeField]
        private Collider2D _collider;

        public float Radius => _collider.bounds.size.x / 2;
        public Color Color => _sprite.color;
    }
}
