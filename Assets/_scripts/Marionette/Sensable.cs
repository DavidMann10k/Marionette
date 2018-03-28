using Marionette.Indexing;
using System.Collections.Generic;
using UnityEngine;

namespace Marionette
{
    public class Sensable : MonoBehaviour, Indexing.IGridItem<Sensable>
    {
        SenseGrid grid;
        new Renderer renderer;
        Cell<Sensable> cell;

        public Bounds2D Bounds { 
            get {
                Vector3 center = Renderer.bounds.center;
                return new Bounds2D(new Vector2(center.x, center.z), renderer.bounds.size);
            }
        }

        Renderer Renderer { 
            get {
                if (renderer == null) {
                    renderer = GetComponent<Renderer>();
                }

                return renderer;
            }
        }

        public void OnInsert(Cell<Sensable> cell)
        {
            this.cell = cell;
        }

        void Start()
        {
            grid = SenseGrid.Instance;
            grid.InsertSensable(this);
        }

        void Update()
        {
            if (cell != null) {
                RemoveItemFromCell();
            }

            grid.InsertSensable(this);
        }

        void RemoveItemFromCell()
        {
            cell.Remove(this);
            cell = null;
        }
    }
}