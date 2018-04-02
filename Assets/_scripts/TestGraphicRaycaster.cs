using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TestGraphicRaycaster : MonoBehaviour {

    GraphicRaycaster graphics_raycaster;
    PhysicsRaycaster physics_raycaster;
    PointerEventData pointer_event_data;
    EventSystem event_system;

	void Start () {
        graphics_raycaster = FindObjectOfType<GraphicRaycaster>();
        event_system = FindObjectOfType<EventSystem>();
        physics_raycaster = FindObjectOfType<PhysicsRaycaster>();
    }
	
	void Update () {
        if(Input.GetMouseButtonDown(0)) {
            DebugGraphic();

            pointer_event_data = new PointerEventData(event_system);
            pointer_event_data.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            physics_raycaster.Raycast(pointer_event_data, results);
            foreach (RaycastResult r in results) {
                Debug.Log(r.gameObject.name);
            }
        }
	}

    void DebugGraphic()
    {
        pointer_event_data = new PointerEventData(event_system);
        pointer_event_data.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        graphics_raycaster.Raycast(pointer_event_data, results);
        foreach (RaycastResult r in results) {
            Debug.Log(r.gameObject.name);
        }
    }
}
