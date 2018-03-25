using System;
using UnityEngine;

namespace Marionette
{
    public interface IDirective
    {
        int Priority { get; }

        IBehavior Behavior { get; }

        void Execute(Marionette caller);

        bool IsComplete(Marionette caller);
    }
}
