using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class BranchDestructionFXController : MonoBehaviour
    {
        [SerializeField]
        private NodeTree _tree;

        [SerializeField]
        private FMODUnity.StudioEventEmitter _emitter;
        // Start is called before the first frame update
        void Start()
        {
            _tree.OnBranchDestroy += PlaySound;
        }

        private void PlaySound()
        {
            _emitter.Play();
        }

        private void OnDestroy()
        {
            _tree.OnBranchDestroy -= PlaySound;
        }

    }
}
