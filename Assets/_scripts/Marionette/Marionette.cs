﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Marionette
{
	[RequireComponent (typeof(Locomotion))]
	public class Marionette : MonoBehaviour
	{
		public Locomotion locomotion { get; private set; }

		List<IDirective> directives = new List<IDirective> ();

		IDirective current_directive;

		public void AddDirective (IDirective directive)
		{
			//Debug.Log ("Adding new directive");
			directives.Add (directive);
		}

		private void Start ()
		{
			locomotion = gameObject.GetComponent<Locomotion> ();
		}

		void Update ()
		{
			if (current_directive == null && directives.Count > 0) {
				current_directive = directives.OrderBy (i => i.Priority).First ();
				current_directive.Execute (this);
			} else if (current_directive.IsComplete (this)) {
				directives.Remove (current_directive);
				current_directive.Behavior.CreateDirective ();
				current_directive = null;
			}
		}
	}
}
