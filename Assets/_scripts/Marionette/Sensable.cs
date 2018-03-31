using Marionette.Indexing;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Marionette
{
    public class Sensable : MonoBehaviour
    {
        SenseGrid grid;
        new Renderer renderer;
        Cell<Sensable> cell;
        GridInsertCallback<Sensable> insertCallback;

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
            if (grid == null)
                throw new Exception("Sensable requires a SenseGrid in the scene to function.");
            insertCallback = OnInsert;
            grid.InsertSensable(this, insertCallback);
        }

        void Update()
        {
            if (cell != null) {
                RemoveItemFromCell();
            }

            grid.InsertSensable(this, insertCallback);
        }

        void RemoveItemFromCell()
        {
            cell.Remove(this);
            cell = null;
        }
    }
}