using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Marionette
{
	// adds ability to collect inventoriable objects
	public class Inventory : MonoBehaviour
	{
		List<Inventoriable> inventory = new List<Inventoriable> ();

		public void Store (Inventoriable item)
		{
			inventory.Add (item);
			item.gameObject.SetActive (false);
			Debug.Log ("Storign a " + item.gameObject.name);
			Debug.Log (inventory.Count () + " items in store");
		}

		public Inventoriable UnStore (string name)
		{
			var item = inventory.First (i => i.name == name);
			inventory.Remove (item);
			return item;
		}

		public Inventoriable UnStore ()
		{
			var item = inventory.FirstOrDefault ();
			if (item != null) {
				inventory.Remove (item);
				item.gameObject.SetActive (true);
				return item;
			}
			return null;
		}
	}
}