using Marionette.Indexing;
using System.Collections.Generic;
using UnityEngine;

namespace Marionette
{
    public class Senses : MonoBehaviour
    {
        SenseGrid grid;

        [SerializeField]
        float range = 10f;

        HashSet<Sensable> nearby_senses_cache = new HashSet<Sensable>();

        GridQueryCallback<Sensable> query_callback;

        Bounds2D Bounds { 
            get {
                Vector3 center = transform.position;
                return new Bounds2D(new Vector2(center.x, center.z), range);
            }
        }

        void Sense(Sensable sensable)
        {
            if ((sensable.transform.position - transform.position).sqrMagnitude < range * range) {
                nearby_senses_cache.Add(sensable);
            }
        }

        void Start()
        {
            grid = SenseGrid.Instance;
            query_callback = Sense;
        }

        void Update()
        {
            CacheNearbySenses();
        }

        void CacheNearbySenses()
        {
            nearby_senses_cache.Clear();
            grid.Query(Bounds, query_callback);
        }

        void OnDrawGizmos()
        {
            foreach (Sensable s in nearby_senses_cache) {
                Gizmos.DrawLine(transform.position, s.transform.position);
            }
        }
    }
}