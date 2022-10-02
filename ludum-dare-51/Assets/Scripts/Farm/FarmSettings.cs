using UnityEngine;

namespace LD51
{
	[CreateAssetMenu(fileName = "FarmSettings", menuName = "ScriptableObjects/Game/FarmSettings")]
	public class FarmSettings : ScriptableObject
	{
		[SerializeField]
		private int _baseEnergyGerneration = 1;
		public int BaseEnergyGerneration => _baseEnergyGerneration;
	}
}