using System;
using UnityEngine;

// Utility class for use with components with Click methods
public class ClickSender : MonoBehaviour
{
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
			hit.collider.gameObject.SendMessage ("Click", SendMessageOptions.DontRequireReceiver);
			ClickParticle (hit.point);
		}
//		else {
//			print ("no touch!");
//		}
	}

	void ClickParticle (Vector3 position)
	{
		particle.Clear ();
		particle.transform.position = position;
		particle.Play ();
	}
}
