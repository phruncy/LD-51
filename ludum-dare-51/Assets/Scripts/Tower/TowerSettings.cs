using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    [CreateAssetMenu(fileName = "TowerSettings", menuName = "ScriptableObjects/Game/TowerSettings")]
    public class TowerSettings : ScriptableObject
    {
        [SerializeField]
        private List<TowerLevelSettings> _levels = new List<TowerLevelSettings>();
        public IReadOnlyList<TowerLevelSettings> Levels => _levels.AsReadOnly();

        [SerializeField]
        private int _energyPerAmonition = 1;
        public int EngeryPerAmonition => _energyPerAmonition;

        [SerializeField]
        private int _consumptionPrio = 2;
        public int ConsumptionPrio => _consumptionPrio;

        [SerializeField]
        private int _buildConsumptionPrio = 5;
        public int BuildConsumptionPrio => _buildConsumptionPrio;
    }
}
