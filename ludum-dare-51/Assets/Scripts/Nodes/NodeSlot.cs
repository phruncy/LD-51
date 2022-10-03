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
        public INodeSlotObject Content { get; private set; }
        public bool IsEmpty => Content != null;

        public void SetContent(INodeSlotObject content)
		{
            if (Content != null)
                Content.OnDestruct -= RemoveContent;
            Content = content;
            content.Base.SetParent(_contentHook, false);
            content.Base.position = _contentHook.position;
            Content.OnDestruct += RemoveContent;
        }

        public void RemoveContent()
        {
            Content.OnDestruct -= RemoveContent;
            Content = null;
        }
    }
}
