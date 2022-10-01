using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LD51
{
    public class Agent : MonoBehaviour
    {
        [SerializeField]
        private float speed;
        [SerializeField]
        private Vector3 movement;
        [SerializeField]
        private float steeringForce;
        [SerializeField]
        private Node _target;
        public Node target
        {
            get => _target;
        }

        public float delta => speed * 0.1f;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            MoveToTarget();
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

        private void MoveToTarget()
        {
            if (_target)
            {
                Vector3 steeringDir = _target.transform.position - transform.position;
                if (steeringDir.sqrMagnitude > delta)
                {
                    steeringDir.Normalize();
                    movement += steeringDir * steeringForce;
                    movement.Normalize();
                    Move();
                }

            }
        }

        private void Move()
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, movement);
            transform.position += movement * Time.deltaTime;
        }
    }
}

