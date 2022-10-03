using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class ShowGameOverScreenOnNodeDeath : MonoBehaviour
    {
		private GameOverScreen _gameOverScreen;

		private void Start()
		{
			_gameOverScreen = FindObjectOfType<GameOverScreen>(true);
		}

		private void OnDestroy()
		{
			if (_gameOverScreen != null)
				_gameOverScreen.Show();
		}
	}
}
