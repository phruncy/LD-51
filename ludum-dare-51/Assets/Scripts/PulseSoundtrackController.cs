using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class PulseSoundtrackController : MonoBehaviour
    {
        [SerializeField]
        private FMODUnity.StudioEventEmitter _emitter;
        private RepeatingTimer _timer;

        private void Start()
        {
            _timer = FindObjectOfType<RepeatingTimer>();
            _timer.OnPreTrigger += PlaySound;
        }

        private void OnDestroy()
        {
            _timer.OnPreTrigger -= PlaySound;
        }

        void PlaySound()
        {
            _emitter.Play();
        }
    }
}
