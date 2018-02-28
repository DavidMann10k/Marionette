using UnityEngine;
using System;
using Marionette.Utilities;

namespace Marionette
{
	// Listens for ClickEvents and manages Selected behavior on GameObjects
	public class Select : MonoBehaviour
	{
		[SerializeField]
		MouseButton select_button = MouseButton.Left;

		[SerializeField]
		MouseButton deselect_button = MouseButton.Right;

		public event EventHandler<SelectGameObjectArgs> SelectEvent;
		public event EventHandler<DeselectGameObjectArgs> DeselectEvent;

		Click click;

		void Start ()
		{
			click = FindObjectOfType<Click> ();
			click.ClickEvent += new EventHandler<Click.ClickArgs> (OnClick);
		}

		void OnClick (object sender, Click.ClickArgs e)
		{

			if (e.MouseIndex == (int)deselect_button ||
				e.GameObject == null) {
				Selectable.DeselectAll ();
				RaiseDeselectEvent ();
				return;
			}

			if (e.MouseIndex == (int)select_button) {
				var selectable = e.GameObject.GetComponent<Selectable> ();
				Selectable.DeselectAll ();
				RaiseDeselectEvent ();
				if (selectable != null) {
					selectable.Select ();
					RaiseSelectEvent (e.GameObject);
				}
				return;
			}
		}

		void RaiseSelectEvent (GameObject game_object)
		{
			EventHandler<SelectGameObjectArgs> handler = SelectEvent;
			if (handler != null) {
				handler (this, new SelectGameObjectArgs (game_object));
			}
		}

		void RaiseDeselectEvent ()
		{
			EventHandler<DeselectGameObjectArgs> handler = DeselectEvent;
			if (handler != null) {
				handler (this, new DeselectGameObjectArgs ());
			}
		}

		public class SelectGameObjectArgs : EventArgs
		{
			public GameObject GameObject { get; set; }

			public SelectGameObjectArgs (GameObject game_object)
			{
				GameObject = game_object;
			}
		}

		public class SelectGameObjectsArgs : EventArgs
		{
			public GameObject[] GameObjects { get; set; }

			public SelectGameObjectsArgs (GameObject[] game_objects)
			{
				GameObjects = game_objects;
			}
		}

		public class DeselectGameObjectArgs : EventArgs {}
	}
}
