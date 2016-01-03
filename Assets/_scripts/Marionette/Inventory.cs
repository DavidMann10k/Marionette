using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Marionette
{
	// adds ability to store InventoryItems
	public class Inventory : MonoBehaviour
	{
		public static event EventHandler<SelectInventoryArgs> SelectInventory;

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

		void Click ()
		{
			RaiseSelectedInventoryEvent ();
		}

		void RaiseSelectedInventoryEvent ()
		{
			try {
				EventHandler<SelectInventoryArgs> handler = SelectInventory;
				if (handler != null) {
					handler (this, new SelectInventoryArgs (this));
				}
			} catch (Exception ex) {
				Debug.LogError (ex.Message);
			}
		}
	}

	public class SelectInventoryArgs : EventArgs
	{
		public Inventory Inventory { get; set; }

		public SelectInventoryArgs (Inventory inventory)
		{
			this.Inventory = inventory;
		}
	}
}