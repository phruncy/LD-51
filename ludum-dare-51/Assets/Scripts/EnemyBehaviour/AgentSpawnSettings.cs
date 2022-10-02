using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    [CreateAssetMenu(fileName = "AgentSpawnSettings", menuName = "ScriptableObjects/Game/AgentSpawnSettings")]
    public class AgentSpawnSettings : ScriptableObject
    {
        [SerializeField]
        private List<SpawnLevel> _spawnLevels = new List<SpawnLevel>();
        public SpawnLevel GetLevel(int index) => _spawnLevels[index];
        public int LevelCount => _spawnLevels.Count;
    }
}
