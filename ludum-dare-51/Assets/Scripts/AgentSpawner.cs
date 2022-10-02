using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LD51
{
    public class AgentSpawner : MonoBehaviour
    {
        [SerializeField]
        private int spawnNumber;
        [SerializeField]
        private float spawnRadius;
        [SerializeField]
        private AgentCollection targetCollection;

        private RepeatingTimer _timer;

        // Start is called before the first frame update
        void Start()
        {
            _timer = FindObjectOfType<RepeatingTimer>();
            _timer.OnFinished += Spawn;
            Spawn();
        }

        private void OnDestroy()
        {
            _timer.OnFinished -= Spawn;
        }

        void Spawn()
        {
            foreach(int value in Enumerable.Range(0, spawnNumber))
            {
                Vector3 offset = new Vector3(Random.Range(-spawnRadius, spawnRadius), Random.Range(-spawnRadius, spawnRadius), 1);
                Vector3 position = transform.position + offset;
                targetCollection.Add(position);
            }
        }
    }
}

