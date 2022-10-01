using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class SeedPlacer : MonoBehaviour
    {
        [SerializeField]
        private float _startDelay = 2;
        [SerializeField]
        private Seed _seedPrefab;
        [SerializeField]
        private NodeConnection _connectionPrefab;
        [SerializeField]
        private Transform _connectionsHook;
        [SerializeField]
        private Transform _nodesHook;
        [SerializeField]
        private SeedSettings _settings;

        private SeedsController _slots;
        private RepeatingTimer _timer;
        private System.Random _random;

        private IEnumerator Start()
        {
            _slots = FindObjectOfType<SeedsController>();
            _timer = FindObjectOfType<RepeatingTimer>();
            _random = new System.Random();
            yield return new WaitForSeconds(_startDelay);
            PlaceSeed();
        }

		private void PlaceSeed()
		{
            SeedSlot slot = _slots.GetRandomSeedSlot();
            if (slot == null)
                return;
            Seed seed = Instantiate(_seedPrefab, _nodesHook, true);
            seed.transform.position = slot.transform.position; 
            float angle = (float)_random.NextDouble() * _settings.AngleVariance - _settings.AngleVariance / 2;
            Vector3 up = slot.transform.up;
            seed.MoveToTarget.Target = slot.transform.position + up * _settings.DistanceFromSlot;
            NodeConnection connection = Instantiate(_connectionPrefab, _connectionsHook, false);
            Debug.Log(seed.MoveToTarget.Target - seed.transform.position);
            connection.Init(slot.Node, seed.Node);
            slot.AddSeed(seed);
        }
	}
}
