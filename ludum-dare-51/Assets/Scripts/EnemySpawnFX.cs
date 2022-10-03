using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class EnemySpawnFX : MonoBehaviour
    {
        [SerializeField]
        private AgentSpawnController _controller;

        [SerializeField]
        private FMODUnity.StudioEventEmitter _emitter;
        // Start is called before the first frame update
        void Start()
        {
            _controller.OnSpawn += PlaySound;
        }

        private void OnDestroy()
        {
            _controller.OnSpawn -= PlaySound;
        }

        private void PlaySound()
        {
            _emitter.Play();
        }
    }
}
