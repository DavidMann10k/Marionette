using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashSetTest : MonoBehaviour {
	HashSet<GameObject> lista = new HashSet<GameObject> ();
	HashSet<GameObject> listb = new HashSet<GameObject>();

	void Start () {
		for (int i = 0; i < 1000; i++) {
			lista.Add(new GameObject ());
		}
	}

	void Update () {
		if (lista.Count > listb.Count) {
			foreach(GameObject item in lista) {
				listb.Add (item);
				lista.Remove (item);
			}
		} else {
			foreach(GameObject item in listb) {
				lista.Add (item);
				listb.Remove (item);
			}
		}
	}
}
