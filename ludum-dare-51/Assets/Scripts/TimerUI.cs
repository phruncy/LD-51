using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LD51
{
    public class TimerUI : MonoBehaviour
    {
		[SerializeField]
		private Text _text;
		private RepeatingTimer _repeatingTimer;

		private void Start()
		{
			_repeatingTimer = FindObjectOfType<RepeatingTimer>();
		}

		private void Update()
		{
			_text.text = _repeatingTimer.CurrentTime.ToString("N1");
		}
	}
}
