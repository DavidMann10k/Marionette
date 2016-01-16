using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Marionette
{
	// The central consciousness of a Marionette AI controlled agent
	[RequireComponent (typeof(Locomotion))]
	public class Marionette : MonoBehaviour
	{
		public ILocomotion locomotion { get; private set; }

		List<IDirective> directives = new List<IDirective> ();

		IDirective current_directive;

		public void AddDirective (IDirective directive)
		{
			//Debug.Log ("Adding new directive");
			directives.Add (directive);
		}

		private void Start ()
		{
			locomotion = gameObject.GetComponent<ILocomotion> ();
		}

		void Update ()
		{
			if (directives.Count > 0) {
				if (current_directive == null) {
					current_directive = directives.OrderBy (i => i.Priority).First ();
					current_directive.Execute (this);
				} else if (current_directive.IsComplete (this)) {
					current_directive.Behavior.ConcludeDirective (current_directive);
					directives.Remove (current_directive);
					current_directive = null;
				}
			}
		}

		void OnDeath ()
		{
			enabled = false;
		}
	}
}
