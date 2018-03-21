namespace Marionette.Indexing {
	public struct Grid<T> where T : IGridItem {
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
	}
}

