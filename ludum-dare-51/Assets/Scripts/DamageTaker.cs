using UnityEngine;

namespace LD51
{
    public class DamageTaker : MonoBehaviour
    {
        [SerializeField]
        private Node _node;

        public void ApplyDamage(float _damage)
        {
            _node.Shrink(_damage);
        }
    }
}
