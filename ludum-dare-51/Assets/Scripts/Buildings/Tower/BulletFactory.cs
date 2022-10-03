using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class BulletFactory : MonoBehaviour
    {
        [SerializeField]
        private Bullet _bulletPrefab;
        [SerializeField]
        private float _bulletSpeed = 8;

        public void Create(Vector3 origin, Vector3 target)
		{
            Bullet result = Instantiate(_bulletPrefab);
            result.transform.position = origin;
            Vector2 direction = target - origin;
            direction.Normalize();
            Vector2 force = direction * _bulletSpeed;
            result.Rigidbody.AddForce(force, ForceMode2D.Force);
        }
    }
}
