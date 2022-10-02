using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class EnergyConsumerToCollectionAdder : MonoBehaviour
    {
        [SerializeField]
        private EnergyConsumer _consumer;

		private void Start()
		{
			FindObjectOfType<EnergyController>().Add(_consumer);
		}
	}
}
