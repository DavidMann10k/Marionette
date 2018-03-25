using System;

namespace Marionette
{
    public class Observable<T>
    {
        T t;

        public Observable(T t)
        {
            this.t = t;
        }

        public event EventHandler<ObservableEventArgs<T>> ValueChange;

        public T Value {
            get {
                return t;
            }

            set {
                t = value;
                RaiseValueChangeEvent(value);
            }
        }

        public override string ToString() { return t.ToString(); }

        void RaiseValueChangeEvent(T new_value)
        {
            EventHandler<ObservableEventArgs<T>> handler = ValueChange;
            if (handler != null) {
                handler(this, new ObservableEventArgs<T>(new_value));
            }
        }
    }
}
