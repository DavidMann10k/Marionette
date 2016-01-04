//using UnityEngine;
//using Marionette;
//
//// Picks and sets inventoriable things in the scene
//[RequireComponent (typeof(Marionette.Inventory))]
//public class Picker : MonoBehaviour
//{
//	Inventory inventory;
//
//	void Start ()
//	{
//		inventory = GetComponent<Inventory> ();
//	}
//
//	void Update ()
//	{
//		if (Input.GetMouseButtonUp (0)) {
//			sendPick ();
//		}
//		if (Input.GetMouseButtonUp (1)) {
//			sendSet ();
//		}
//	}
//
//	private void sendPick ()
//	{
//		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//		RaycastHit hit;
//		if (Physics.Raycast (ray, out hit)) {
//			// Debug.Log (hit.transform.gameObject.name);
//			Inventory target_inventory = hit.transform.gameObject.GetComponent<Inventory> ();
//			if (target_inventory != null) {
//				// take an InventoryItem from the clicked inventory
//				inventory.Store (target_inventory.UnStore ());
//			}
//		} else {
//			print ("No inventory found!");
//		}
//	}
//
//	private void sendSet ()
//	{
//		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//		RaycastHit hit;
//		if (Physics.Raycast (ray, out hit)) {
//			Inventory target_inventory = hit.transform.gameObject.GetComponent<Inventory> ();
//			var item = inventory.UnStore ();
//			if (target_inventory != null) {
//				// put an InventoryItem into the clicked inventory
//				target_inventory.Store (inventory.UnStore ());
//			}
//		} else {
//			print ("No inventory found!");
//		}
//	}
//}
