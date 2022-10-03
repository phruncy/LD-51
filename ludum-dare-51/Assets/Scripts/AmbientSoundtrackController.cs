using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class AmbientSoundtrackController : MonoBehaviour
    {
        [SerializeField]
        private FMODUnity.StudioEventEmitter _emitter;

        [SerializeField]
        private NodesController _nodes;

        [SerializeField]
        private EnergyController _energy;

        [SerializeField]
        private AgentCollection _agents;

        [SerializeField]
        private int _bassMinEnergyLvl = 10;

        [SerializeField]
        private int _bassFullEnergyLvl = 100;

        [SerializeField]
        private int _drumsMaxEnemyCount = 50;

        private float _depthLevel1 = 0;
        private float _bassLevel = 0;
        private float _drumsLevel = 0;
        private const float DEPTH01_CONTRIBUTION_PER_NODE = 0.05f;

        void Start()
        {
            _emitter.Play();
        }

        void Update()
        {
            CheckFadeInDepth();
            CheckBass();
            checkDrums();
        }

        private void checkDrums()
        {
            _drumsLevel = (float)_agents.Count / _drumsMaxEnemyCount;
            _emitter.SetParameter("depth-3", _drumsLevel);
        }

        private void CheckBass()
        {
            _bassLevel = Math.Max(_energy.GetEnergyPerTick() - _bassMinEnergyLvl, 0) / (float)(Mathf.Abs(_bassFullEnergyLvl - _bassMinEnergyLvl));
            _emitter.SetParameter("depth-2", _bassLevel);
        }

        private void CheckFadeInDepth()
        {
            if (_depthLevel1 < 1f)
            {
                _depthLevel1 = _nodes.Count * DEPTH01_CONTRIBUTION_PER_NODE;
                _emitter.SetParameter("depth-1", _depthLevel1);
            }
        }
    }
}
