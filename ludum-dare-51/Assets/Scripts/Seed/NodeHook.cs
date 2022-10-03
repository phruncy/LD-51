using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class NodeHook : MonoBehaviour
    {
        [SerializeField]
        private Attatch _attatch;
        public Attatch Attatch => _attatch;
    }
}
