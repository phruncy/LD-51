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

        private Seed _seed;

		internal void AddSeed(Seed seed)
		{
            _seed = seed;
            Occupied = true;
        }
	}
}
