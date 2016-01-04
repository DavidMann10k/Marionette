using UnityEngine;
using UnityEngine.UI;
using System;

namespace Marionette.UI
{
	public class SelectablePanel : MonoBehaviour
	{
		public Text selectedText;

		void Start ()
		{
			Click.SelectgGameObject += new EventHandler<SelectGameObjectArgs> (OnSelectGameObject);
		}

		void OnDestroy ()
		{
			Click.SelectgGameObject -= new EventHandler<SelectGameObjectArgs> (OnSelectGameObject);
		}

		void OnSelectGameObject (object sender, SelectGameObjectArgs e)
		{
			if (String.IsNullOrEmpty (e.GameObject.name)) {
				selectedText.text = "Selected: None";
			} else {
				selectedText.text = "Selected: " + e.GameObject.name;
			}
		}
	}
}