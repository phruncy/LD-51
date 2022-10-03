using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LD51
{
    public class GameTimerText : MonoBehaviour
    {
		[SerializeField]
		private Text _text;
        private GameTimer _timer;

		private void OnEnable()
		{
			_timer = FindObjectOfType<GameTimer>();
			float time = _timer.GameTime;
			int minutes = (int) (time / 60f);
			int seconds = (int) (time - (minutes * 60f));
			_text.text = $"Time: {minutes}:{seconds}";
		}
	}
}
