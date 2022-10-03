using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class SeedSlotsToControllerAdder : MonoBehaviour
    {
        [SerializeField]
        private SeedSlots _slots;
		private SeedsController _controller;

		private void Start()
		{
			_controller = FindObjectOfType<SeedsController>();
			_controller.Add(_slots);
		}

		private void OnDestroy()
		{
			_controller?.Remove(_slots);
		}
	}
}
