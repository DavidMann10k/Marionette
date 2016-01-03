using UnityEngine;
using UnityEngine.UI;
using System;

namespace Marionette.UI
{
	public class InventoryScrollView : MonoBehaviour
	{
		public Text ItemTextPrefab;

		public RectTransform Content;

		public void RefreshScrollView (Inventory inventory)
		{
			foreach (RectTransform child in Content) {
				Destroy (child.gameObject);
			}
			if (inventory != null) {
				foreach (InventoryItem i in inventory.Items) {
					var text = Instantiate<Text> (ItemTextPrefab);
					text.text = i.ItemName;
					text.rectTransform.SetParent (Content);
				}
			}
		}

		void OnSelectInventory (object sender, SelectInventoryArgs e)
		{
			RefreshScrollView (e.Inventory);
		}

		void Start ()
		{
			Inventory.SelectInventory += new EventHandler<SelectInventoryArgs> (OnSelectInventory);
		}
	}
}
