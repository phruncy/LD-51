using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Destructor : MonoBehaviour
    {
        [SerializeField]
        private Node _node;

        private void Start()
        {
            _node.OnLifeZero += Destruct;
        }

        private void Destruct()
        {
            Tree tree = FindObjectOfType<Tree>();
            if (tree)
                tree.DestroyBranch(_node);
            else
                Destroy(transform.gameObject);
        }

        private void OnDestroy()
        {
            _node.OnLifeZero -= Destruct;
        }
    }
}
