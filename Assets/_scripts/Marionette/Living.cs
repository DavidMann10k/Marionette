using UnityEngine;
using System.Collections;

namespace Marionette
{
	public class Living : MonoBehaviour
	{
		public Observable<int> Life { 
			get { return life; }
		}

		Observable<int> life = new Observable<int> (5);

		public ParticleSystem OnDeathparticle;

		public void OnDamage (int damage)
		{
			life.Value -= damage;
			if ((int)life <= 0)
				gameObject.SendMessage ("OnDeath");
		}

		void OnDeath ()
		{
			StartCoroutine (Die ());
		}

		IEnumerator Die ()
		{
			OnDeathparticle.Play ();

			var em = OnDeathparticle.emission;
			em.enabled = true;

			yield return new WaitForSeconds (OnDeathparticle.duration);
			Destroy (this.gameObject);
		}
	}
}
