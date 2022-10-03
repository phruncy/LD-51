using UnityEngine;

namespace LD51
{
	[CreateAssetMenu(fileName = "FarmSettings", menuName = "ScriptableObjects/Game/FarmSettings")]
	public class FarmSettings : ScriptableObject
	{
		[SerializeField]
		private int _baseEnergyGerneration = 1;
		public int BaseEnergyGerneration => _baseEnergyGerneration;
		[SerializeField]
		private ConstructionSettings _constructionSettings;
		public ConstructionSettings ConstructionSettings => _constructionSettings;
		[SerializeField]
		private NodeColorSettings _colorSettings;
		public NodeColorSettings ColorSettings => _colorSettings;
	}
}