using System;
using UnityEngine;
using System.Collections.Generic;

namespace Marionette
{
	// Adds collecting behavior to an AI agent
	[RequireComponent (typeof(Marionette))]
	[RequireComponent (typeof(PhysicsDrivenSenses))]
	public class Collects : MonoBehaviour, IBehavior
	{
		[SerializeField]
		List<string> item_names;

		Marionette marionette;
		PhysicsDrivenSenses senses;

		public void ConcludeDirective (IDirective directive)
		{
			throw new NotImplementedException ();
		}

		void Awake ()
		{
			marionette = GetComponent<Marionette> ();
			senses = GetComponent<PhysicsDrivenSenses> ();
		}

		void Start ()
		{
			// if there are nearby objects of interest
			//   if objects of interest are withing range
			//     create store directive
			//   else
			//     create move directive
			//   else
			//     do nothing
		}

		public void OnDeath ()
		{
			this.enabled = false;
		}
	}
}