using UnityEngine;

namespace Marionette.Indexing {
	public struct WorldSpaceGrid<T> where T : IGridItem {
		
		public Cell<T>[,] Cells { get { return grid.Cells; } }
		public Vector3 Min { get { return position; } }

		public Vector3 Max {
			get {
				return position + new Vector3 (grid.Width * cell_width, 0, grid.Depth * cell_depth);
			}
		}

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
			Bounds2D bounds = item.Bounds;

			// convert center from wourld to grid space
			Vector2 center = new Vector2 (
				(item.Bounds.Center.x - position.x) / cell_depth,
				(item.Bounds.Center.y - position.y) / cell_width);
			Vector2 size = new Vector2 (
				item.Bounds.Size.x / cell_width,
				item.Bounds.Size.y / cell_depth);

			grid.Insert (item, new Bounds2D(center, size));
		}

		public Vector3 CellMin(int cell_x, int cell_y) {
			return Min + new Vector3 (cell_width * cell_x, 0, cell_depth * cell_y);
		}

		public Vector3 CellMax(int cell_x, int cell_y) {
			return CellMin (cell_x, cell_y) + new Vector3(cell_width, 0, cell_depth);
		}
	}
}

