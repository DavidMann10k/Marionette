using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;

namespace Marionette
{
	// a collection of tools used to mimic senses such as sight or smell
	[RequireComponent (typeof(Marionette))]
	public class Senses : MonoBehaviour
	{
		private IEnumerable<PositionItemPair> FindProximateItems ()
		{
			var colliders = Physics.OverlapSphere (transform.position, 5);
			var inventories = colliders.Select (i => i.gameObject.GetComponent<Inventory> ()).Where (j => j != null);
			var pairs = inventories.SelectMany (v => v.Items, (v, i) => new PositionItemPair (v.transform.position, i));
			return pairs;
		}

		private PositionItemPair MostProximateItem (Vector3 origin)
		{
			// TODO: pretty dirty, replace when it becomes a problem
			var items_with_distance = FindProximateItems ().Select (i => new { position = i.Position, item = i.Item, distance = Vector3.Distance (origin, i.Position) });
			var item = items_with_distance.OrderBy (i => i.distance).First ();
			return new PositionItemPair (item.position, item.item);
		}
	}

	class PositionItemPair
	{
		public Vector3 Position { get; private set; }

		public InventoryItem Item { get; private set; }

		public PositionItemPair (Vector3 position, InventoryItem item)
		{
			this.Position = position;
			this.Item = item;
		}
	}
}
