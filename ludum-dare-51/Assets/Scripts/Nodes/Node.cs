using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Node : MonoBehaviour
    {
        public event Action OnLifeZero;

        [SerializeField]
        private SpriteRenderer _sprite;
        [SerializeField]
        private Collider2D _collider;
        [SerializeField]
        private Transform _lifeIndicatorTransform;

        public float Radius => _collider.bounds.size.x / 2;
        public Color Color => _sprite.color;
        public NodeHook Hook { get; set; }

        public void SetColor(Color color)
		{
            _sprite.color = color;
        }

        public void Destruct()
		{
            Destroy(Hook.gameObject);
		}

        public void SetHook(NodeHook hook)
		{
            Hook = hook;
        }

        public void Shrink(float damage)
        {
            if (damage > _lifeIndicatorTransform.localScale.x)
            {
                _lifeIndicatorTransform.localScale = Vector3.zero;
                OnLifeZero?.Invoke();
            }
            else
            {
                Vector3 decrease = Vector3.one * damage;
                _lifeIndicatorTransform.localScale -= decrease;
            }
        }
    }
}
