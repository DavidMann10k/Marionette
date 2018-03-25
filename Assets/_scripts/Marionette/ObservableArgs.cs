using System;

namespace Marionette
{
    public class ObservableEventArgs<T> : EventArgs
    {
        public ObservableEventArgs(T t)
        {
            Value = t;
        }

        public T Value { get; private set; }
    }
}