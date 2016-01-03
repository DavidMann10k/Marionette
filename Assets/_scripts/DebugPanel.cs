using UnityEngine;
using UnityEngine.UI;
using System;

public class DebugPanel : MonoBehaviour
{
	public Text selectedText;

	void Start ()
	{
		Selectable.SelectgGameObject += new EventHandler<SelectGameObjectArgs> (updateText);
	}

	void updateText (object sender, SelectGameObjectArgs e)
	{
		if (String.IsNullOrEmpty (e.GameObject.name)) {
			selectedText.text = "Selected: None";
		} else {
			selectedText.text = "Selected: " + e.GameObject.name;
		}
	}
}
