using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Grow : MonoBehaviour
    {
        [SerializeField]
        private Transform _transform;
        [SerializeField]
        private float _growthPerSecond = 0.05f;

		private void Update()
		{
            float deltaTime = Time.deltaTime;
            float delta = _growthPerSecond * deltaTime;
            _transform.localScale = _transform.localScale + Vector3.one * delta;
        }
	}
}
