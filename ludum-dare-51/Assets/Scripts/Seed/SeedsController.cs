using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LD51
{
    public class SeedsController : MonoBehaviour
    {
        private List<SeedSlots> _slots = new List<SeedSlots>();
        public IReadOnlyCollection<SeedSlot> SingleSlots => _slots.SelectMany(s => s.Values).ToList();
        public IReadOnlyCollection<SeedSlots> Slots => _slots.AsReadOnly();
        private System.Random _random;
        public event Action<SeedSlots> OnSeedSlotsAdded;

        private void Awake()
        {
            _random = new System.Random();
        }

        public void Add(SeedSlots slots)
        {
            _slots.Add(slots);
            OnSeedSlotsAdded?.Invoke(slots);
        }

        public SeedSlot GetRandomActiveSeedSlot()
        {
            List<SeedSlot> activeUnoccupiedSlots = SingleSlots.Where(v => !v.Occupied && v.Active).ToList();
            if (activeUnoccupiedSlots.Count == 0)
                return null;
            return activeUnoccupiedSlots[_random.Next(activeUnoccupiedSlots.Count)];
        }

        public SeedSlot GetRandomInactiveSeedSlot(SeedSlots seedSlots)
        {
            List<SeedSlot> inactiveUnoccupiedSlots = seedSlots.Values.Where(v => !v.Occupied && !v.Active).ToList();
            if (inactiveUnoccupiedSlots.Count == 0)
                return null;
            int index = _random.Next(inactiveUnoccupiedSlots.Count);
            return inactiveUnoccupiedSlots[index];
        }
    }
}
