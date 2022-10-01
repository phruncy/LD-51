using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LD51
{
    public class SeedsController : MonoBehaviour
    {
        private List<SeedSlot> _slots = new List<SeedSlot>();
        private System.Random _random;

        private void Start()
        {
            _random = new System.Random();
        }

        public void Add(SeedSlot slot)
		{
            _slots.Add(slot);
        }

        public void Add(SeedSlots slots)
		{
            _slots.AddRange(slots.Values);
        }

        public void Remove(SeedSlot slot)
		{
            _slots.Remove(slot);
        }

        public SeedSlot GetRandomSeedSlot()
        {
            List<SeedSlot> unoccupiedSlots = _slots.Where(v => !v.Occupied).ToList();
            if (unoccupiedSlots.Count == 0)
                return null;
            return unoccupiedSlots[_random.Next(unoccupiedSlots.Count)];
        }
    }
}
