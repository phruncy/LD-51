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

        private float _depthLevel1 = 0;
        private const float DEPTH01_CONTRIBUTION_PER_NODE = 0.05f;

        void Start()
        {
            _emitter.Play();
        }

        void Update()
        {
            CheckFadeInDepth();
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
