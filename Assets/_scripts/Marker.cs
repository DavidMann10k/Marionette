using UnityEngine;
using System.Collections;

public class Marker : MonoBehaviour {

    [SerializeField]
    private float size = 1;

    [SerializeField]
    private Color color = Color.white;

	private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, size);
    }
}
