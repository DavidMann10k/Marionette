using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Marionette
{
    public class SensesSortedList : MonoBehaviour
    {
        static List<IndexItem> senses_list = new List<IndexItem>();

        [SerializeField]
        float senseRange = 10f;

        List<SensesSortedList> nearby_senses_cache = new List<SensesSortedList>();

        IndexItem index_item;

        void Start()
        {
            index_item = new IndexItem(transform.position, this);
            senses_list.Add(index_item);
        }

        void Update()
        {
            CacheNearbySenses();
            IndexPosition();
        }

        void IndexPosition()
        {
            index_item.Position = transform.position;
        }

        [Obsolete]
        void CacheNearbySensesLinq()
        {
            nearby_senses_cache.Clear();

            nearby_senses_cache = senses_list.Where(i =>
                i.Position.x < transform.position.x + senseRange &&
                i.Position.x > transform.position.x - senseRange &&
                i.Position.z < transform.position.z + senseRange &&
                i.Position.z > transform.position.z - senseRange).Select(j => j.Object).ToList();
        }

        bool IsInRange(Vector3 point)
        {
            return (point - transform.position).sqrMagnitude < senseRange * senseRange;
        }

        void CacheNearbySenses()
        {
            nearby_senses_cache.Clear();

            foreach (IndexItem i in senses_list) {
                if (true) {
                    if (IsInRange(i.Object.transform.position)) {
                        nearby_senses_cache.Add(i.Object);
                    }
                }
            }
        }

        void OnDrawGizmos()
        {
            foreach (SensesSortedList s in nearby_senses_cache) {
                Gizmos.DrawLine(transform.position, s.transform.position);
            }
        }

        void OnDestroy()
        {
            senses_list.Remove(index_item);
        }

        struct IndexItem
        {
            public IndexItem(Vector3 position, SensesSortedList game_object)
                : this()
            {
                Object = game_object;
                Position = position;
            }

            public SensesSortedList Object { get; private set; }

            public Vector3 Position { get; set; }
        }
    }
}
