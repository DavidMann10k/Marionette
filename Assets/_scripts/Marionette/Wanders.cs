using UnityEngine;
using System.Collections.Generic;

namespace Marionette
{
	[RequireComponent (typeof(Marionette))]
	public class Wanders : MonoBehaviour, IBehavior
	{
		[SerializeField]
		float distance = 5;
		Marionette marionette;

		public void CreateDirective ()
		{
			marionette.AddDirective (new MoveDirective (RandomNearbyPosition, this));
		}

		void Start ()
		{
			marionette = GetComponent<Marionette> ();
			CreateDirective ();
		}

		Vector3 RandomNearbyPosition {
			get {
				var randomVector = Random.insideUnitCircle * distance;
				// TODO: replace with pathfinding determined destination
				return marionette.transform.position + new Vector3 (randomVector.x, 0, randomVector.y);
			}
		}
	}
}
