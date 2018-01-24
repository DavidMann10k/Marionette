using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class Selected : MonoBehaviour {
	public static List<GameObject> SelectedObjects()
	{
		return FindObjectsOfType<Selected>().Select(x => x.gameObject).ToList();
	}

	void Awake()
	{
		gameObject.AddComponent<Outline> ();
	}

	void OnDestroy()
	{
		Destroy(gameObject.GetComponent<Outline>());
	}
}
