using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LD51
{
    public class NodesController : MonoBehaviour
    {
        private List<Node> _values = new List<Node>();

		public void Add(Node node)
		{
			_values.Add(node);
		}

		public void Remove(Node node)
		{
			_values.Add(node);
		}
    }
}
