using UnityEngine;
using UnityEngine.UI;
using System;

namespace Marionette.UI
{
	public class LifePanel : MonoBehaviour
	{
		public Text text;
		public GameObject panel;

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
			var living = e.GameObject.GetComponent<Living>();

			if (living == null) {
				panel.SetActive(false);
			} else {
				panel.SetActive(true);
				updateText(living.Life.ToString());
			}
		}

		void updateText(string lifeValue)
		{
			text.text = "Life: " + lifeValue;
		}
	}
}