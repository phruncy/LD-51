using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class SeedSlotsToControllerAdder : MonoBehaviour
    {
        [SerializeField]
        private SeedSlots _slots;

		private void Start()
		{
			FindObjectOfType<SeedsController>().Add(_slots);
		}
	}
}
