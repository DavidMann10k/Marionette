using UnityEngine;
using System;

public class TestObservable : MonoBehaviour
{
	

	Observable<int> hitpoints = new Observable<int> (50);

	[SerializeField]
	string gui_text = "";

	void Start ()
	{
		hitpoints.ValueChange += new EventHandler<ObservableEventArgs<int>> (OnTextChange);
		UpdateText (hitpoints.ToString ());
	}

	void Update ()
	{
		if (Input.GetMouseButtonUp (0)) {
//			Debug.Log ("CLICK");
			hitpoints.Value -= 1;
		}
	}

	void OnTextChange (object sender, ObservableEventArgs<int> e)
	{
		Debug.Log ("OnTextChange!");
		UpdateText (e.Value.ToString ());
	}

	void UpdateText (string new_value)
	{
		gui_text = new_value;
	}

	void OnGUI ()
	{
		GUI.Label (new Rect (0, 0, 200, 30), gui_text);
	}
}
