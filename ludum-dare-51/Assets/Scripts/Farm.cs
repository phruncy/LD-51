using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Farm : MonoBehaviour
    {
        [SerializeField]
        private Node _node;
        public Node Node => _node;
    }
}
