using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class SetSizeToTowerRange : MonoBehaviour
    {
        [SerializeField]
        private Tower _tower;
        [SerializeField]
        private Transform _target;

		private void Start()
		{
			_tower.OnRangeChanged += UpdateView;
			UpdateView();
		}

		private void OnDestroy()
		{
			_tower.OnRangeChanged -= UpdateView;
		}

		private void UpdateView()
		{
			float range = _tower.Range;
			_target.localScale = new Vector3(range, range, range);
		}
	}
}
