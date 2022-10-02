using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class EnemyHitAudioController : MonoBehaviour
    {
        [SerializeField]
        private FMODUnity.StudioEventEmitter _emitter;

        [SerializeField]
        private SingleHitDestructor _destructor;

        private void Start()
        {
            _destructor.OnHit += PlaySound;
        }

        private void OnDestroy()
        {
            _destructor.OnHit -= PlaySound;
        }

        private void PlaySound()
        {
            _emitter.Play();
        }
    }
}
