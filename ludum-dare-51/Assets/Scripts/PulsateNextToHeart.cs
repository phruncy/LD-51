using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class PulsateNextToHeart : MonoBehaviour
	{
		[SerializeField]
		private AnimationCurve _distanceCurve;
		[SerializeField]
		private float _maxDistance = 15;
		[SerializeField]
		private float _delayPerUnit = 0.02f;
		[SerializeField]
		private Pulsate _targetPulsate;
		private Heart _heart;

		private void Start()
		{
			_heart = FindObjectOfType<Heart>();
		}

		private void Update()
		{
			float distanceToHeart = (_targetPulsate.transform.position - _heart.transform.position).magnitude;
			_targetPulsate.SetDelay(distanceToHeart * _delayPerUnit);
			float intensity = 1 - Mathf.Clamp01((_maxDistance - distanceToHeart) / _maxDistance);
			_targetPulsate.SetIntensity(_distanceCurve.Evaluate(intensity));
		}
	}
}
