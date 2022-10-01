using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class PopupAudio : MonoBehaviour
    {
        /// <summary>
        /// This class triggers a adaptive sound when the game object is instantiated
        /// </summary>
        ///

        public float minPitch = 0;
        public float maxPix = 1.0f;

        private void Awake()
        {
            Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
            float pitch = position.y / Camera.main.pixelHeight;
            var emitter = GetComponent<FMODUnity.StudioEventEmitter>();
            emitter.Play();
            emitter.SetParameter("Test-Event_Pitch", pitch, true);
            
        }
    }
}
