using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    [CreateAssetMenu(fileName = "SeedSettings", menuName = "ScriptableObjects/Game/SeedSettings")]
    public class SeedSettings : ScriptableObject
    {
        [SerializeField]
        private int _growCosts = 5;
        public int GrowCosts => _growCosts;

        [SerializeField]
        private int _priority = 1;
        public int Priority => _priority;

        [SerializeField]
        private float _distanceFromNode = 7f;
        public float DistanceFromNode => _distanceFromNode;

        [SerializeField]
        private float _angleVariance = 40;
        public float AngleVariance => _angleVariance;

        [SerializeField]
        private float _slotOnSize = 0.5f;
        public float SlotOnSize => _slotOnSize;

        [SerializeField]
        private float _minNodeSize = 0.75f;
        public float MinNodeSize => _minNodeSize;
    }
}
