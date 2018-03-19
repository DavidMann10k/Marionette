using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Marionette {
	public class SenseGrid : MonoBehaviour {
		
		[SerializeField]
		int depth = 10;

		[SerializeField]
		int width = 10;

		[SerializeField]
		float cell_width = 1.0f;

		[SerializeField]
		float cell_depth = 1.0f;

		Vector2 size { get { return new Vector2(width, depth); } }
		Vector2 cell_size { get { return new Vector2(cell_width, cell_depth); } }

		Indexing.WorldSpaceGrid<Sensable> grid;

		void OnValidate() {
			grid = new Indexing.WorldSpaceGrid<Sensable> (width, depth, cell_size, transform.position);
		}

		void OnDrawGizmos(){
			for (int x = 0; x < width; x++) {
				for (int y = 0; y < depth; y++) {
					Gizmos.color = Color.green;
					GizmosDrawSquare (grid.CellMin (x, y), grid.CellMax (x, y), transform.position.y);

				}
			}
			Gizmos.color = Color.red;
			GizmosDrawBounds ();
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