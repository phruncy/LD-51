using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class SeedSlots : MonoBehaviour
    {
        [SerializeField]
        private SeedSlot[] _values = new SeedSlot[0];
        public SeedSlot[] Values => _values;
    }
}
