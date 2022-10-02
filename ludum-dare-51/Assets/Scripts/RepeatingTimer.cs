using System;
using UnityEngine;

namespace LD51
{
    public class RepeatingTimer : MonoBehaviour
    {
        [SerializeField]
        private float _secondsTillTrigger = 10f;
		[SerializeField]
		private float _secondsToPreTrigger = 6f;

		public event Action OnFinished;
		public event Action OnPreTrigger;
		public float CurrentTime { get; private set; } = 0;
		public float SecondsTillFrigger => _secondsTillTrigger;
		public float Percentage => CurrentTime / SecondsTillFrigger;
		private bool hasTriggeredSound = false;

		private void Update()
		{
			CurrentTime += Time.deltaTime;
			CheckPreTrigger();
			CheckFinished();
		}

        private void CheckPreTrigger()
        {
            if (CurrentTime >= _secondsToPreTrigger && !hasTriggeredSound)
            {
				OnPreTrigger?.Invoke();
				hasTriggeredSound = true;
            }
        }

        private void CheckFinished()
		{
			while(CurrentTime >= _secondsTillTrigger)
			{
				Reset();
				OnFinished?.Invoke();
			}
		}

        private void Reset()
        {
			CurrentTime -= _secondsTillTrigger;
			hasTriggeredSound = false;
		}
    }
}
