using UnityEngine;

namespace Marionette.Indexing
{
    public struct WorldSpaceGrid<T>
    {
        float cell_width;
        float cell_depth;
        Vector3 position;
        Grid<T> grid;

        public WorldSpaceGrid(int width, int depth, float cell_width, float cell_depth, Vector3 position)
        {
            grid = new Grid<T>(width, depth);
            this.cell_width = cell_width;
            this.cell_depth = cell_depth;
            this.position = position;
        }

        public Cell<T>[,] Cells { get { return grid.Cells; } }

        public Vector3 Min { get { return position; } }

        public Vector3 Max {
            get {
                return position + new Vector3(grid.Width * cell_width, 0, grid.Depth * cell_depth);
            }
        }

        public void Insert(T item, Bounds2D bounds, GridInsertCallback<T> callback)
        {
            // convert center from world to grid space
            Vector2 center = new Vector2(
                (bounds.Center.x - position.x) / cell_width,
                (bounds.Center.y - position.z) / cell_depth);
            Vector2 size = new Vector2(
                bounds.Size.x / cell_width,
                bounds.Size.y / cell_depth);

            grid.Insert(item, new Bounds2D(center, size), callback);
        }

        public void Query(Bounds2D bounds, GridQueryCallback<T> callback)
        {
            // convert center from world to grid space
            Vector2 center = new Vector2(
                (bounds.Center.x - position.x) / cell_width,
                (bounds.Center.y - position.z) / cell_depth);
            Vector2 size = new Vector2(
                bounds.Size.x / cell_width,
                bounds.Size.y / cell_depth);

            grid.Query(new Bounds2D(center, size), callback);
        }

        public void Insert(T item, Vector3 point, GridInsertCallback<T> callback)
        {
            // convert center from wourld to grid space
            float grid_space_x = (point.x - position.x) / cell_width;
            float grid_space_z = (point.z - position.z) / cell_depth;

            grid.Insert(item, new Vector2(grid_space_x, grid_space_z), callback);
        }

        public void Remove(T item)
        {
            grid.Remove(item);
        }

        public Vector3 CellMin(int cell_x, int cell_y)
        {
            return Min + new Vector3(cell_width * cell_x, 0, cell_depth * cell_y);
        }

        public Vector3 CellMax(int cell_x, int cell_y)
        {
            return CellMin(cell_x, cell_y) + new Vector3(cell_width, 0, cell_depth);
        }
    }
}
