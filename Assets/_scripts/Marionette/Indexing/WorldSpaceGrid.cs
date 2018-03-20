using UnityEngine;

namespace Marionette.Indexing {
	public struct WorldSpaceGrid<T> {
		
		public Bounds2D Bounds { get { return new Bounds2D (position, Vector2.Scale(cell_size, new Vector2(grid.Width, grid.Depth))); } }
		public Cell<T>[,] Cells { get { return grid.Cells; } }

		Vector2 cell_size;
		Vector3 position;
		Grid<T> grid;

		public WorldSpaceGrid(int width, int depth, Vector2 cell_size, Vector3 position) {
			grid = new Grid<T> (width, depth);
			this.cell_size = cell_size;
			this.position = position;
		}

		public void Insert(T obj) {
			grid.Insert (obj);
		}

		public Vector2 CellMin(int cell_x, int cell_y) {
			return new Vector2 (
				Bounds.min.x + cell_x * cell_size.x,
				Bounds.min.y + cell_y * cell_size.y
			);
		}

		public Vector2 CellMax(int cell_x, int cell_y) {
			return CellMin (cell_x, cell_y) + cell_size;
		}

		public Vector2 CellCenter(int cell_x, int cell_y) {
			return CellMin (cell_x, cell_y) + cell_size * 0.5f;
		}
	}
}

