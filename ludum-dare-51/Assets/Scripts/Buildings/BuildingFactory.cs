using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class BuildingFactory : MonoBehaviour
    {
        public void Create(BuildingType type, int level, NodeSlot slot)
		{
            Debug.Log($"Create building od Type {type} and level {level}");
		}
    }
}
