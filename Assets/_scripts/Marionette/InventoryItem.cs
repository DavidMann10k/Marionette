namespace Marionette
{
	public class InventoryItem
	{
		public string ItemName { get { return item_name; } }

		string item_name;

		public InventoryItem (string item_name)
		{
			this.item_name = item_name;
		}
	}
}

