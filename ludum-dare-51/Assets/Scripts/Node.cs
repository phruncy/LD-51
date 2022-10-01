using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Node : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _sprite;

        public float Radius => _sprite.bounds.size.x / 2;
    }
}
