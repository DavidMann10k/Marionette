using UnityEngine;

namespace Marionette {
	public class Sensable : MonoBehaviour, Indexing.IGridItem {
		SenseGrid grid;
		Bounds Bounds { get; set; }

		void Start () {
			grid = SenseGrid.Instance;
			grid.InsertSensable (this);
			Bounds = GetComponent<Renderer> ().bounds;
		}
	}
}