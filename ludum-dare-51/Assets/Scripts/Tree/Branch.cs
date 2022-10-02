using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Branch
    {
        public Node PreviousNode { get; }
        public Node Node { get; }
        public NodeConnection NodeConnection { get; }

        private List<Branch> _branches = new List<Branch>();

        public Branch(
            NodeConnection connection)
		{
            PreviousNode = connection.StartNode;
            NodeConnection = connection;
            Node = connection.EndNode;
        }
        

        public Branch(
            Node node)
		{
            PreviousNode = null;
            NodeConnection = null;
            Node = node;
        }

        public void AddBranch(Branch branch)
		{
            _branches.Add(branch);
        }

        public void RemoveBranch(Branch branch)
		{
            _branches.Remove(branch);
        }
    }
}
