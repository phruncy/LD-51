using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class ContinousCameraZoom : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;
        [SerializeField]
        private float _zoomPerSecond = 0.05f;

		private void Update()
		{
            _camera.orthographicSize += _zoomPerSecond * Time.deltaTime;
        }
	}
}
