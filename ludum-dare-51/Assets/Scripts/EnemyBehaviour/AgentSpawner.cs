using System;
using System.Linq;
using UnityEngine;

namespace LD51
{
    public class AgentSpawner : MonoBehaviour
    {
        public event Action OnCycleStarted;

        [SerializeField]
        private uint _pendingCycles = 0;
        private uint _lifeCyclePhase = 0;
        private AgentCollection _targetCollection;
        private SpawnLevel _spawnLevel;
        private RepeatingTimer _timer;

		public AgentSpawnerState State { get; private set; } = AgentSpawnerState.Pending;
        public event Action OnStateChanged;

		public void Init(Vector2 position, SpawnLevel spawnLevel, AgentCollection target)
        {
            transform.position = position;
            _spawnLevel = spawnLevel;
            _targetCollection = target;
        }

        void Start()
        {
            _timer = FindObjectOfType<RepeatingTimer>();
            _timer.OnFinished += UpdateLifeCycle;
            OnCycleStarted?.Invoke();
        }

        private void UpdateLifeCycle()
        {
            if(State == AgentSpawnerState.Pending)
            {
                if (_lifeCyclePhase >= _pendingCycles)
                {
                    Spawn();
                    SetState(AgentSpawnerState.Spawned);
                }
                _lifeCyclePhase++;
            } else if (State == AgentSpawnerState.Spawned)
            {
                Destroy(transform.gameObject);
            }
            
        }

        private void OnDestroy()
        {
            _timer.OnFinished -= UpdateLifeCycle;
        }

        private void Spawn()
        {
            foreach(int value in Enumerable.Range(0, _spawnLevel.AgentCount))
            {
                Vector3 offset = new Vector3(UnityEngine.Random.Range(-_spawnLevel.SpawnRadius, _spawnLevel.SpawnRadius), UnityEngine.Random.Range(-_spawnLevel.SpawnRadius, _spawnLevel.SpawnRadius), 1);
                Vector3 position = transform.position + offset;
                _targetCollection.Add(position);
            }
        }

        private void SetState(AgentSpawnerState value)
		{
            State = value;
            OnStateChanged?.Invoke();
        }

    }
}

