using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class AgentSpawnerIndicator : MonoBehaviour
    {
		private const string ANIMATOR_SHOW_ID = "Shown";

		[SerializeField]
		private Animator _animator;
		[SerializeField]
		private float _destructionDelay = 0.5f;
		[SerializeField]
		private float _offset = -10f;
		private AgentSpawner _agentSpawner;

		public void Init(AgentSpawner agentSpawner)
		{
			RemoveListeners();
			_agentSpawner = agentSpawner;
			_agentSpawner.OnStateChanged += CheckDelete;
		}

		private void Update()
		{
			float halfScreenHeight = Screen.height / 2;
			float halfScreenWidth = Screen.width / 2;
			Vector3 screenCenter = new Vector3(halfScreenWidth, halfScreenHeight, 0);
			Vector3 distanceVector = Camera.main.WorldToScreenPoint(_agentSpawner.transform.position) - screenCenter;
			float length = Mathf.Min(halfScreenHeight, halfScreenWidth);
			transform.position = screenCenter + distanceVector.normalized * (length + _offset);
		}

		private void RemoveListeners()
		{
			if (_agentSpawner != null)
				_agentSpawner.OnStateChanged -= CheckDelete;
		}

		private void CheckDelete()
		{
			if(_agentSpawner.State == AgentSpawnerState.Spawned)
				StartCoroutine(Destruct());
		}

		private IEnumerator Destruct()
		{
			RemoveListeners();
			_animator.SetBool(ANIMATOR_SHOW_ID, false);
			yield return new WaitForSeconds(_destructionDelay);
			Destroy(gameObject);
		}
	}
}
