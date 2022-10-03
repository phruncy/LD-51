using System;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
	public class EnergyPath : MonoBehaviour
	{
		private List<Node> _waypoints;
		private EnergyController.EnergyTarget _target;
		private Energy _energy;
		private float _speed;

		private Node _currentWaypoint;
		private Queue<Node> _waypoitsLeft = new Queue<Node>();
		private Vector3 CurrentDistanceVector => _currentWaypoint.transform.position - _energy.transform.position;

		public void Init(List<Node> waypoints,
			EnergyController.EnergyTarget target,
			Energy energy,
			float speed)
		{
			_waypoints = waypoints;
			_target = target;
			_energy = energy;
			_speed = speed;
		}

		private void Start()
		{
			_energy.transform.position = _waypoints[0].transform.position;
			_waypoitsLeft = new Queue<Node>(_waypoints);
			SetNextTarget();
		}

		private void Update()
		{
			if (_currentWaypoint == null)
				Destruct();
			else
			{
				MoveEnergy();
				CheckWaypointReached();
			}
		}

		private void SetNextTarget()
		{
			_currentWaypoint = _waypoitsLeft.Dequeue();
		}

		private void CheckWaypointReached()
		{
			float distance = CurrentDistanceVector.magnitude;
			if(distance == 0)
			{
				if(IsTragetReached())
				{
					HandleTargetReached();
				}
				else
				{
					SetNextTarget();
				}
			}
		}

		private void HandleTargetReached()
		{
			_target.Consumer?.Provide(_target.EnergyAmount);
			Destruct();
		}


		private void Destruct()
		{
			Destroy(_energy.gameObject);
			Destroy(gameObject);
		}

		private bool IsTragetReached()
		{
			return _currentWaypoint == _target.Consumer.Node;
		}

		private void MoveEnergy()
		{
			Vector3 distanceVector = CurrentDistanceVector;
			float distance = distanceVector.magnitude;
			float delta = _speed * Time.deltaTime;

			if(delta >= distance)
			{
				_energy.transform.position = _currentWaypoint.transform.position;
			}
			else
			{
				_energy.transform.position += distanceVector.normalized * delta;
			}
		}
	}
}