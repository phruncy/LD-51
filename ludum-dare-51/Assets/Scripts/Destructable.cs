using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Destructable : MonoBehaviour
    {
        [SerializeField]
        private GameObject _target;

        public virtual void Destruct()
		{
            Destroy(_target);
		}
    }
}
