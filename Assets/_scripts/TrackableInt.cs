using System;

public struct TrackableInt {

	public event EventHandler<TrackableIntEventArgs> ValueChange;

	public int Value {
		get { return value; }
		set { 
			this.value = value;
			RaiseValueChangeEvent(value);
		}
	}

	int value;

	public static explicit operator TrackableInt(int value)
	{
		return new TrackableInt() { Value = value };
	}

	public static explicit operator int(TrackableInt ti)
	{
		return ti.value;
	}


	void RaiseValueChangeEvent(int new_value)
	{
		EventHandler<TrackableIntEventArgs> handler = ValueChange;
		if (handler != null)
		{
			handler(this, new TrackableIntEventArgs(new_value));
		}
	}
}

public class TrackableIntEventArgs : EventArgs
{
	public int NewValue { get; private set; }

	public TrackableIntEventArgs(int new_value)
	{
		NewValue = new_value;
	}
}