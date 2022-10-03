using System;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class AgentSpawnController : MonoBehaviour
    {
        [SerializeField]
        private AgentSpawner _spawnerPrefab;

        [SerializeField]
        private int _progressionStep = 3;

        [SerializeField]
        private int _spawnIntervall = 2;

        [SerializeField]
        private AgentCollection _collection;

        [SerializeField]
        private AgentSpawnSettings _settings;

        private RepeatingTimer _timer;
        private int _currentLevel = 0;
        private int _timerCount = 0;
        private const float SCREEN_OFFSET = 0.0f;

        private void Start()
        {
            _timer = FindObjectOfType<RepeatingTimer>();
            _timer.OnFinished += Step;
        }

        private void Step()
        {
            _timerCount++;
            if (_timerCount % _progressionStep == 0 && _currentLevel < _settings.LevelCount - 1)
                _currentLevel++;
            if (_timerCount % _spawnIntervall == 0)
            {
                Spawn();
            }
        }

        private void OnDestroy()
        {
            _timer.OnFinished -= Step;
        }

        /// <summary>
        /// Places a Spawnpoint in a random direction outside of the Screen
        /// </summary>
        private void Spawn()
        {
            Vector3 direction = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), 0);
            Vector3 screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
            const float ratio = 16f / 9f;
            if (Mathf.Abs(direction.x) > Math.Abs(direction.y) * ratio)
            {
                direction *= (screen.x / direction.x);
            }
            else
            {
                direction *= (screen.y / direction.y); 
            }
            Vector3 offset = direction.normalized * SCREEN_OFFSET;
            direction += offset;
            Vector2 position = direction;
            SpawnLevel lvl = _settings.GetLevel(_currentLevel);
            AgentSpawner spawner = GameObject.Instantiate(_spawnerPrefab);
            spawner.Init(position, lvl, _collection);
        }
    }
}