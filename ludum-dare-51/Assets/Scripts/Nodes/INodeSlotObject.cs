using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public interface INodeSlotObject
    {
        public Transform Base { get; }
        public Color Color { get; }
        public event Action OnDestruct;
    }
}
