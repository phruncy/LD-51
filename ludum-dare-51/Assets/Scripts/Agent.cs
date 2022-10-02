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
        private Rigidbody2D body;
        [SerializeField]
        private Node _target;
        public Node target
        {
            get => _target;
        }
        private Vector2 acceleration;
        private float SqrMaxSpeed => maxSpeed * maxSpeed;
        private AgentState _state = AgentState.TargetSeeking;
        private uint _innerTimer = 0;

        public float delta => maxSpeed * 0.01f;

        private void FixedUpdate()
        {
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
            Face(body.velocity);
        }

        /// <summary>
        /// Seeks the closest node within the scene
        /// </summary>
        public void SeekTarget()
        {
            Node[] nodes = FindObjectsOfType<Node>();
            float closest = float.PositiveInfinity;
            foreach(Node node in nodes)
            {
                float distanceSqr = (transform.position - node.transform.position).sqrMagnitude;
                if (distanceSqr < closest)
                {
                    _target = node;
                    closest = distanceSqr;
                }  
            }
        }

        private void Face(Vector2 target)
        {
            Quaternion targetRotation = Quaternion.LookRotation(target);
            targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.fixedDeltaTime);
            body.MoveRotation(targetRotation);
        }

        private Vector2 GetSteer(Vector2 targetDir)
        {
            targetDir *= maxSpeed;
            Vector2 steer = targetDir - body.velocity;
            if (steer.sqrMagnitude > maxSteeringForce * maxSteeringForce)
            {
                steer = steer.normalized * maxSteeringForce;
            }
            return steer;
        }

        private void Move()
        {
            body.AddForce(acceleration);
            acceleration *= 0;
            if (body.velocity.sqrMagnitude > SqrMaxSpeed)
            {
                Vector2 velocity = body.velocity.normalized;
                body.velocity = velocity * maxSpeed;
            }
        }
    }
}

