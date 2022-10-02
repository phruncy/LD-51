using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LD51
{
    public class AgentSpawner : MonoBehaviour
    {
        private AgentCollection _targetCollection;
        private SpawnLevel _spawnLevel;

        public void Init(Vector2 position, SpawnLevel spawnLevel, AgentCollection target)
        {
            transform.position = position;
            _spawnLevel = spawnLevel;
            _targetCollection = target;
        }

        // Start is called before the first frame update
        void Start()
        {
            Spawn();
            //Destroy(transform.gameObject);
        }

        void Spawn()
        {
            foreach(int value in Enumerable.Range(0, _spawnLevel.AgentCount))
            {
                Vector3 offset = new Vector3(Random.Range(-_spawnLevel.SpawnRadius, _spawnLevel.SpawnRadius), Random.Range(-_spawnLevel.SpawnRadius, _spawnLevel.SpawnRadius), 1);
                Vector3 position = transform.position + offset;
                _targetCollection.Add(position);
            }
        }
    }
}

