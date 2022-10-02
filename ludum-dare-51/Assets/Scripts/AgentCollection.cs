using System;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class AgentCollection: MonoBehaviour
    {
        private List<Agent> agents;
        [SerializeField]
        private Agent prefab;

        internal void Add(Vector3 position)
        {
            Agent agent = GameObject.Instantiate(prefab, position, Quaternion.identity);
            agent.transform.SetParent(transform);
            agent.SeekTarget();
        }

        public void Remove(Agent agent)
        {

        }
        
    }
}