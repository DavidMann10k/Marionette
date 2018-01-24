using System;
using UnityEngine;

[RequireComponent(typeof(Select))]
public class TestLiving : MonoBehaviour
{
	public ParticleSystem particle;

	Select select;

	string message = "OnDamage";

	void Start()
	{
		select = GetComponent<Select> ();
	}

	void runParticle (GameObject go)
	{
		particle.Clear ();
		particle.transform.position = go.transform.position;
		particle.Play ();

		var em = particle.emission;
		em.enabled = true;
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonUp (1)) {
			if (Selected.SelectedObjects().Count > 0) {
				foreach (GameObject go in Selected.SelectedObjects()) {
					go.SendMessage (message, 1, SendMessageOptions.DontRequireReceiver);
					runParticle (go);
				}
			}
		}
	}
}
