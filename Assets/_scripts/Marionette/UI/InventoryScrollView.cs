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

		void OnSelectGameObject (object sender, SelectGameObjectArgs e)
		{
			var inventory = e.GameObject.GetComponentInChildren<Inventory> ();
			this.gameObject.SetActive (inventory != null);
			RefreshScrollView (inventory);
		}

		void Start ()
		{
			Click.ClickEvent += new EventHandler<SelectGameObjectArgs> (OnSelectGameObject);
		}

		void OnDestroy ()
		{
			Click.ClickEvent -= new EventHandler<SelectGameObjectArgs> (OnSelectGameObject);
		}
	}
}
