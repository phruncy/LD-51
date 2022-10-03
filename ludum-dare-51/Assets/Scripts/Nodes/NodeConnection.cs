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

		public Node StartNode { get; private set; }
		public Node EndNode { get; private set; }


		private void Start()
		{
			_lineRenderer.positionCount = verticesAmount;
			_lineRenderer.useWorldSpace = false;
		}

		private void Update()
		{
            UpdatePosition();
			UpdateColors();
		}

		public void Destruct()
		{
			Destroy(gameObject);
		}

		public void Init(Node startNode, Node endNode)
		{
			StartNode = startNode;
			EndNode = endNode;
		}

		private void UpdatePosition()
		{
			Vector3 startNodePos = StartNode.transform.position;
			Vector3 endNodePose = EndNode.transform.position;
			Vector3 connectionVector = endNodePose - startNodePos;
			float startNodeRadius = StartNode.Radius * RADIUS_FACTOR;
			float endNodeRadius = EndNode.Radius * RADIUS_FACTOR;
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
			float startWidth = StartNode.Radius * MAX_WIDTH_FACTOR;
			float endWidth = EndNode.Radius * MAX_WIDTH_FACTOR;
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

		private void UpdateColors()
		{
			Color startColor = StartNode.Color;
			Color endColor = EndNode.Color;
			Gradient gradient = new Gradient();
			gradient.SetKeys(
				new GradientColorKey[]
				{
					new GradientColorKey{color = startColor, time = 0.25f},
					new GradientColorKey{color = endColor, time = 0.75f},
				},
				new GradientAlphaKey[]
				{
					new GradientAlphaKey(1, 0.25f),
					new GradientAlphaKey(1, 0.75f)
				}
			);
			_lineRenderer.colorGradient = gradient;
		}
	}
}