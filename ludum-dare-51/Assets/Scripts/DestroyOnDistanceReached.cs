using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class DestroyOnDistanceReached : MonoBehaviour
    {
        [SerializeField]
        private float _distance = 20f;
		private Vector3 _start;

		private void Start()
		{
			_start = transform.position;
		}

		private void Update()
		{
			if ((_start - transform.position).magnitude >= _distance)
				Destroy(gameObject);
		}
	}
}
