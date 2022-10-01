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
        private float _distanceFromSlot = 4f;
        public float DistanceFromSlot => _distanceFromSlot;

        [SerializeField]
        private float _angleVariance = 40;
        public float AngleVariance => _angleVariance;
    }
}
