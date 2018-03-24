using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Marionette
{
	[RequireComponent(typeof(Conformation))]
	public class Locomotion : MonoBehaviour, ILocomotion {
		float distanceToFloor { get { return floor_height - conformation.FeetPosition.y; } }

		[SerializeField]
		LayerMask mask = -1;

		Conformation conformation;
		RaycastHit hit;
		Ray ray = new Ray();
		float floor_height;

		public void Move(Vector3 velocity) {
			CacheFloorHeight ();

			// convert velocity to a per-frame step
			velocity *= Time.deltaTime;

			// lock mover to the floor
			velocity.y = distanceToFloor;

			transform.Translate (velocity);
		}

		void Start() {
			conformation = GetComponent<Conformation> ();
		}

		void CacheFloorHeight() {
			floor_height = GetFloorHeight();
		}

		float GetFloorHeight() {
			ray.origin = transform.position;
			ray.direction = Vector3.down;
			Physics.Raycast (ray, out hit, 100, mask);
			return hit.point.y;
		}
	}
}