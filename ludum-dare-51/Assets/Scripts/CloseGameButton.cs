using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LD51
{
    public class CloseGameButton : MonoBehaviour
    {
		[SerializeField]
		private Button _button;

		private void Start()
		{
			_button.onClick.AddListener(Application.Quit);
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(Application.Quit);
		}
	}
}
