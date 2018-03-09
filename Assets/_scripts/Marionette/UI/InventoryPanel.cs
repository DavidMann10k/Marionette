using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Marionette {
	public class InventoryPanel : MonoBehaviour {

		[SerializeField]
		GameObject ItemPanelPrefab;

		[SerializeField]
		Transform ItemsPanel;

		Select select;
		Inventory current_inventory;

		List<GameObject> item_panels = new List<GameObject>();

		void Start ()
		{
			select = FindObjectOfType<Select> ();
			select.SelectEvent += OnSelectGameObject;
			select.DeselectEvent += OnDeselectGameObject;
			gameObject.SetActive (false);
		}

		void OnDestroy ()
		{
			select.SelectEvent -= OnSelectGameObject;
		}

		void OnSelectGameObject (object sender, Select.SelectGameObjectArgs e) {
			current_inventory = e.GameObject.GetComponent<Inventory> ();

			if (current_inventory == null) {
				gameObject.SetActive (false);
			} else {
				gameObject.SetActive (true);
				RefreshItemPanels ();
			}
		}

		void OnDeselectGameObject (object sender, Select.DeselectGameObjectArgs e) {
			gameObject.SetActive (false);
		}

		void RefreshItemPanels() {
			ClearItemPanels ();

			foreach (var item in current_inventory.Items) {
				var go = Instantiate (ItemPanelPrefab, ItemsPanel);
				go.GetComponentInChildren<Text> ().text = item.ItemName;
				go.SetActive (true);
				item_panels.Add(go);
			}
		}

		void ClearItemPanels() {
			foreach (var go in item_panels) {
				Destroy (go);
			}
		}
	}
}