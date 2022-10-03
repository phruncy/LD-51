using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class SlotFromSeedCreator : MonoBehaviour
    {
        [SerializeField]
        private NodeSlot _slotPrefab;
        [SerializeField]
        private Seed _seed;
		[SerializeField]
		private float _delay = 1;
		private Tree _tree;

		private void Start()
		{
			_tree = FindObjectOfType<Tree>();
			if (_seed.EnergyConsumer.Progress == 1)
				OnComplete();
			else
				_seed.EnergyConsumer.OnComplete += OnComplete;
        }

		private void OnDestroy()
		{
			_seed.EnergyConsumer.OnComplete -= OnComplete;
		}

		private void OnComplete()
		{
			StartCoroutine(CreateSlot());
		}

		private IEnumerator CreateSlot()
		{
			yield return new WaitForSeconds(_delay);
			NodeSlot slot = Instantiate(_slotPrefab, _seed.Hook.transform, false);
			slot.transform.position = _seed.transform.position;
			_tree.ReplaceNode(_seed.Node, slot.Node);
			Destroy(_seed.gameObject);
		}
	}
}
