using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LD51
{
    public class AgentSpawnController : MonoBehaviour
    {
        [SerializeField]
        private AgentSpawner _spawnerPrefab;

        [SerializeField]
        private AgentSpawnerIndicator _indicatorPrefab;

        [SerializeField]
        private int _progressionStep = 1;

        [SerializeField]
        private int _spawnIntervall = 2;

        [SerializeField]
        private AgentCollection _collection;

        [SerializeField]
        private AgentSpawnSettings _settings;

        public event Action OnSpawn;

        private RepeatingTimer _timer;
        private Canvas _canvas;
        private int _currentLevel = 0;
        private int _timerCount = 0;
        private const float SCREEN_OFFSET = 10.0f;

        private void Start()
        {
            _timer = FindObjectOfType<RepeatingTimer>();
            _canvas = FindObjectOfType<Canvas>();
            _timer.OnFinished += Step;
        }

        private void Step()
        {
            _timerCount++;
            if (_timerCount % _progressionStep == 0 && _currentLevel < _settings.LevelCount - 1)
                _currentLevel++;
            if (_timerCount % _spawnIntervall == 0)
            {
                SpawnLevel lvl = _settings.GetLevel(_currentLevel);
                ExecuteLevel(lvl);
                OnSpawn?.Invoke();
            }
        }

        private void ExecuteLevel(SpawnLevel lvl)
        {
            int numSpawned = UnityEngine.Random.Range(lvl.MinSpawnnumber, lvl.MaxSpawnNumber + 1);
            foreach (int index in Enumerable.Range(0, numSpawned))
            {
                Spawn(lvl);
            }
        }

        private void OnDestroy()
        {
            _timer.OnFinished -= Step;
        }

        private void Spawn(SpawnLevel lvl)
        {
            Vector2 position = GetRandomPosition();
            AgentSpawner spawner = GameObject.Instantiate(_spawnerPrefab);
            spawner.Init(position, lvl, _collection);
            AgentSpawnerIndicator indicator = Instantiate(_indicatorPrefab, _canvas.transform);
            indicator.Init(spawner);
        }

        private Vector2 GetRandomPosition()
        {
            Vector3 direction = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), 0);
            Vector3 screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
            const float ratio = 16f / 9f;
            if (Mathf.Abs(direction.x) > Math.Abs(direction.y) * ratio)
            {
                direction *= (screen.x / Math.Abs(direction.x));
            }
            else
            {
                direction *= (screen.y / Math.Abs(direction.y)); 
            }
            direction += direction.normalized * SCREEN_OFFSET;
            return new Vector2(direction.x, direction.y);
        }
    }
}