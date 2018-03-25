using System;
using UnityEngine;

namespace Marionette
{
    // Directive pausing all action
    public class PauseDirective : IDirective
    {
        float duration = 1000;

        float pause_start;

        public PauseDirective(float duration, IBehavior caller)
        {
            Behavior = caller;
            this.duration = duration;
            this.pause_start = Time.time;
            Priority = 1;
        }

        public int Priority { get; private set; }

        public IBehavior Behavior { get; private set; }

        public void Execute(Marionette caller)
        {
            // Debug.Log ("Executing pause directive");
            // do nothing?
        }

        public bool IsComplete(Marionette caller)
        {
            return Time.time >= pause_start + duration;
        }
    }
}
