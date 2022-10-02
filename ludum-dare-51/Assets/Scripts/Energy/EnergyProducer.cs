using System;
using UnityEngine;

namespace LD51
{
	public class EnergyProducer : MonoBehaviour
	{
		[SerializeField]
		private Node _node;
		public Node Node => _node;

		public int EnergyProduction { get; set; } = 0;
	}
}