using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Marionette {
	public class SensesBounds : MonoBehaviour {

		public float Range;
		Bounds bounds;

		static List<SensesBounds> senses_list = new List<SensesBounds> ();
		List<SensesBounds> nearby_senses_cache = new List<SensesBounds>();

		void Start() {
			senses_list.Add (this);
			bounds.size = Vector3.one * Range;
		}

		void Update() {
			bounds.center = transform.position;

			CacheNearbySenses ();
		}

		void CacheNearbySenses()
		{
			nearby_senses_cache.Clear ();
			foreach (SensesBounds s in senses_list) {
				if (bounds.Intersects(s.bounds))
					nearby_senses_cache.Add (s);
			}
		}

		void OnDrawGizmos() {
			foreach (SensesBounds s in nearby_senses_cache) {
				Gizmos.DrawLine (transform.position, s.transform.position);
			}
		}

		void OnDestroy()
		{
			senses_list.Remove (this);
		}
	}
}