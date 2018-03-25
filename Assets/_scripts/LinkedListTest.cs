using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Marionette;

public class LinkedListTest : MonoBehaviour {
	LinkedList<Sensable> lista = new LinkedList<Sensable> ();
	LinkedList<Sensable> listb = new LinkedList<Sensable>();

	void Start () {
		for (int i = 0; i < 1000; i++) {
			lista.AddFirst(new Sensable ());
		}
	}

	void Update () {
		if (lista.Count > listb.Count) {
			while (lista.Count > 0) {
				listb.AddFirst (lista.First.Value);
				lista.RemoveFirst ();
			}
		} else {
			while (listb.Count > 0) {
				lista.AddFirst (listb.First.Value);
				listb.RemoveFirst ();
			}
		}
	}
}
