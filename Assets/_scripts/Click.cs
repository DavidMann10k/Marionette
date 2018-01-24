using System;
using UnityEngine;

// Utility class for use with components with Click methods
public class Click : MonoBehaviour
{
	public static event EventHandler<SelectGameObjectArgs> ClickEvent;

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
			RaiseClickEvent (hit.collider.gameObject);
			ClickParticle (hit.point);
		} else {
			RaiseClickEvent (null);
		}
	}

	void ClickParticle (Vector3 position)
	{
		particle.transform.position = position;
		particle.Clear ();
		particle.Play ();

		var em = particle.emission;
		em.enabled = true;
	}

	void RaiseClickEvent (GameObject game_object)
	{
		EventHandler<SelectGameObjectArgs> handler = ClickEvent;
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
