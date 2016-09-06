using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;

namespace Marionette
{
	// keeps a list of "NearbyAgents"
	// an interesting experiment but clearly very inefficient,
	// Being tied to physics update, means there's no good way to optimize
	[RequireComponent (typeof(Marionette))]
	[RequireComponent (typeof(Rigidbody))]
	[Obsolete]
	public class PhysicsDrivenSenses : MonoBehaviour
	{
		public SphereCollider AwarenessCollider;

		public List<GameObject> NearbyAgents;

		public bool DebugSenses = true;

		void OnTriggerEnter (Collider collider)
		{
			if (!collider.isTrigger)
			if (collider.gameObject.tag == "Agent")
				NearbyAgents.Add (collider.gameObject);
		}

		void OnTriggerExit (Collider collider)
		{
			if (NearbyAgents.Contains (collider.gameObject))
				NearbyAgents.Remove (collider.gameObject);
		}

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

		void OnDrawGizmos ()
		{
			if (DebugSenses) {
				foreach (GameObject go in NearbyAgents) {
					Gizmos.DrawLine (transform.position, go.transform.position);
				}
			}
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
