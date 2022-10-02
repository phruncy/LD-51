using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Tree : MonoBehaviour
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

        public List<Branch> GetBranchesFromHeartTo(Node node)
		{
            List<Branch> result = new List<Branch>();
            Branch currentBranch = _nodeToBranch[node];
            result.Add(currentBranch);
            while (currentBranch.Node != _heart.Node)
			{
                currentBranch = _nodeToBranch[currentBranch.PreviousNode];
                result.Add(currentBranch);
            }
            result.Reverse();
            return result;
		}
    }
}
