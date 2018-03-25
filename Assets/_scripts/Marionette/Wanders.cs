using UnityEngine;
using System;
using System.Collections.Generic;

namespace Marionette
{
    // Adds wandering behavior to an AI agent
    [RequireComponent(typeof(Marionette))]
    public class Wanders : MonoBehaviour, IBehavior
    {
        [SerializeField]
        float distance = 5;

        [SerializeField]
        float pause_duration = 1;

        Marionette marionette;

        Vector3 RandomNearbyPosition {
            get {
                var randomVector = UnityEngine.Random.insideUnitCircle * distance;
                return marionette.transform.position + new Vector3(randomVector.x, 0, randomVector.y);
            }
        }

        public void ConcludeDirective(IDirective directive)
        {
            if (directive.GetType() == typeof(MoveDirective)) {
                CreatePauseDirective();
            }
            else {
                CreateMoveDirective();
            }
        }

        public void OnDeath()
        {
            Destroy(this);
        }

        void CreateMoveDirective()
        {
            marionette.AddDirective(new MoveDirective(RandomNearbyPosition, this));
        }

        void CreatePauseDirective()
        {
            marionette.AddDirective(new PauseDirective(pause_duration, this));
        }

        void Start()
        {
            marionette = GetComponent<Marionette>();
            CreateMoveDirective();
        }
    }
}
