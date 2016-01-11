using UnityEngine;

namespace Marionette
{
	public class Living : MonoBehaviour
	{
		public int Life { 
			get { return life; }
		}

		[SerializeField]
		int life = 5;

		public ParticleSystem particle;

		public void OnDamage (int damage)
		{
			life -= damage;
			if (life <= 0)
				OnDeath ();
		}

		public void OnDeath ()
		{
			Destroy (this.gameObject);
		}
	}
}
