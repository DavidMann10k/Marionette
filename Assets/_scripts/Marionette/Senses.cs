using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Marionette
{
	public class Senses : MonoBehaviour
	{
		public bool DebugSenses = true;
		private Vector3 sensing_bounds_size = new Vector3 (10f, 10f, 10f);

		void Update ()
		{
//			var nearby_sensables = Sensable.Search (new Bounds (this.transform.position, sensing_bounds_size));
		}

		void OnDrawGizmos ()
		{
			var watch = new Stopwatch ();
			watch.Start ();
			if (DebugSenses && Application.isPlaying) {
				var nearby_sensables = Sensable.Search (new Bounds (this.transform.position, sensing_bounds_size));

				foreach (Sensable sensable in nearby_sensables) {
					Gizmos.DrawLine (transform.position, sensable.transform.position);
				}
			}


			watch.Stop ();
			if (watch.Elapsed.Milliseconds > 0)
				UnityEngine.Debug.Log ("DRAW GIZMOS: " + watch.Elapsed.Milliseconds.ToString ());
		}
	}
}