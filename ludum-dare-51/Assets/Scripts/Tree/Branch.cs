using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Branch
    {
        public Branch Parent { get; private set; }
        public Node Node { get; private set; }
        public NodeConnection NodeConnection { get; }

        private List<Branch> _branches = new List<Branch>();
        public IReadOnlyCollection<Branch> Branches => _branches;

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

        public void AddBranch(Branch branch)
		{
            _branches.Add(branch);
        }

        public void RemoveBranch(Branch branch)
		{
            _branches.Remove(branch);
        }

        public void SetNode(Node newNode)
		{
            Node = newNode;
        }

        public void SetParent(Branch parent)
		{
            Parent = parent;
        }
	}
}
