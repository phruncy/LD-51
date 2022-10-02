using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class PulseSoundtrackController : MonoBehaviour
    {
        [SerializeField]
        private FMODUnity.StudioEventEmitter _emitter;

        [SerializeField]
        private Grow _heartGrow;

        private RepeatingTimer _timer;

        private void Start()
        {
            _timer = FindObjectOfType<RepeatingTimer>();
            _timer.OnPreTrigger += PlaySound;
        }

        private void Update()
        {
            float value = _heartGrow.Transform.localScale.x / _heartGrow.MaxSize;
            _emitter.SetParameter("tensec-depth", value);
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
