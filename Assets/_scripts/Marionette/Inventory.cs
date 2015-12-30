using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Marionette
{
	// adds ability to store InventoryItems
	public class Inventory : MonoBehaviour
	{
		public int ItemCount { get { return items.Count (); } }

		public IEnumerable<InventoryItem> Items { get { return items; } }

		List<InventoryItem> items = new List<InventoryItem> ();

		public void Store (InventoryItem inventory_item)
		{
			if (inventory_item != null)
				items.Add (inventory_item);
		}

		public InventoryItem Unstore (InventoryItem item)
		{
			items.Remove (item);
			return item;
		}

		public InventoryItem UnStore (string name)
		{
			return Unstore (items.FirstOrDefault (i => i.ItemName == name));
		}

		public InventoryItem UnStore ()
		{
			return Unstore (items.FirstOrDefault ());
		}
	}
}