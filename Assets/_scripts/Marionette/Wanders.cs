using UnityEngine;
using System.Collections.Generic;

namespace Marionette
{
	// Adds wandering behavior to an AI agent
	[RequireComponent (typeof(Marionette))]
	public class Wanders : MonoBehaviour, IBehavior
	{

		[SerializeField]
		float distance = 5;
		Marionette marionette;

		public void ConcludeDirective (IDirective directive)
		{
			if (directive.GetType () == typeof(MoveDirective)) {
				CreatePauseDirective ();
			} else {
				CreateMoveDirective ();
			}
		}

		void CreateMoveDirective ()
		{
			marionette.AddDirective (new MoveDirective (RandomNearbyPosition, this));
		}

		void CreatePauseDirective ()
		{
			marionette.AddDirective (new PauseDirective (1, this));
		}

		void Start ()
		{
			marionette = GetComponent<Marionette> ();
			CreateMoveDirective ();
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
