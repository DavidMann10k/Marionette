using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Marionette
{
    [RequireComponent(typeof(Locomotion))]
    public class Navigator : MonoBehaviour, INavigator, IDies
    {
        const float ARRIVAL_DISTANCE = 0.1f;

        [SerializeField]
        float speed = 1f;

        ILocomotion locomotion;

        Vector3? destination;

        public void MoveTo(Vector3 destination)
        {
            this.destination = destination;
        }

        public void OnDeath()
        {
            this.enabled = false;
        }

        bool ArrivedAt(Vector3 point)
        {
            return (((point.x - transform.position.x) * (point.x - transform.position.x)) +
                ((point.z - transform.position.z) * (point.z - transform.position.z))) <
                ARRIVAL_DISTANCE * ARRIVAL_DISTANCE;
        }

        Vector3 DistanceTo(Vector3 point)
        {
            return point - transform.position;
        }

        void Awake()
        {
            locomotion = GetComponent<ILocomotion>();
        }

        void Update()
        {
            if (destination != null) {
                // if within arrival distance of destination
                if ((destination.Value - transform.position).sqrMagnitude < ARRIVAL_DISTANCE * ARRIVAL_DISTANCE) {
                    destination = null;
                }
                else {
                    locomotion.Move((destination.Value - transform.position).normalized * speed);
                }
            }
            else {
                // no destination, nowhere to go
            }
        }
    }
}
