using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class ShowGameOverScreenOnDestroy : MonoBehaviour
    {
		private GameOverScreen _gameOverScreen;

		private void Start()
		{
			_gameOverScreen = FindObjectOfType<GameOverScreen>();
		}

		private void OnDestroy()
		{
			if (_gameOverScreen != null)
				_gameOverScreen.Show();
		}
	}
}
