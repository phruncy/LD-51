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
        public void SetColor(Color color)
		{
            _sprite.color = color;
        }

        public void Shrink(float _damage)
        {
            if (_damage > _lifeIndicatorTransform.localScale.x)
                OnLifeZero?.Invoke();
            else
            {
                Vector3 decrease = Vector3.one * _damage;
                _lifeIndicatorTransform.localScale -= decrease;
            }
        }
    }
}
