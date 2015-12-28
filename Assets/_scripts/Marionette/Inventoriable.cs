using UnityEngine;
using System.Collections;

namespace Marionette
{
	// Adds ability for an object to be added to an inventory
	public class Inventoriable : MonoBehaviour
	{
		public string PrefabName { get; set; }

		void Awake ()
		{
			PrefabName = this.name;
		}
	}
}
