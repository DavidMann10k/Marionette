using System;
using UnityEngine;
using Marionette;

[RequireComponent (typeof(Marionette.Inventory))]
public class Picker : MonoBehaviour
{
	Inventory inventory;

	void Start ()
	{
		inventory = GetComponent<Inventory> ();
	}

	void Update ()
	{
		if (Input.GetMouseButtonUp (0)) {
			sendPick ();
		}
		if (Input.GetMouseButtonUp (1)) {
			sendSet ();
		}
	}

	private void sendPick ()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			Debug.Log (hit.transform.gameObject.name);
			Inventoriable item = hit.transform.gameObject.GetComponent<Inventoriable> ();
			if (item != null) {
				inventory.Store (item);
			}
		} else {
			print ("nothing to pick!");
		}
	}

	private void sendSet ()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			var item = inventory.UnStore ();
			if (item != null) {
				item.gameObject.transform.position = hit.point;
			}
		} else {
			print ("nowhere to set!");
		}
	}
}
