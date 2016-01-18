using UnityEngine;

// Super dirty testing class
// it will instantiate [prefab] every [interval] seconds
public class Spawner : MonoBehaviour
{

	public float Interval;

	public GameObject Prefab;

	// Use this for initialization
	void Start ()
	{
		InvokeRepeating ("spawn", 0, Interval);
	}

	void spawn ()
	{
		Instantiate (Prefab, transform.position, Quaternion.identity);
	}
}
