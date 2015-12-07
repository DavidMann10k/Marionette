using System;
using UnityEngine;

namespace Marionette
{
    /// <summary>
    /// Locomotion controls basic steering. Give it a destination and it moves there.
    /// </summary>
    public class Locomotion : MonoBehaviour
    {
        [SerializeField]
        private float movement_speed = 1f;

        [SerializeField]
        private float rotation_speed = 1f;

        [SerializeField]
        private Vector3 destination;

        private Vector3 vector_to_destination
        {
            get
            {
                return destination - transform.position;
            }
        }

        private Vector3 world_direction_to_destination
        {
            get
            {
                return vector_to_destination.normalized;
            }
        }

        private Vector3 local_direction_to_destination
        {
            get
            {
                return transform.InverseTransformDirection(world_direction_to_destination);
            }
        }

        private float distance_to_destination
        {
            get
            {
                return vector_to_destination.magnitude;
            }
        }

        private float movement_step
        {
            get
            {
                return movement_speed * Time.deltaTime;
            }
        }

        private float rotation_step
        {
            get
            {
                return rotation_speed * Time.deltaTime;
            }
        }

        private Vector3 rotation_towards_destination
        {
            get
            {
                return Vector3.RotateTowards(transform.forward, world_direction_to_destination, rotation_step, 0.0f);
            }
        }

        public void MoveTo(Vector3 destination)
        {
            this.destination = destination;

        }

        private void Update()
        {
            Rotate();
            Move();
        }

        private void Rotate()
        {
            var rotation = Quaternion.Inverse(transform.rotation) * Quaternion.LookRotation(rotation_towards_destination);
            transform.Rotate(rotation.eulerAngles);
        }

        private void Move()
        {
            Debug.DrawLine(transform.position, destination);

            // blend forward movement and direction to destination 50/50
            var translation = (local_direction_to_destination + Vector3.forward).normalized * movement_step;
            transform.Translate(translation, Space.Self);
        }
    }
}