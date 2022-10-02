using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    [Serializable]
    public class SpawnLevel
    {
        [SerializeField]
        private int _agentCount = 0;
        public int AgentCount => _agentCount;

        [SerializeField]
        private float _spawnRadius = 0;
        public float SpawnRadius => _spawnRadius;
    }
}
