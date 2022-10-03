
using System.Collections.Generic;

namespace LD51
{
    public class Branch
    {
        public Branch Parent { get; private set; }
        public Node Node { get; private set; }
        public NodeConnection NodeConnection { get; }

        private List<Branch> _children = new List<Branch>();
        public IReadOnlyCollection<Branch> Children => _children;

        public Branch(
            Branch parent,
            NodeConnection connection)
		{
            Parent = parent;
            NodeConnection = connection;
            Node = connection.EndNode;
        }
        

        public Branch(
            Node node)
		{
            Parent = null;
            NodeConnection = null;
            Node = node;
        }

        public void AddChild(Branch branch)
		{
            _children.Add(branch);
        }

        public void RemoveChild(Branch branch)
		{
            _children.Remove(branch);
        }

        public void SetNode(Node newNode)
		{
            Node = newNode;
        }

        public void SetParent(Branch parent)
		{
            Parent = parent;
        }

        public void Destruct()
        {
            Node.Destruct();
            NodeConnection?.Destruct();
        }
    }
}
