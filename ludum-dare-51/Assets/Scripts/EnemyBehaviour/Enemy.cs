using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private Agent _agent;
        [SerializeField]
        private Destructable _destructable;
        public Destructable Destructable => _destructable;
    }
}
