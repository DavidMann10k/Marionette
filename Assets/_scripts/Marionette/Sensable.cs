using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using RTree;
using System.Diagnostics;

namespace Marionette
{
	public class Sensable : MonoBehaviour
	{
		static List<Sensable> sensables = new List<Sensable> ();
		static RTree<Sensable> sensable_tree;


		void Awake ()
		{
			sensables.Add (this);
		}

		void LateUpdate ()
		{
			sensable_tree = null;
		}

		public static List<Sensable> Search (Bounds bounds)
		{
			if (sensable_tree == null) {
				BuildTree ();
			}

			var min = new float[]{ bounds.min.x, bounds.min.y, bounds.min.z };
			var max = new float[]{ bounds.max.x, bounds.max.y, bounds.max.z };
			return sensable_tree.Contains (new Rectangle (min, max));
		}

		private static void BuildTree ()
		{
			Stopwatch watch = new Stopwatch ();
			watch.Start ();

			sensable_tree = new RTree<Sensable> (sensables.Count, sensables.Count);

			foreach (Sensable sensable in sensables) {
				var pos = sensable.transform.position;
				var rect = new Rectangle (new float[]{ pos.x, pos.y, pos.z }, new float[]{ pos.x, pos.y, pos.z });
				sensable_tree.Add (rect, sensable);
			}

			watch.Stop ();
			if (watch.Elapsed.TotalMilliseconds > 0)
				UnityEngine.Debug.Log ("BUILD TREE: " + watch.Elapsed.TotalMilliseconds.ToString ());
		}


		//		public static List<Sensable> SensableObjects ()
		//		{
		//			return sensables;
		//		}
		//
		//		public static List<Sensable> SensableObjects (Bounds bounds)
		//		{
		//			var list = sensables.Where (i => bounds.Contains (i.transform.position));
		//
		//			return sensables;
		//		}
		//
		//		public static List<Sensable> SensableObjects (Vector3 position, float distance)
		//		{
		//			var list = sensables.Where (i => Vector3.Distance (i.transform.position, position) < distance);
		//
		//			return sensables;
		//		}
	}
}