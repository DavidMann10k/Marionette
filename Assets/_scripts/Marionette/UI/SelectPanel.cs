using UnityEngine;
using UnityEngine.UI;
using System;

namespace Marionette.UI
{
	public class SelectPanel : MonoBehaviour
	{
		public Text selectedText;

		Select select;

		void Start ()
		{
			select = FindObjectOfType<Select> ();
			select.SelectEvent += OnSelect;
			select.DeselectEvent += OnDeselect;
			gameObject.SetActive (false);
		}

		void OnDestroy ()
		{
			select.SelectEvent -= OnSelect;
			select.DeselectEvent -= OnDeselect;
		}

		void OnSelect (object sender, Select.SelectGameObjectArgs e)
		{
			gameObject.SetActive (true);
			selectedText.text = e.GameObject.name;
		}

		void OnDeselect(object sender, Select.DeselectGameObjectArgs e)
		{
			gameObject.SetActive (false);
		}
	}
}