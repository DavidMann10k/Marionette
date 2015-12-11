using UnityEngine;
using System.Collections.Generic;

namespace Marionette
{
	[RequireComponent (typeof(Marionette))]
	public class Wanders : MonoBehaviour
	{
		[SerializeField]
		float distance = 1;
		
		Marionette marionette;

		void Start ()
		{
			marionette = GetComponent<Marionette> ();
			marionette.AddDirective (new MovementDirective (RandomNearbyPosition));
		}

		Vector3 RandomNearbyPosition {
			get {
				var pos = Random.insideUnitCircle * distance;
				// TODO: remove this magic number, replace with pathfinding determined destination
				return new Vector3 (pos.x, 1.5f, pos.y);
			}
		}
	}
}
