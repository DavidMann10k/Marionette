using UnityEngine;

namespace Marionette.Indexing {
	public struct WorldSpaceGrid<T> where T : IGridItem {
		
		public Cell<T>[,] Cells { get { return grid.Cells; } }
		public Vector3 Min { get { return position + new Vector3 (-grid.Width * 0.5f, 0, -grid.Depth * 0.5f); } }
		public Vector3 Max { get { return position + new Vector3 (+grid.Width * 0.5f, 0, +grid.Depth * 0.5f); } }

		float cell_width;
		float cell_depth;
		Vector3 position;
		Grid<T> grid;

		public WorldSpaceGrid(int width, int depth, float cell_width, float cell_depth, Vector3 position) {
			grid = new Grid<T> (width, depth);
			this.cell_width = cell_width;
			this.cell_depth = cell_depth;
			this.position = position;
		}

		public void Insert(T item) {
			var bounds = item.Bounds;
			float min_x = bounds.min.x - Min.x;
			float max_x = bounds.max.x - Min.x;
			float min_y = bounds.min.y - Min.z;
			float max_y = bounds.max.y - Min.z;

			int xmin = Mathf.Max (Mathf.FloorToInt (min_x / cell_width), 0);
			int xmax = Mathf.Min (Mathf.FloorToInt (max_x / cell_width), grid.Width - 1);
			int ymin = Mathf.Max (Mathf.FloorToInt (min_y / cell_depth), 0);
			int ymax = Mathf.Min (Mathf.FloorToInt (max_y / cell_depth), grid.Depth - 1);

			for (int y = ymin; y <= ymax; y++) {
				for (int x = xmin; x <= xmax; x++) {
					Cells [x, y].Add (item);
				}
			}
		}

		public Vector3 CellMin(int cell_x, int cell_y) {
			return Min + new Vector3 (cell_width * cell_x, 0, cell_depth * cell_y);
		}

		public Vector3 CellMax(int cell_x, int cell_y) {
			return CellMin (cell_x, cell_y) + new Vector3(cell_width, 0, cell_depth);
		}

//		public Vector3 CellCenter(int cell_x, int cell_y) {
//			return CellMin (cell_x, cell_y) + cell_size * 0.5f;
//		}
	}
}

