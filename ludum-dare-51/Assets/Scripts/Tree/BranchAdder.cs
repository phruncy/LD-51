using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class BranchAdder : MonoBehaviour
    {
        [SerializeField]
        private NodeConnection _connection;

		private void Start()
		{
			FindObjectOfType<Tree>().Add(_connection);
		}
	}
}
