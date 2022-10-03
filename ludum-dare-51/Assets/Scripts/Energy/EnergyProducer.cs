using System;
using UnityEngine;

namespace LD51
{
	public class EnergyProducer : MonoBehaviour
	{
		[SerializeField]
		private Node _node;
		public Node Node { get; private set; }

		public int EnergyProduction { get; set; } = 0;

		private void Awake()
		{
			Node = _node;
		}

		public void SetNode(Node node)
		{
			Node = node;
		}
	}
}