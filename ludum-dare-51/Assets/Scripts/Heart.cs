using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Heart : MonoBehaviour
    {
        [SerializeField]
        private Pulsate _pulsate;

        public Pulsate Pulsate => _pulsate;
    }
}
