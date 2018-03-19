using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Marionette {
	public class SensesSortedList : MonoBehaviour {

		public float SenseRange = 10f;

		static List<IndexItem> senses_list = new List<IndexItem> ();
		List<SensesSortedList> nearby_senses_cache = new List<SensesSortedList>();

	//	Vector3 indexed_position;

		IndexItem index_item;

		void Start() {
			index_item = new IndexItem (transform.position, this);
			senses_list.Add (index_item);
		}

		void Update() {
			
			CacheNearbySenses ();
			IndexPosition ();
		}

		void IndexPosition() {
			index_item.Position = transform.position;

	//		if ((transform.position - indexed_position).sqrMagnitude > .1f)
	//		{
	//			indexed_position = transform.position;
	//
	//		}
		}

		[Obsolete]
		void CacheNearbySensesLinq()
		{
			nearby_senses_cache.Clear ();

			nearby_senses_cache = senses_list.Where( i => 
				i.Position.x < transform.position.x + SenseRange &&
				i.Position.x > transform.position.x - SenseRange &&
				i.Position.z < transform.position.z + SenseRange &&
				i.Position.z > transform.position.z - SenseRange).Select(j => j.Object).ToList();
			//		foreach (IndexItem i in senses_list) {
			//			if ((i.Object.transform.position - transform.position).sqrMagnitude < Range * Range)
			//				nearby_senses_cache.Add (i.Object);
			//		}
		}

		bool IsInRange(Vector3 point)
		{
			return (point - transform.position).sqrMagnitude < SenseRange * SenseRange;
		}

		void CacheNearbySenses()
		{
			nearby_senses_cache.Clear ();
			
			foreach (IndexItem i in senses_list) {
				if (true) {
					if (IsInRange (i.Object.transform.position)) {
						nearby_senses_cache.Add (i.Object);
					}
				}
			}
		}

		void OnDrawGizmos() {
			foreach (SensesSortedList s in nearby_senses_cache) {
				Gizmos.DrawLine (transform.position, s.transform.position);
			}
		}

		void OnDestroy()
		{
			senses_list.Remove (index_item);
		}

		struct IndexItem {
			public SensesSortedList Object  { get; private set; }
			public Vector3 Position { get; set; }

			public IndexItem (Vector3 position, SensesSortedList game_object)
				: this()
			{
				Object = game_object;
				Position = position;
			}
		}
	}
}