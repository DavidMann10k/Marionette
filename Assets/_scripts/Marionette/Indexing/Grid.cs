using UnityEngine;

namespace Marionette.Indexing {
	public struct Grid<T> {
		public Cell<T>[,] Cells { get { return cells; } }
		public int Width { get { return width; } }
		public int Depth { get { return depth; } }

		Cell<T>[,] cells;
		int width;
		int depth;

		public Grid(int width, int depth) {
			this.width = width;
			this.depth = depth;

			cells = new Cell<T>[width,depth];
			for (int x = 0; x < width; x++) {
				for (int y = 0; y < depth; y++) {
					cells [x, y] = new Cell<T> ();
				}
			}
		}

		public void Insert(T item, Bounds2D bounds) {

			int xmin = Mathf.Max (Mathf.FloorToInt (bounds.min.x), 0);
			int xmax = Mathf.Min (Mathf.FloorToInt (bounds.max.x), width - 1);
			int ymin = Mathf.Max (Mathf.FloorToInt (bounds.min.y), 0);
			int ymax = Mathf.Min (Mathf.FloorToInt (bounds.max.y), depth - 1);

			for (int y = ymin; y <= ymax; y++) {
				for (int x = xmin; x <= xmax; x++) {
					cells [x, y].Add (item);
				}
			}
		}
	}
}

