using UnityEngine;
using UnityEngine.UI;

public class DebugPanel : MonoBehaviour {

    [SerializeField]
    private Text selectedText;

	private void Update ()
    {
        if (Selectable.Selected == null)
        {
            selectedText.text = "Selected: None";
        }
        else
        {
            selectedText.text = "Selected: " + Selectable.Selected.name;
        }
	}
}
