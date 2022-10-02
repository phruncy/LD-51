using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    [CreateAssetMenu(fileName = "EnergySettings", menuName = "ScriptableObjects/Game/EnergySettings")]
    public class EnergySettings : ScriptableObject
    {
        [SerializeField]
        private float _energySpeed = 8;
        public float EnergySpeed => _energySpeed;
    }
}
