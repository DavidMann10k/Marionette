using UnityEngine;
using UnityEngine.UI;
using System;

namespace Marionette.UI
{
	// Listens for SelectEvents and displays 
	public class LifePanel : MonoBehaviour
	{
		public Text text;

		Living current_living;

		Select select;

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
			select.DeselectEvent -= OnDeselectGameObject;
		}

		void OnSelectGameObject (object sender, Select.SelectGameObjectArgs e)
		{	
			var living = e.GameObject.GetComponent<Living> ();

			if (living == null) {
				gameObject.SetActive (false);
				if (current_living != null) {
					UnsubscribeFrom (current_living);
				}
			} else {
				gameObject.SetActive (true);
				SubscribeTo (living);
				updateText (living.Life.ToString ());
			}
		}

		void OnDeselectGameObject(object sender, Select.DeselectGameObjectArgs e) {
			if (current_living != null) {
				current_living.Life.ValueChange -= new EventHandler<ObservableEventArgs<int>> (OnLivingValueChange);
				current_living = null;
			}
			gameObject.SetActive (false);
		}

		void OnLivingValueChange (object sender, ObservableEventArgs<int> e)
		{
			updateText (current_living.Life.ToString ());
		}

		void OnDeath(object sender, Living.DeathArgs e){
			gameObject.SetActive (false);
		}

		void SubscribeTo (Living living)
		{
			living.Life.ValueChange += OnLivingValueChange;
			living.DeathEvent += OnDeath;
			current_living = living;
		}

		void UnsubscribeFrom (Living living)
		{
			living.Life.ValueChange -= OnLivingValueChange;
			living.DeathEvent -= OnDeath;
			current_living = null;
		}

		void updateText (string lifeValue)
		{
			text.text = "Life: " + lifeValue;
		}
	}
}
