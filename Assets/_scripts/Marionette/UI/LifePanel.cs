using UnityEngine;
using UnityEngine.UI;
using System;

namespace Marionette.UI
{
	public class LifePanel : MonoBehaviour
	{
		public Text text;
		public GameObject panel;

		Living current_living;

		void Start ()
		{
			Click.SelectGameObject += new EventHandler<SelectGameObjectArgs> (OnSelectGameObject);
		}

		void OnDestroy ()
		{
			Click.SelectGameObject -= new EventHandler<SelectGameObjectArgs> (OnSelectGameObject);
		}

		void OnSelectGameObject (object sender, SelectGameObjectArgs e)
		{
			var living = e.GameObject.GetComponent<Living> ();

			if (living == null) {
				panel.SetActive (false);
				if (current_living != null) {
					current_living.Life.ValueChange -= new EventHandler<ObservableEventArgs<int>> (OnLivingValueChange);
				}
			} else {
				panel.SetActive (true);
				current_living = living;
				current_living.Life.ValueChange += new EventHandler<ObservableEventArgs<int>> (OnLivingValueChange);
				updateText (living.Life.ToString ());
			}
		}

		void OnLivingValueChange (object sender, ObservableEventArgs<int> e)
		{
			updateText (current_living.Life.ToString ());
		}

		void updateText (string lifeValue)
		{
			text.text = "Life: " + lifeValue;
		}
	}
}
