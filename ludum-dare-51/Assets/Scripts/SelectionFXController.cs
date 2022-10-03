using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class SelectionFXController : MonoBehaviour
    {
        [SerializeField]
        private Selection _selection;

        [SerializeField]
        FMODUnity.StudioEventEmitter _emitter;
        // Start is called before the first frame update
        void Start()
        {
            _selection.OnSelect += PlaySound;
        }

        private void PlaySound()
        {
            _emitter.Play();
        }

        private void OnDestroy()
        {
            _selection.OnSelect -= PlaySound;
        }
    }
}

