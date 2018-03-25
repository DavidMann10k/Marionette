using System;
using UnityEngine;

namespace Marionette
{
    // Directive for moving to a point in wold space
    public class MoveDirective : IDirective
    {
        private Vector3 destination;

        public MoveDirective(Vector3 position, IBehavior caller)
        {
            Behavior = caller;
            this.destination = position;
            Priority = 1;
        }

        public int Priority { get; private set; }

        public IBehavior Behavior { get; private set; }

        public void Execute(Marionette caller)
        {
            // Debug.Log ("Executing move directive");
            caller.Navigator.MoveTo(destination);
        }

        public bool IsComplete(Marionette caller)
        {
            return Vector3.Distance(caller.transform.position, destination) < 1;
        }
    }
}
