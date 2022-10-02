using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class SeedPlacer : MonoBehaviour
    {
        [SerializeField]
        private float _startDelay = 1;
        [SerializeField]
        private Seed _seedPrefab;
        [SerializeField]
        private SeedHook _seedHookPrefab;
        [SerializeField]
        private NodeConnection _connectionPrefab;
        [SerializeField]
        private Transform _connectionsHook;
        [SerializeField]
        private Transform _nodesHook;
        [SerializeField]
        private SeedSettings _settings;

        private SeedsController _seedsController;
        private System.Random _random;

        private IEnumerator Start()
        {
            _seedsController = FindObjectOfType<SeedsController>();
            _random = new System.Random();
            yield return new WaitForSeconds(_startDelay);
            Init();
        }

		private void OnDestroy()
		{
            _seedsController.OnSeedSlotsAdded -= Init;
			foreach (SeedSlot slot in _seedsController.SingleSlots)
			{
                slot.OnSlotActivated -= PlaceSeed;

            }
        }

		private void Init()
		{
			foreach(SeedSlots slots in _seedsController.Slots)
			{
                Init(slots);
            }
            _seedsController.OnSeedSlotsAdded += Init;
        }

		private void Init(SeedSlots slots)
		{
			foreach (SeedSlot slot in slots.Values)
			{
                Init(slot);
            }
		}

		private void Init(SeedSlot slot)
		{
            if (slot.Active)
                PlaceSeed(slot);
            else
                slot.OnSlotActivated += PlaceSeed;
        }

		private void PlaceSeed(SeedSlot slot)
		{
            if (slot == null)
                return;
            SeedHook hook = Instantiate(_seedHookPrefab, _nodesHook, true);
            hook.Attatch.Init(slot.transform);
            Seed seed = Instantiate(_seedPrefab, hook.transform, false);
            SetPosition(seed, slot);
            SetMoveToTarget(seed, slot);
            CreateConnection(seed, slot);
            slot.AddSeed(seed);
            slot.OnSlotActivated -= PlaceSeed;
            Debug.Log("Seed placed");
        }

		private void SetPosition(Seed seed, SeedSlot slot)
		{
            Vector3 pos = slot.transform.position;
            seed.transform.position = pos;
        }

        private void SetMoveToTarget(Seed seed, SeedSlot slot)
        {
            float angle = (float)_random.NextDouble() * _settings.AngleVariance - _settings.AngleVariance / 2;
            Vector3 pos = Quaternion.Euler(0, 0, angle) * (Vector2.up * _settings.DistanceFromNode);
            seed.MoveToTarget.Init(Vector3.zero, pos);
        }

        private void CreateConnection(Seed seed, SeedSlot slot)
        {
            NodeConnection connection = Instantiate(_connectionPrefab, _connectionsHook, false);
            connection.Init(slot.Node, seed.Node);
        }
    }
}
