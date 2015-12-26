﻿using System;
using UnityEngine;

// Utility class for use with components with Click methods
public class ClickSender : MonoBehaviour
{

	private void Update ()
	{
		if (Input.GetMouseButtonUp (0)) {
			sendClick ();
		}
	}

	private void sendClick ()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			hit.collider.gameObject.SendMessage ("Click", SendMessageOptions.DontRequireReceiver);
		} else {
			// print("no touch!");
		}
	}
}
