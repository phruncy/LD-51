using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace LD51
{
    public class EscapeHandler : MonoBehaviour
    {
		public List<Action> _actions = new List<Action>();

		private void Update()
		{
			if(Input.GetKeyDown(KeyCode.Escape))
			{
				HandleEsc();
			}
		}

		public bool Contains(Action action)
		{
			return _actions.Contains(action);
		}

		public void Add(Action action)
		{
			_actions.Add(action);
		}

		public void Remove(Action action)
		{
			_actions.Remove(action);
		}

		private void HandleEsc()
		{
			Action action = GetNextAction();

			if (action != null)
				action.Invoke();
			else
				Application.Quit();
		}

		private Action GetNextAction()
		{
			if (_actions.Count == 0)
				return null;
			Action result = _actions[_actions.Count - 1];
			_actions.Remove(result);
			return result;
		}
	}
}
