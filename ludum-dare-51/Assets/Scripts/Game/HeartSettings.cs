using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    [CreateAssetMenu(fileName = "HeartSettings", menuName = "ScriptableObjects/Game/HeartSettings")]
    public class HeartSettings : ScriptableObject
    {
        [SerializeField]
        private int _baseEnergyPerTick = 3;
        public int BaseEnergyPerTick => _baseEnergyPerTick;
    }
}
