using UnityEngine;
using System;

public class Select : MonoBehaviour
{
	void Start ()
	{
		Click.ClickEvent += new EventHandler<SelectGameObjectArgs> (OnSelectGameObject);
	}

	void OnSelectGameObject (object sender, SelectGameObjectArgs e)
	{
		Deselect ();
		e.GameObject.AddComponent<Selected> ();
		//Selected.Value = e.GameObject;
	}

	void Deselect()
	{
		foreach (GameObject go in Selected.SelectedObjects())
		{
			Destroy (go.GetComponent<Selected> ());
		}
	}
}
