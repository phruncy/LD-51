using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class SeedToTargetMover : MonoBehaviour
    {
        [SerializeField]
        private MoveToTarget _moveToTarget;
        [SerializeField]
        private EnergyConsumer _energyConsumer;
		private Vector3 _start;
		private Vector3 _target;
        private Vector3 DistanceVector => _target - _start;


		private void OnDestroy()
        {
            RemoveListerners();
        }

		public void Init(Vector3 start, Vector3 target)
		{
            _start = start;
            _target = target;
            _energyConsumer.OnPogress += UpdateMoveToTarget;
            UpdateMoveToTarget();
        }

		private void UpdateMoveToTarget()
		{
            Vector3 target = DistanceVector * _energyConsumer.Progress;
            _moveToTarget.Target = target;
        }

        private void CheckOnTargetReached()
        {
            if(_moveToTarget.Target == _target)
            {
                RemoveListerners();
            }
        }

        private void RemoveListerners()
        {
            _energyConsumer.OnPogress -= UpdateMoveToTarget;
            _moveToTarget.OnTargetReached -= CheckOnTargetReached;
        }
    }
}
