using Marionette.Indexing;
using UnityEngine;

namespace Marionette
{
    public class Sensable : MonoBehaviour, Indexing.IGridItem
    {
        SenseGrid grid;
        new Renderer renderer;

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

        void Start()
        {
            grid = SenseGrid.Instance;
            grid.InsertSensable(this);
            grid.RemoveSensable(this);
        }

        void Update()
        {
            grid.RemoveSensable(this);
            grid.InsertSensable(this);
        }
    }
}