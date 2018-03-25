using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Marionette
{
    // adds ability to store InventoryItems
    public class Inventory : MonoBehaviour
    {
        [SerializeField]
        List<InventoryItem> items = new List<InventoryItem>();

        public int ItemCount { get { return items.Count(); } }

        public IEnumerable<InventoryItem> Items { get { return items; } }

        public void Store(InventoryItem inventoryItem)
        {
            items.Add(inventoryItem);
        }

        public InventoryItem Unstore(InventoryItem item)
        {
            items.Remove(item);
            return item;
        }

        public InventoryItem UnStore(string name)
        {
            return Unstore(items.FirstOrDefault(i => i.ItemName == name));
        }

        public InventoryItem UnStore()
        {
            return Unstore(items.FirstOrDefault());
        }
    }
}