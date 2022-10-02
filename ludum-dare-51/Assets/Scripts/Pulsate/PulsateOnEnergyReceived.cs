using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class PulsateOnEnergyReceived : MonoBehaviour
	{
		[SerializeField]
		private EnergyConsumer _energyConsumer;
		[SerializeField]
		private Pulsate _targetPulsate;

		private void Start()
		{
			_energyConsumer.OnPogress += StartPulse;
		}

		private void OnDestroy()
		{
			_energyConsumer.OnPogress -= StartPulse;
		}

		private void StartPulse()
		{
			_targetPulsate.StartPulse(0);
		}
	}
}
