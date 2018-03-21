using UnityEngine;

namespace Marionette.Indexing {
	public struct WorldSpaceGrid<T> where T : IGridItem {
		
		public Cell<T>[,] Cells { get { return grid.Cells; } }
		public Vector3 Min { get { return position + new Vector3 (-grid.Width * 0.5f, 0, -grid.Depth * 0.5f); } }
		public Vector3 Max { get { return position + new Vector3 (+grid.Width * 0.5f, 0, +grid.Depth * 0.5f); } }

		Vector2 cell_size;
		Vector3 position;
		Grid<T> grid;

		public WorldSpaceGrid(int width, int depth, Vector2 cell_size, Vector3 position) {
			grid = new Grid<T> (width, depth);
			this.cell_size = cell_size;
			this.position = position;
		}

		public void Insert(T item) {
			var bounds = item.Bounds;
			float min_x = bounds.min.x - Min.x;
			float max_x = bounds.max.x - Min.x;
			float min_y = bounds.min.y - Min.z;
			float max_y = bounds.max.y - Min.z;

			int xmin = Mathf.Max (Mathf.FloorToInt (min_x / cell_size.x), 0);
			int xmax = Mathf.Min (Mathf.FloorToInt (max_x / cell_size.x), grid.Width - 1);
			int ymin = Mathf.Max (Mathf.FloorToInt (min_y / cell_size.y), 0);
			int ymax = Mathf.Min (Mathf.FloorToInt (max_y / cell_size.y), grid.Depth - 1);

			for (int y = ymin; y <= ymax; y++) {
				for (int x = xmin; x <= xmax; x++) {
					Cells [x, y].Add (item);
				}
			}
		}

		public Vector3 CellMin(int cell_x, int cell_y) {
			return Min + new Vector3 (cell_size.x * cell_x, 0, cell_size.y * cell_y);
		}

		public Vector3 CellMax(int cell_x, int cell_y) {
			return CellMin (cell_x, cell_y) + new Vector3(cell_size.x, 0, cell_size.y);
		}

//		public Vector3 CellCenter(int cell_x, int cell_y) {
//			return CellMin (cell_x, cell_y) + cell_size * 0.5f;
//		}
	}
}

