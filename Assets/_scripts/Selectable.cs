using System;
using UnityEngine;
using System.Collections;

public class Selectable : MonoBehaviour {

    public static GameObject Selected
    {
        get { return selected; }
    }

    private static GameObject selected;

    private void Update()
    {
    }

    private void Click()
    {
        selected = gameObject;
    }
}
