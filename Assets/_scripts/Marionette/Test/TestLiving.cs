using System;
using UnityEngine;

namespace Marionette.Test
{
	public class TestLiving : MonoBehaviour
	{
		[SerializeField]
		ParticleSystem particle = null;

		Click click;

		void Start() {
			click = FindObjectOfType<Click> ();
			click.ClickEvent += OnClick;
		}

		void OnClick(object sender, Click.ClickArgs args)
		{
			if (args.MouseIndex == 2) {
				if (Selectable.SelectedObjects.Count > 0) {
					foreach (Selectable s in Selectable.SelectedObjects) {
						s.gameObject.SendMessage("OnDamage", 1, SendMessageOptions.DontRequireReceiver);
						runParticle (s.gameObject);
					}
				}
			}
		}

		void runParticle (GameObject go)
		{
			particle.transform.position = go.transform.position;
			particle.Play ();
		}
	}
}