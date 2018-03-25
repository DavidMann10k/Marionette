using UnityEngine;
using System.Collections;

public class AutoDestruct : MonoBehaviour
{
    [SerializeField]
    float lifespan = 1;

    void Awake()
    {
        StartCoroutine(Kill());
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(lifespan);
        Destroy(gameObject);
    }
}
