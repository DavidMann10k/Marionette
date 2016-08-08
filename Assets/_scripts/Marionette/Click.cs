using System;
using UnityEngine;
using Marionette;

namespace Marionette
{
	// Utility class for use with components with Click methods
	public class Click : MonoBehaviour
	{
		public static event EventHandler<SelectGameObjectArgs> SelectGameObject;

		public ParticleSystem particle;

		private void Update ()
		{
			if (Input.GetMouseButtonUp (0)) {
				sendClick ();
			}
		}

		private void sendClick ()
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				RaiseSelectGameObjectEvent (hit.collider.gameObject);
				ClickParticle (hit.point);
			}
			//		else {
			//			print ("no touch!");
			//		}
		}

		void ClickParticle (Vector3 position)
		{
			particle.transform.position = position;
			particle.Clear ();
			particle.Play ();

			var em = particle.emission;
			em.enabled = true;
		}

		void RaiseSelectGameObjectEvent (GameObject game_object)
		{
			EventHandler<SelectGameObjectArgs> handler = SelectGameObject;
			if (handler != null) {
				handler (this, new SelectGameObjectArgs (game_object));
			}
		}
	}

	public class SelectGameObjectArgs : EventArgs
	{
		public GameObject GameObject { get; set; }

		public SelectGameObjectArgs (GameObject game_object)
		{
			GameObject = game_object;
		}
	}
}
