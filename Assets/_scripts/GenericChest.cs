﻿using UnityEngine;
using Marionette;

// drag this onto a game object to make it behave as a chest with gold!
[RequireComponent (typeof(Inventory))]
public class GenericChest : MonoBehaviour
{
	Inventory inventory;

	void Awake ()
	{
		inventory = GetComponent<Inventory> ();

		for (int i = 0; i < 5; i++) {
			inventory.Store (new InventoryItem ("Gold"));
			inventory.Store (new InventoryItem ("Sword"));
		}
	}
}
