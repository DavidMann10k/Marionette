using System;
using UnityEngine;
using Marionette.Utilities;

namespace Marionette
{
	// Manages ClickEvent
	//   broadcasts the clicked GameObject and a mouse button index
	public class Click : MonoBehaviour
	{
		public event EventHandler<ClickArgs> ClickEvent;

		[SerializeField]
		ParticleSystem particle = null;

		Ray ray;
		RaycastHit hit;

		void Update ()
		{
			for (int i = 0; i < 3; i++) {
				if (Input.GetMouseButtonUp (i)) {
					sendClick (i);

					if (i == (int)MouseButton.Left) {
						ClickParticle (hit.point);
					}
				}
			}
		}

		// Raises a click even with a GameObject and mouse button index
		void sendClick (int mouse_index)
		{
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {
				RaiseClickEvent (hit.collider.gameObject, mouse_index);
			} else {
				RaiseClickEvent (null, mouse_index);
			}
		}

		// plays the particle effect at the position supplied
		void ClickParticle (Vector3 position)
		{
			if (particle != null) {
				particle.transform.position = position;
				particle.Clear ();
				particle.Play ();

				var em = particle.emission;
				em.enabled = true;
			}
		}

		void RaiseClickEvent (GameObject game_object, int mouse_index)
		{
			if (ClickEvent != null) {
				ClickEvent (this, new ClickArgs (game_object, mouse_index));
			}
		}

		public class ClickArgs : EventArgs
		{
			public GameObject GameObject { get; set; }
			public int MouseIndex { get; set; }

			public ClickArgs (GameObject game_object, int mouse_index)
			{
				GameObject = game_object;
				MouseIndex = mouse_index;
			}
		}
	}
}