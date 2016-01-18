using UnityEngine;
using System.Collections;

public class AutoDestruct : MonoBehaviour
{
	public float lifespan = 1;

	void Awake ()
	{
		StartCoroutine (Kill ());
	}

	IEnumerator Kill ()
	{
		yield return new WaitForSeconds (lifespan);
		Destroy (gameObject);
	}
}
