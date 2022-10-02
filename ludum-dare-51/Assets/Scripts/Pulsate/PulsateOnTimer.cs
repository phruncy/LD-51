
using UnityEngine;

namespace LD51
{
    public class PulsateOnTimer : MonoBehaviour
    {
		[SerializeField]
		private Pulsate _pulsate;

		private RepeatingTimer timer;
		private float delay = 0;

		private void Start()
		{
			this.timer = FindObjectOfType<RepeatingTimer>();
			timer.OnFinished += StartPulse;
		}

		private void OnDestroy()
		{
			timer.OnFinished -= StartPulse;
		}

		public void SetDelay(float value)
		{
			delay = value;
		}

		private void StartPulse()
		{
			_pulsate.StartPulse(delay);
		}
	}
}
