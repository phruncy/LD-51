using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LD51
{
    public class NodeTree : MonoBehaviour
    {
        [SerializeField]
        private Heart _heart;

        private Dictionary<Node, Branch> _nodeToBranch = new Dictionary<Node, Branch>();

		private void Start()
		{
            Add(new Branch(_heart.Node));
        }

		public void Add(Branch branch)
        {
            _nodeToBranch.Add(branch.Node, branch);
        }

        public void Add(NodeConnection connection)
        {
            Branch branch = new Branch
                (
                    _nodeToBranch[connection.StartNode],
                    connection
                );
            _nodeToBranch.Add(connection.EndNode, branch);
            _nodeToBranch[connection.StartNode].AddChild(branch);
        }

        public List<Branch> GetBranchesFromHeartTo(Node node)
		{
            List<Branch> result = new List<Branch>();
            Branch currentBranch = _nodeToBranch[node];
            result.Add(currentBranch);
            while (currentBranch.Node != _heart.Node)
			{
                currentBranch = currentBranch.Parent;
                result.Add(currentBranch);
            }
            result.Reverse();
            return result;
		}

		public void ReplaceNode(Node former, Node newNode)
		{
            Branch branch = _nodeToBranch[former];
            _nodeToBranch.Remove(former);
            branch.NodeConnection.Init(branch.NodeConnection.StartNode, newNode);
            branch.SetNode(newNode);
            _nodeToBranch.Add(newNode, branch);
        }

        public void DestroyBranch(Node owner)
        {
            if (!_nodeToBranch.ContainsKey(owner))
                return;
            DestroyBranch(_nodeToBranch[owner]);
        }

        private void DestroyBranch(Branch branch)
		{
            foreach (Branch child in branch.Children.ToList())
                DestroyBranch(child);
            branch.Destruct();
            _nodeToBranch.Remove(branch.Node);
            if(branch.NodeConnection != null)
			{
                _nodeToBranch[branch.NodeConnection.StartNode].RemoveChild(branch);
            }
        }
    }
}
