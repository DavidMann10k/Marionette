using UnityEngine;

// the physical structure of a character
public class Conformation : MonoBehaviour
{
    [SerializeField]
    Vector3 feetOffset = Vector3.zero;

    Vector3 feet_dimensions = (Vector3.right + Vector3.forward) * 0.25f;

    public Vector3 FeetPosition {
        get { return transform.position + FeetOffset; }
    }

    public Vector3 FeetOffset { get { return feetOffset; } }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, FeetPosition);
        Gizmos.DrawWireCube(FeetPosition, feet_dimensions);
    }
}
