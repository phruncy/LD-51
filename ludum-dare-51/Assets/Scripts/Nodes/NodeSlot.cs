using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class NodeSlot : MonoBehaviour
    {
        [SerializeField]
        private Node _node;
        [SerializeField]
        private Transform _contentHook;
        public Node Node => _node;
        public Transform Content { get; private set; }
        public bool IsEmpty => Content != null;

        public void SetContent(Transform content)
		{
            Content = content;
            content.SetParent(_contentHook, false);
        }
    }
}
