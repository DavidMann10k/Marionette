using System;
using UnityEngine;

namespace Marionette
{
	public class MovementDirective : IDirective
	{
		private Vector3 position;

		public int Priority { get; private set; }

		public MovementDirective (Vector3 position)
		{
			this.position = position;
			Priority = 1;
		}

		public void Execute (Marionette caller)
		{
			caller.locomotion.MoveTo (position);
		}
	}
}

