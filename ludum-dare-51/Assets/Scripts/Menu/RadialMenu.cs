using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public abstract class RadialMenu : Menu
    {
        private List<RadialMenuOption> _currentOptions;

        public override void Show(Vector3 position)
		{
            _currentOptions = GetOptions();
            transform.position = position;
            gameObject.SetActive(true);
            foreach (RadialMenuOption option in _currentOptions)
                option.Show();
        }

        protected override void DoHide()
        {
            gameObject.SetActive(false);
            foreach (RadialMenuOption option in _currentOptions)
                option.Hide();
        }

        protected abstract List<RadialMenuOption> GetOptions();
    }
}
