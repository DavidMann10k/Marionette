using System;
using UnityEngine;

namespace Marionette
{
	public class TestLiving : MonoBehaviour
	{

		public ParticleSystem particle;
		GameObject selected;

		string message = "OnDamage";

		// Use this for initialization
		void Start ()
		{
			Click.SelectgGameObject += new EventHandler<SelectGameObjectArgs> (OnSelectGameObject);
		}

		void OnSelectGameObject (object sender, SelectGameObjectArgs e)
		{
			selected = e.GameObject;
		}

		void runParticle ()
		{
			particle.Clear ();
			particle.transform.position = selected.transform.position;
			particle.Play ();
		}
	
		// Update is called once per frame
		void Update ()
		{
			if (Input.GetMouseButtonUp (1)) {
				selected.SendMessage (message, 1);
				runParticle ();
			}
		}
	}
}
