using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class GameTimer : MonoBehaviour
    {
		public float GameTime { get; private set; }

		private void Update()
		{
			GameTime += Time.deltaTime;
		}
	}
}
