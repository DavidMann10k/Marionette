using UnityEngine;

// Super dirty testing class
// it will instantiate [prefab] every [interval] seconds
public class Spawner : MonoBehaviour
{

	public float Interval;

	public int limit;

	public GameObject Prefab;

	private float last_spawn_time = 0f;

	private int count = 0;

	void Update ()
	{
		if (count < limit) {
			if (Time.time > last_spawn_time + Interval) {
				last_spawn_time = Time.time;
				spawn ();
			}
		}
	}

	void spawn ()
	{
		Instantiate (Prefab, transform.position, Quaternion.identity);
		count += 1;
	}
}
