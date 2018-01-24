using UnityEngine;
using System.Collections;

namespace Test
{
	public class TestParticle : MonoBehaviour {

		public ParticleSystem particle;

		// Update is called once per frame
		void Update () {
			if (Input.GetMouseButtonUp(0))
			{
				particle.Clear();
				particle.Play();

				var em = particle.emission;
				em.enabled = true;
			}
		}
	}
}