using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Destructor : MonoBehaviour
    {
        [SerializeField]
        private Node _node;
        private NodeTree _tree;

        private void Start()
        {
            _node.OnLifeZero += Destruct;
            _tree = FindObjectOfType<NodeTree>();
        }

        private void Destruct()
        {
            _tree.DestroyBranch(_node);
        }

        private void OnDestroy()
        {
            _node.OnLifeZero -= Destruct;
        }
    }
}
