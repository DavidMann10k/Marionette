using System.Collections;
using UnityEditor;

namespace Marionette
{
	[CustomEditor (typeof(Inventory))]
	public class InventoryInspector : Editor
	{
		bool show_items = false;

		public override void OnInspectorGUI ()
		{
			Inventory inventory = target as Inventory;

			if (show_items = EditorGUILayout.Foldout (show_items, "Items")) {
				EditorGUI.indentLevel = 1;
				foreach (InventoryItem ii in inventory.Items) {
					EditorGUILayout.LabelField (ii.ItemName);
				}
			}
		}
	}
}
