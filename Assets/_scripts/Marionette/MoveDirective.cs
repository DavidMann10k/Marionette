﻿using System;
using UnityEngine;

namespace Marionette
{
	public class MoveDirective : IDirective
	{
		public int Priority { get; private set; }

		public IBehavior Behavior { get; private set; }

		private Vector3 destination;

		public MoveDirective (Vector3 position, IBehavior caller)
		{
			Behavior = caller;
			this.destination = position;
			Priority = 1;
		}

		public void Execute (Marionette caller)
		{
//			Debug.Log ("Executing move directive");
			caller.locomotion.MoveTo (destination);
		}

		public bool IsComplete (Marionette caller)
		{
			return (Vector3.Distance (caller.transform.position, destination) < 1);
		}
	}
}

