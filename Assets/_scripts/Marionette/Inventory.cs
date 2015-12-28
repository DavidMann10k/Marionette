using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Marionette
{
	// adds ability to collect inventoriable objects
	public class Inventory : MonoBehaviour
	{
		List<InventoryItem> inventory = new List<InventoryItem> ();

		public void Store (Inventoriable inventoriable)
		{
			inventory.Add (new InventoryItem (inventoriable));
			Destroy (inventoriable.gameObject);
			// Debug.Log ("Storing a " + inventoriable.gameObject.name);
			// Debug.Log (inventory.Count () + " items in store");
		}

		public GameObject UnStore (string name)
		{
			var item = inventory.First (i => i.PrefabName == name);
			if (item != null) {
				inventory.Remove (item);
				// Debug.Log (item.PrefabName);
				var prefab = Resources.Load<GameObject> (string.Format ("prefabs/{0}", item.PrefabName));
				var go = Instantiate (prefab);
				go.name = item.PrefabName;
				return go;
			}
			return null;
		}

		public GameObject UnStore ()
		{
			var item = inventory.FirstOrDefault ();
			if (item != null) {
				return UnStore (item.PrefabName);
			}
			return null;
		}
	}
}