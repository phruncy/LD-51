using System;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class AgentCollection: MonoBehaviour
    {
        private List<Agent> _agents;
        [SerializeField]
        private Agent prefab;

        public int Count => _agents.Count;

        public void Start()
        {
            _agents = new List<Agent>();
        }

        internal Agent Add(Vector3 position)
        {
            Agent agent = GameObject.Instantiate(prefab, position, Quaternion.identity);
            agent.transform.SetParent(transform);
            _agents.Add(agent);
            return agent;
        }

        public void Remove(Agent agent)
        {
            _agents.Remove(agent);
        }
        
    }
}