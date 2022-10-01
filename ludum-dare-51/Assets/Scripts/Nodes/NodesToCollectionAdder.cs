using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class NodesToCollectionAdder : MonoBehaviour
    {
        [SerializeField]
        private Node _node;

		private void Start()
		{
			FindObjectOfType<NodesController>().Add(_node);
		}
	}
}
