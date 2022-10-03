using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public abstract class Building : MonoBehaviour, INodeSlotObject
    {
        [SerializeField]
        protected SpriteRenderer _sprite;

        public Node Node { get; private set; }
        public int Level { get; private set; }

        public Transform Base => transform;

        public Color Color => _sprite.color;

		public event Action OnDestruct;

        public virtual void Init(Node node, int level)
        {
            Node = node;
            Level = level;
        }

        private void OnDestroy()
        {
            OnDestruct?.Invoke();
        }
    }
}
