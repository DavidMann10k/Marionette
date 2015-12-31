using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Marionette
{
	// a collection of tools used to mimic senses such as sight or smell
	[RequireComponent (typeof(Marionette))]
	public class Senses : MonoBehaviour
	{
		public IEnumerable<InventoryItem> ProximateItems ()
		{
			var colliders = Physics.OverlapSphere (transform.position, 5);
			var inventories = colliders.Select (i => i.gameObject.GetComponent<Inventory> ()).Where (j => j != null);
			var items = inventories.SelectMany (i => i.Items);
			return items;
		}
	}
}
