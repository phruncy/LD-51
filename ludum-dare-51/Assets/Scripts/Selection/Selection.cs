using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Selection : MonoBehaviour
    {
		public Selectable Selected { get; private set; }

		internal void Select(Selectable selectable)
		{
			Deselect();
			Selected = selectable;
			if (Selected != null)
				Selected.Select();
		}

		internal void Deselect()
		{
			if (Selected != null)
				Selected.Deselect();
			Selected = null;
		}
	}
}
