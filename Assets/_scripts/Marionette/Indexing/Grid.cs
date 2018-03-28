using UnityEngine;

namespace Marionette.Indexing
{
    public struct Grid<T> where T : IGridItem<T>
    {
        Cell<T>[,] cells;
        int width;
        int depth;

        public Grid(int width, int depth)
        {
            this.width = Mathf.Max(width, 1);
            this.depth = Mathf.Max(depth, 1);

            cells = new Cell<T>[this.width, this.depth];
            for (int x = 0; x < this.width; x++) {
                for (int y = 0; y < this.depth; y++) {
                    cells[x, y] = new Cell<T>();
                }
            }
        }

        public Cell<T>[,] Cells { get { return cells; } }

        public int Width { get { return width; } }

        public int Depth { get { return depth; } }

        public void Insert(T item, Bounds2D bounds)
        {
            int xmin = Mathf.Max(Mathf.FloorToInt(bounds.Min.x), 0);
            int xmax = Mathf.Min(Mathf.FloorToInt(bounds.Max.x), width - 1);
            int ymin = Mathf.Max(Mathf.FloorToInt(bounds.Min.y), 0);
            int ymax = Mathf.Min(Mathf.FloorToInt(bounds.Max.y), depth - 1);

            for (int y = ymin; y <= ymax; y++) {
                for (int x = xmin; x <= xmax; x++) {
                    cells[x, y].Add(item);
                    item.OnInsert(cells[x, y]);
                }
            }
        }

        public void Insert(T item, Vector2 point)
        {
            int x = Mathf.FloorToInt(point.x);
            int y = Mathf.FloorToInt(point.y);

            if (x >= 0 && x < width && y >= 0 && y < depth) {
                cells[x, y].Add(item);
                item.OnInsert(cells[x, y]);
            }
        }

        public void Remove(T item)
        {
            foreach (Cell<T> cell in cells) {
                cell.Remove(item);
            }
        }
    }
}
