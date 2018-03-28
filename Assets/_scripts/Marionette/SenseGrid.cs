using Marionette.Indexing;
using UnityEngine;

namespace Marionette
{
    [ExecuteInEditMode]
    public class SenseGrid : MonoBehaviour
    {
        [SerializeField]
        int depth = 10;

        [SerializeField]
        int width = 10;

        [SerializeField]
        float cell_width = 1.0f;

        [SerializeField]
        float cell_depth = 1.0f;

        Indexing.WorldSpaceGrid<Sensable> grid;

        public static SenseGrid Instance { get; private set; }

        public void InsertSensable(Sensable sensable)
        {
            // grid.Insert(sensable, sensable.Bounds);
            grid.Insert(sensable, sensable.transform.position);
        }

        public void RemoveSensable(Sensable sensable)
        {
            grid.Remove(sensable);
        }

        void InstantiateGrid()
        {
            grid = new WorldSpaceGrid<Sensable>(width, depth, cell_width, cell_depth, transform.position);
        }

        void Awake()
        {
            EnforceSingleton();
            InstantiateGrid();
        }

        void EnforceSingleton()
        {
            if (Instance == null) {
                Instance = this;
            }
            else if (Instance != this) {
                Destroy(gameObject);
            }
        }

        void OnValidate()
        {
            InstantiateGrid();
            width = Mathf.Clamp(width, 1, 1000);
            depth = Mathf.Clamp(depth, 1, 1000);
            cell_width = Mathf.Clamp(cell_width, 0.001f, 1000);
            cell_depth = Mathf.Clamp(cell_depth, 0.001f, 1000);
        }

        void OnDrawGizmos()
        {
            GizmosDrawGrid();
            Gizmos.color = Color.cyan;
            GizmosDrawBounds();
        }

        void GizmosDrawGrid()
        {
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < depth; y++) {
                    Gizmos.color = Color.green;
                    GizmosDrawSquare(grid.CellMin(x, y), grid.CellMax(x, y), transform.position.y);
                    for (int i = 0; i < grid.Cells[x, y].ItemCount; i++) {
                        Gizmos.color = Color.red;
                        GizmosDrawSquare(grid.CellMin(x, y), grid.CellMax(x, y), transform.position.y + (i * (0.1f + 0.1f)));
                    }
                }
            }
        }

        void GizmosDrawBounds()
        {
            GizmosDrawSquare(grid.Min, grid.Max, transform.position.y);
        }

        void GizmosDrawSquare(Vector3 min, Vector3 max, float y)
        {
            Gizmos.DrawLine(new Vector3(min.x, y, min.z), new Vector3(max.x, y, min.z));
            Gizmos.DrawLine(new Vector3(max.x, y, min.z), new Vector3(max.x, y, max.z));
            Gizmos.DrawLine(new Vector3(max.x, y, max.z), new Vector3(min.x, y, max.z));
            Gizmos.DrawLine(new Vector3(min.x, y, max.z), new Vector3(min.x, y, min.z));
        }
    }
}