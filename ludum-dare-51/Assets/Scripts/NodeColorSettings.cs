using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    [Serializable]
    public class NodeColorSettings
	{
		[SerializeField]
		private Color _sideColor = Color.black;
		public Color SideColor => _sideColor;

		[SerializeField]
		private Color _mainColor = Color.black;
		public Color MainColor => _mainColor;
	}
}
