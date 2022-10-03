using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
	public class ConstructionSite : MonoBehaviour, INodeSlotObject
    {
        private const string SHOW_ANIMATOR_ID = "Shown";

        [SerializeField]
        private EnergyConsumer _consumer;
        [SerializeField]
        private float _destructionDelay;
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private SpriteRenderer _sprite;
        [SerializeField]
        private SpriteRenderer _indicator;
		private Node _node;
        private Action _onComplete;
		private ConstructionSettings _settings;

        public Transform Base => transform;

        public Color Color => _sprite.color;
        public event Action OnDestruct;


        private void Start()
        {
            _consumer.OnComplete += OnConstructionComplete;
        }

		public void Init(Node node, Action onComplete, ConstructionSettings settings, NodeColorSettings colorSettings)
        {
            _node = node;
            _onComplete = onComplete;
            _settings = settings;
            _sprite.color = colorSettings.SideColor;
            _indicator.color = colorSettings.MainColor;

            _consumer.SetRequiredEnergy(_settings.Costs);
            _consumer.SetPriority(_settings.Priority);
            _consumer.SetNode(_node);
        }

		private void OnDestroy()
        {
            _consumer.OnComplete -= OnConstructionComplete;
            OnDestruct?.Invoke();
        }

        private void OnConstructionComplete()
		{
            _onComplete?.Invoke();
            StartCoroutine(Destruct());
        }

		private IEnumerator Destruct()
		{
            _animator.SetBool(SHOW_ANIMATOR_ID, false);
            yield return new WaitForSeconds(_destructionDelay);
            Destroy(gameObject);
		}
	}
}
