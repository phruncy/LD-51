using UnityEngine;

namespace LD51
{
    public class Energy : MonoBehaviour
    {
        [SerializeField]
        private float _additionalSizePerEnergy = 0.2f;
        [SerializeField]
        private Transform _transform;
        private float _amount;

        public void Init(int amount)
		{
            _amount = amount;
            InitView();
        }

		private void InitView()
		{
            _transform.localScale += _transform.localScale * _additionalSizePerEnergy * _amount;
        }
	}
}
