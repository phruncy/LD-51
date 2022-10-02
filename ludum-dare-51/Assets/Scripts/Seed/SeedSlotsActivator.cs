using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LD51
{
    public class SeedSlotsActivator : MonoBehaviour
    {
        [SerializeField]
        private SeedSettings _settings;
        [SerializeField]
        private SeedsController _seedsController;

		private void Start()
		{
			UpdateSeedSlotsActive();
		}

		private void Update()
		{
			UpdateSeedSlotsActive();
		}

		private void UpdateSeedSlotsActive()
		{
			foreach (SeedSlots slot in _seedsController.Slots)
			{
				UpdateSeedSlotsActive(slot);
			}
		}

		private void UpdateSeedSlotsActive(SeedSlots slots)
		{
			int validSeedAmount = (int) ((slots.Node.Radius - _settings.MinNodeSize + _settings.SlotOnSize) / _settings.SlotOnSize);
			int activeAmount = slots.Values.Count(s => s.Active);
			int activatabledSlotsAmount = validSeedAmount - activeAmount;
			int slotsLeftToActovate = slots.Values.Length - activeAmount;
			int slotsToUnlockAmount = Mathf.Min(activatabledSlotsAmount, slotsLeftToActovate);

			while(slotsToUnlockAmount > 0)
			{
				SeedSlot slot = _seedsController.GetRandomInactiveSeedSlot(slots);
				slot.Activate();
				slotsToUnlockAmount--;
			}
		}
	}
}
