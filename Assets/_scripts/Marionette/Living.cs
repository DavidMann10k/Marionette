﻿using UnityEngine;
using System.Collections;

namespace Marionette
{
	public class Living : MonoBehaviour
	{
		public Observable<int> Life {
			get { return life; }
		}

		public int InitialLife = 1;

		Observable<int> life;

		public ParticleSystem OnDeathparticle;

		public void OnDamage (int damage)
		{
			life.Value -= damage;
			if (life.Value <= 0)
				gameObject.SendMessage ("OnDeath");
		}

		void Awake ()
		{
			life = new Observable<int> (InitialLife);
		}

		void OnDeath ()
		{
			StartCoroutine (Die ());
		}

		IEnumerator Die ()
		{
			OnDeathparticle.Play ();
			yield return new WaitForSeconds (OnDeathparticle.duration);
			gameObject.AddComponent<Dead> ();
			Destroy (this);
		}
	}
}
