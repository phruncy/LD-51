using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class GrowOnTimerFinished : MonoBehaviour
	{
		[SerializeField]
		private Transform _transform;
		[SerializeField]
		private float _growthPerTimerFinished = 0.5f;

		private RepeatingTimer _timer;

		private void Start()
		{
			_timer = FindObjectOfType<RepeatingTimer>();
			_timer.OnFinished += Grow;
		}

		private void OnDestroy()
		{
			_timer.OnFinished -= Grow;
		}

		private void Grow()
		{
			_transform.localScale = _transform.localScale + Vector3.one * _growthPerTimerFinished;
		}

	}
}
