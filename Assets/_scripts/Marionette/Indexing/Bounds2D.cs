using UnityEngine;

namespace Marionette.Indexing
{
    public struct Bounds2D
    {
        Vector2 center;
        Vector2 size;

        public Bounds2D(Vector2 center, Vector2 size)
        {
            this.center = center;
            this.size = size;
        }

        public Bounds2D(Vector2 center, float size)
        {
            this.center = center;
            this.size = new Vector2(size, size);
        }

        public Vector2 Center { get { return center; } }

        public Vector2 Size { get { return size; } }

        public Vector2 Min { get { return Center - (Size * 0.5f); } }

        public Vector2 Max { get { return Center + (Size * 0.5f); } }
    }
}
