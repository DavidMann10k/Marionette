using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

namespace Marionette.UI
{
	public class SceneSelectPanel : MonoBehaviour
	{
		public string[] SceneNames;

		public Button ButtonPrefab;

		public void ToggleEnabled ()
		{
			gameObject.SetActive (!gameObject.activeSelf);
		}

		void Start ()
		{
			foreach (string scene_name in SceneNames) {
				var button = Instantiate (ButtonPrefab);
				button.transform.SetParent (gameObject.transform);
				button.GetComponentInChildren<Text> ().text = scene_name;
				AddHandler (button, scene_name);
			}
		}

		void AddHandler (Button button, string scene_name)
		{
			button.onClick.AddListener (() => SceneManager.LoadScene (scene_name));
		}
	}
}
