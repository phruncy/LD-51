using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LD51
{
    public class RestartButton : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

		private void Start()
		{
			_button.onClick.AddListener(Restart);
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(Restart);
		}

		private void Restart()
		{
			SceneManager.LoadScene("Game", LoadSceneMode.Single);
		}
	}
}
