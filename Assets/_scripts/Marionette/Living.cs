using UnityEngine;
using System.Collections;
using System;

namespace Marionette
{
	public class Living : MonoBehaviour, IDies
	{
		public Observable<int> Life {
			get { return life; }
		}

		public int InitialLife = 1;

		Observable<int> life;

		public GameObject OnDeathparticle;

		public event EventHandler<DeathArgs> DeathEvent;

		public void OnDamage (int damage)
		{
			life.Value -= damage;
			if (life.Value <= 0) {
				foreach (IDies component in gameObject.GetComponents<IDies> ()) {
					component.OnDeath ();
				}
			}
		}

		public void OnDeath ()
		{
			Instantiate (OnDeathparticle, transform.position, Quaternion.identity);
			gameObject.AddComponent<Dead> ();
			RaiseDeathEvent ();
			Destroy (this);
		}

		void RaiseDeathEvent ()
		{
			EventHandler<DeathArgs> handler = DeathEvent;
			if (handler != null) {
				handler (this, new DeathArgs ());
			}
		}

		void Awake ()
		{
			life = new Observable<int> (InitialLife);
		}

		public class DeathArgs : EventArgs {}
	}
}
