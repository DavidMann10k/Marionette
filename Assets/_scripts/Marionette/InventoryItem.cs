﻿using UnityEngine;
using System;

namespace Marionette
{
    [Serializable]
    public struct InventoryItem
    {
        [SerializeField]
        string item_name;

        public InventoryItem(string item_name)
        {
            this.item_name = item_name;
        }

        public string ItemName { get { return item_name; } }
    }
}
