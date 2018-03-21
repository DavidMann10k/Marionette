﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Marionette {
	public class SenseGrid : MonoBehaviour {
		public static SenseGrid Instance { get;	private set; }

		[SerializeField]
		int depth = 10;

		[SerializeField]
		int width = 10;

		[SerializeField]
		float cell_width = 1.0f;

		[SerializeField]
		float cell_depth = 1.0f;

//		Vector3 size { get { return new Vector3(width, 0, depth); } }
//		Vector3 cell_size { get { return new Vector3(cell_width, 0, cell_depth); } }

		Indexing.WorldSpaceGrid<Sensable> grid;
		void Awake() {
			EnforceSingleton ();
		}

		void EnforceSingleton ()
		{
			if (Instance == null) {
				Instance = this;
			}
			else
				if (Instance != this) {
					Destroy (gameObject);
				}
		}

		public void InsertSensable(Sensable sensable) {
			grid.Insert (sensable);
		}

		void OnValidate() {
			grid = new Indexing.WorldSpaceGrid<Sensable> (width, depth, cell_width, cell_depth, transform.position);
		}

		void OnDrawGizmos(){
			GizmosDrawGrid ();
			Gizmos.color = Color.cyan;
			GizmosDrawBounds ();
		}

		void GizmosDrawGrid ()
		{
			for (int x = 0; x < width; x++) {
				for (int y = 0; y < depth; y++) {
					Gizmos.color = Color.green;
					GizmosDrawSquare (grid.CellMin (x, y), grid.CellMax (x, y), transform.position.y);
					for ( int i = 0; i < grid.Cells [x, y].ItemCount; i++ ) {
						Gizmos.color = Color.red;
						GizmosDrawSquare(grid.CellMin (x, y), grid.CellMax (x, y), transform.position.y + (i * 0.1f + 0.1f));
					}
				}
			}
		}

		void GizmosDrawBounds(){
			GizmosDrawSquare (grid.Min, grid.Max, transform.position.y);
		}

		void GizmosDrawSquare(Vector3 min, Vector3 max, float y){
			Gizmos.DrawLine(new Vector3(min.x, y, min.z), new Vector3(max.x, y, min.z));
			Gizmos.DrawLine(new Vector3(max.x, y, min.z), new Vector3(max.x, y, max.z));
			Gizmos.DrawLine(new Vector3(max.x, y, max.z), new Vector3(min.x, y, max.z));
			Gizmos.DrawLine(new Vector3(min.x, y, max.z), new Vector3(min.x, y, min.z));
		}
	}
}