using System;
using UnityEngine;

namespace LD51
{
    public class SeedSlot : MonoBehaviour
    {
        [SerializeField]
        private Node _node;
        public Node Node => _node;
        public bool Occupied { get; private set; } = false;
        public bool Active { get; private set; } = false;
        public event Action<SeedSlot> OnSlotActivated;

        private Seed _seed;

		public void AddSeed(Seed seed)
		{
            RemoveSeedListeners();
            _seed = seed;
            _seed.OnDestruction += Free;
            Occupied = true;
        }

        public void Activate()
		{
            Active = true;
            OnSlotActivated?.Invoke(this);
        }

        private void RemoveSeedListeners()
		{
            if (_seed == null)
                return;
            _seed.OnDestruction -= Free;
        }

        private void Free()
        {
            Occupied = false;
        }

        private void OnDestroy()
        {
            RemoveSeedListeners();
        }
    }
}
