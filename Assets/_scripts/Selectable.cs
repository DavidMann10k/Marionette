using System;
using UnityEngine;
using System.Collections;

public class Selectable : MonoBehaviour
{
	public static event EventHandler<SelectGameObjectArgs> SelectgGameObject;

	private void Update ()
	{
	}

	private void Click ()
	{
		RaiseSelectedInventoryEvent ();
	}

	void RaiseSelectedInventoryEvent ()
	{
		try {
			EventHandler<SelectGameObjectArgs> handler = SelectgGameObject;
			if (handler != null) {
				handler (this, new SelectGameObjectArgs (gameObject));
			}
		} catch (Exception ex) {
			Debug.LogError (ex.Message);
		}
	}
}

public class SelectGameObjectArgs : EventArgs
{
	public GameObject GameObject { get; set; }

	public SelectGameObjectArgs (GameObject game_object)
	{
		GameObject = game_object;
	}
}
