using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class AgentCollectionRemover : MonoBehaviour
    {
        [SerializeField]
        private Agent _agent;

        private void OnDestroy()
        {
            FindObjectOfType<AgentCollection>()?.Remove(_agent);
        }
    }
}
