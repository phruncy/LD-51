using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LD51
{
    public class Agent : MonoBehaviour
    {
        [SerializeField]
        private float maxSpeed;
        [SerializeField]
        private float maxSteeringForce;
        [SerializeField]
        private Rigidbody2D _body;
        [SerializeField]
        private Node _target;
        public Node target
        {
            get => _target;
        }
        private Vector2 acceleration;
        private float SqrMaxSpeed => maxSpeed * maxSpeed;
        private AgentState _state = AgentState.TargetSeeking;

        private bool active = true;
        private NodesController _nodesCollection;

        public float delta => maxSpeed * 0.01f;

		private void Start()
		{
            _nodesCollection = FindObjectOfType<NodesController>();
        }

		private void FixedUpdate()
        {
            if(active)
                HandleState();
        }

        private void HandleState()
        {
            if (_state == AgentState.TargetLocked)
            {
                HandleTargetLocked();
            }
            else if (_state == AgentState.TargetSeeking)
            {
                HandleTargetSeeking();
            }
        }

        private void HandleTargetSeeking()
        {
            SeekTarget();
            if (_target)
                _state = AgentState.TargetLocked;
        }

        private void HandleTargetLocked()
        {
            if (_target)
                MoveToTarget();
            else
                _state = AgentState.TargetSeeking;
        }

        private void MoveToTarget()
        {
            Vector2 desired = _target.transform.position - transform.position;
            Vector2 steer = GetSteer(desired);
            acceleration += steer;
            Move();
            if (_body.velocity.sqrMagnitude > 0)
                Face(_body.velocity);
        }

        public void SeekTarget()
        {
            float closest = float.PositiveInfinity;
            foreach(Node node in _nodesCollection.Values)
            {
                float distanceSqr = (transform.position - node.transform.position).sqrMagnitude;
                if (distanceSqr < closest)
                {
                    _target = node;
                    closest = distanceSqr;
                }  
            }
            if (_target == null)
                active = false;
        }

        private void Face(Vector2 direction)
        {
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
            targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.fixedDeltaTime);
            _body.MoveRotation(targetRotation);
        }

        private Vector2 GetSteer(Vector2 targetDir)
        {
            targetDir *= maxSpeed;
            Vector2 steer = targetDir - _body.velocity;
            if (steer.sqrMagnitude > maxSteeringForce * maxSteeringForce)
            {
                steer = steer.normalized * maxSteeringForce;
            }
            return steer;
        }

        private void Move()
        {
            _body.AddForce(acceleration, ForceMode2D.Force);
            acceleration *= 0;
            if (_body.velocity.sqrMagnitude > SqrMaxSpeed)
            {
                Vector2 velocity = _body.velocity.normalized;
                _body.velocity = velocity * maxSpeed;
            }
        }
    }
}

