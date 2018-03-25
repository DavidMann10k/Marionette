﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Marionette
{
    public class Senses : MonoBehaviour
    {
        static List<Senses> senses_list = new List<Senses>();

        [SerializeField]
        float range = 10f;

        List<Senses> nearby_senses_cache = new List<Senses>();

        void Start()
        {
            senses_list.Add(this);
        }

        void Update()
        {
            CacheNearbySenses();
        }

        void CacheNearbySenses()
        {
            nearby_senses_cache.Clear();
            foreach (Senses s in senses_list) {
                if ((s.transform.position - transform.position).sqrMagnitude < range * range) {
                    nearby_senses_cache.Add(s);
                }
            }
        }

        void OnDrawGizmos()
        {
            foreach (Senses s in nearby_senses_cache) {
                Gizmos.DrawLine(transform.position, s.transform.position);
            }
        }

        void OnDestroy()
        {
            senses_list.Remove(this);
        }
    }
}