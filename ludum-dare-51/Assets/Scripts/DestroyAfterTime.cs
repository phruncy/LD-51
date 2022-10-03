using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class DestroyAfterTime : MonoBehaviour
    {
        [SerializeField]
        private float _timeInSeconds = 20f;
		private float _timeLeft;

		private void Start()
		{
			_timeLeft = _timeInSeconds;
		}

		private void Update()
		{
			_timeLeft -= Time.deltaTime;
			if (_timeLeft <= 0)
				Destroy(gameObject);
		}
	}
}
