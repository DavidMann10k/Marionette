using UnityEngine;

namespace Marionette.Indexing {
	public struct Bounds2D {
		public Vector2 Center { get { return center; } }
		public Vector2 Size { get { return size; } }
		public Vector2 min { get { return Center - Size * 0.5f; } }
		public Vector2 max { get { return Center + Size * 0.5f; } }

		Vector2 center;
		Vector2 size;

		public Bounds2D(Vector2 center, Vector2 size) {
			this.center = center;
			this.size = size;
		}
	}
}

