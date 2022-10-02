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
        public float Progress => RequiredEnergy != 0 ? (float)ProvidedEnergy / RequiredEnergy : 1;
        public event Action OnPogress;
        public event Action OnComplete;
        public event Action OnRequiredEnergyChanged;

		public int ProvidedEnergy { get; private set; } = 0;
		public int MissingEnergy => RequiredEnergy - ProvidedEnergy;

        public void Provide(int energy)
		{
            ProvidedEnergy = Mathf.Clamp(ProvidedEnergy + energy, 0, RequiredEnergy);
            OnPogress?.Invoke();

            if (ProvidedEnergy == RequiredEnergy)
                OnComplete?.Invoke();
        }

        public void SetRequiredEnergy(int value)
		{
            RequiredEnergy = value;
            OnRequiredEnergyChanged?.Invoke();
        }
    }
}
