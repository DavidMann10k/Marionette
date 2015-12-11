using UnityEngine;
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
			}
		}
	}
}
