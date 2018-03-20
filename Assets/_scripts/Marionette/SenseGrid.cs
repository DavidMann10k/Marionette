using System.Collections;
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

//		[SerializeField]
		float cell_depth = 1.0f;

		Vector2 size { get { return new Vector2(width, depth); } }
		Vector2 cell_size { get { return new Vector2(cell_width, cell_depth); } }

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
			grid = new Indexing.WorldSpaceGrid<Sensable> (width, depth, cell_size, transform.position);
		}

		void OnDrawGizmos(){
			Gizmos.color = Color.green;
			GizmosDrawGrid ();
			Gizmos.color = Color.cyan;
			GizmosDrawBounds ();
		}

		void GizmosDrawGrid ()
		{
			for (int x = 0; x < width; x++) {
				for (int y = 0; y < depth; y++) {
					GizmosDrawSquare (grid.CellMin (x, y), grid.CellMax (x, y), transform.position.y);
					for ( int i = 0; i < grid.Cells [x, y].ItemCount; i++ ) {
						GizmosDrawSquare(grid.CellMin (x, y), grid.CellMax (x, y), transform.position.y + (0.1f * i));
					}
				}
			}
		}

		void GizmosDrawBounds(){
			GizmosDrawSquare (grid.Bounds.min, grid.Bounds.max, transform.position.y);
		}

		void GizmosDrawSquare(Vector2 min, Vector2 max, float y){
			Gizmos.DrawLine(new Vector3(min.x, y, min.y), new Vector3(max.x, y, min.y));
			Gizmos.DrawLine(new Vector3(max.x, y, min.y), new Vector3(max.x, y, max.y));
			Gizmos.DrawLine(new Vector3(max.x, y, max.y), new Vector3(min.x, y, max.y));
			Gizmos.DrawLine(new Vector3(min.x, y, max.y), new Vector3(min.x, y, min.y));
		}
	}
}