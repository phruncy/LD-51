using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class EnergyProducerToCollectionAdder : MonoBehaviour
    {
        [SerializeField]
        private EnergyProducer _producer;

		private void Start()
		{
			FindObjectOfType<EnergyController>().Add(_producer);
		}
	}
}
