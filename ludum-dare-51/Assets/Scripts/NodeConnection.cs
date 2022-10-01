using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LD51
{
    public class NodeConnection : MonoBehaviour
    {
		private float RADIUS_FACTOR = 0.65f;
		private float MAX_WIDTH_FACTOR = 1.5f;
		private float MIN_WIDTH_FACTOR = 0.7f;
		private int MIDDLE_KEY_INDEX = 1;

        [SerializeField]
        private LineRenderer _lineRenderer;
		[SerializeField]
		private int verticesAmount = 10;
        [SerializeField]
        private Node _startNode;
        [SerializeField]
        private Node _endNode;


		private void Start()
		{
			_lineRenderer.positionCount = verticesAmount;
			_lineRenderer.useWorldSpace = false;
		}

		private void Update()
		{
            UpdatePosition();
		}

		private void UpdatePosition()
		{
			Vector3 startNodePos = _startNode.transform.position;
			Vector3 endNodePose = _endNode.transform.position;
			Vector3 connectionVector = endNodePose - startNodePos;
			float startNodeRadius = _startNode.Radius * RADIUS_FACTOR;
			float endNodeRadius = _endNode.Radius * RADIUS_FACTOR;
			Vector3 startPos = startNodePos + connectionVector.normalized * startNodeRadius;
			float lineLength = connectionVector.magnitude - startNodeRadius - endNodeRadius;
			transform.position = startPos;
			UpdateVertices(lineLength, connectionVector.normalized);
			UpdateWidth();
		}

		private void UpdateVertices(float lineLength, Vector3 normalizedConnectionVector)
		{
			Vector3[] positions = new Vector3[verticesAmount];
			float delta = lineLength / (verticesAmount - 1);
			for (int i = 0; i < positions.Length; i++)
			{
				positions[i] = delta * i * normalizedConnectionVector;
			}

			_lineRenderer.SetPositions(positions);
		}

		private void UpdateWidth()
		{
			float startWidth = _startNode.Radius * MAX_WIDTH_FACTOR;
			float endWidth = _endNode.Radius * MAX_WIDTH_FACTOR;
			_lineRenderer.startWidth = startWidth;
			_lineRenderer.endWidth = endWidth;
			UpdateCenterKey(startWidth, endWidth);
			
		}

		private void UpdateCenterKey(float startWidth, float endWidth)
		{
			float combinedWidth = startWidth + endWidth;
			Keyframe[] keys = _lineRenderer.widthCurve.keys;
			keys[MIDDLE_KEY_INDEX].value = Mathf.Min(startWidth, endWidth) * MIN_WIDTH_FACTOR;
			keys[MIDDLE_KEY_INDEX].time = startWidth / combinedWidth;
			_lineRenderer.widthCurve = new AnimationCurve(keys);
		}
	}
}