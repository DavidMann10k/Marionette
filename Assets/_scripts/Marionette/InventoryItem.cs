using System;

namespace Marionette
{
	public class InventoryItem
	{
		public string PrefabName { get; set; }

		public InventoryItem (Inventoriable inventoriable)
		{
			this.PrefabName = inventoriable.PrefabName;
		}
	}
}

