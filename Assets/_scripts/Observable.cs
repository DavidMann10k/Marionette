using System;

public class Observable<T>
{
	public T Value {
		get { return t; }
		set {
			t = value;
			RaiseValueChangeEvent (value);
		}
	}

	public event EventHandler<ObservableEventArgs<T>> ValueChange;

	T t;

	public Observable (T t)
	{
		this.t = t;
	}

	public override string ToString ()
	{
		return t.ToString ();
	}

	void RaiseValueChangeEvent (T new_value)
	{
		EventHandler<ObservableEventArgs<T>> handler = ValueChange;
		if (handler != null) {
			handler (this, new ObservableEventArgs<T> (new_value));
		}
	}
}

public class ObservableEventArgs<T> : EventArgs
{
	public T Value { get; private set; }

	public ObservableEventArgs (T t)
	{
		Value = t;
	}
}
