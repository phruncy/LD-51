using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Attatch : MonoBehaviour
    {
		private Transform _target;

		public void Init(Transform target)
		{
			_target = target;
			Update();
		}

		private void Update()
		{
			transform.position = _target.position;
			transform.rotation = _target.rotation;
		}
	}
}
