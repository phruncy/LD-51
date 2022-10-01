using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class EnergyConsumer : MonoBehaviour
    {
        [SerializeField]
        private Node _node;
        public Node Node => _node;

        public int RequiredEnergy { get; private set; } = 0;
        public int Priority { get; } = 0;
        public float Progress => RequiredEnergy != 0 ? (float)_providedEnergy / RequiredEnergy : 1;
        public event Action OnPogress;
        public event Action OnComplete;
        public event Action OnRequiredEnergyChanged;


        private int _providedEnergy = 0;

        public void Provide(int energy)
		{
            _providedEnergy = Mathf.Clamp(_providedEnergy + energy, 0, RequiredEnergy);
            OnPogress?.Invoke();

            if (_providedEnergy == RequiredEnergy)
                OnComplete?.Invoke();
        }

        public void SetRequiredEnergy(int value)
		{
            RequiredEnergy = value;
            OnRequiredEnergyChanged?.Invoke();
        }
    }
}
