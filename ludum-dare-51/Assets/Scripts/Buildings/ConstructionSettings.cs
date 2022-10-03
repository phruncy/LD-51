using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    [Serializable]
    public class ConstructionSettings
    {
        [SerializeField]
        private int _costs;
        public int Costs => _costs;
        [SerializeField]
        private int _priority;
        public int Priority => _priority;
    }
}
