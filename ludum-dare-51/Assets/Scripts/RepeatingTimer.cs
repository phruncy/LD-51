using System;
using UnityEngine;

namespace LD51
{
    public class RepeatingTimer : MonoBehaviour
    {
        [SerializeField]
        private float _secondsTillTrigger = 10f;

		public event Action OnFinished;
		public float CurrentTime { get; private set; } = 0;
		public float SecondsTillFrigger => _secondsTillTrigger;
		public float Percentage => CurrentTime / SecondsTillFrigger;

		private void Update()
		{
			CurrentTime += Time.deltaTime;
			CheckFinished();
		}

		private void CheckFinished()
		{
			while(CurrentTime >= _secondsTillTrigger)
			{
				CurrentTime -= _secondsTillTrigger;
				OnFinished?.Invoke();
			}
		}
	}
}
