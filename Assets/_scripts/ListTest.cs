using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Marionette;

public class ListTest : MonoBehaviour {
	List<Sensable> lista = new List<Sensable> ();
	List<Sensable> listb = new List<Sensable>();

	void Start () {
		for (int i = 0; i < 1000; i++) {
			lista.Add(new Sensable ());
		}
	}

	void Update () {
		if (lista.Count > listb.Count) {
			while (lista.Count > 0) {
				listb.Add(lista[0]);
				lista.RemoveAt(0);
			}
		} else {
			while (listb.Count > 0) {
				lista.Add(listb[0]);
				listb.RemoveAt(0);
			}
		}
	}
}
