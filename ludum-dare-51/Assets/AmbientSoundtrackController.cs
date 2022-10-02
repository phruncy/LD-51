using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    }
    public class AmbientSoundtrackController : MonoBehaviour
    {
        [SerializeField]
        private FMODUnity.StudioEventEmitter emitter;

        // Start is called before the first frame update
        void Start()
        {
            emitter.Play();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
