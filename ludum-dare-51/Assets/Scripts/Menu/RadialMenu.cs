using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public abstract class RadialMenu : Menu
    {
        private List<NodeSlotMenuOption> _currentOptions;

        public override void Show()
        {
            Show(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        }

        public override void Show(Vector3 position)
		{
            _currentOptions = GetOptions();
            transform.position = position;
            gameObject.SetActive(true);
            foreach (NodeSlotMenuOption option in _currentOptions)
                option.Show();
        }

        protected override void DoHide()
        {
            gameObject.SetActive(false);
            foreach (NodeSlotMenuOption option in _currentOptions)
                option.Hide();
        }

        protected abstract List<NodeSlotMenuOption> GetOptions();
    }
}
