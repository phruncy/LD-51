using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
	public class GameOverScreen : Menu
	{
		private void Start()
		{
			DoHide();
		}

		public override void Show(Vector3 position)
		{
			gameObject.SetActive(true);
		}

		public override void Show()
		{
			gameObject.SetActive(true);
		}

		protected override void DoHide()
		{
			gameObject.SetActive(false);
		}
	}
}
