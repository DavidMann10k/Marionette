using System;
using UnityEngine;

namespace Marionette
{
    // Picks and sets inventoriable things in the scene
    [RequireComponent(typeof(Inventory))]
    public class TestInventory : MonoBehaviour
    {
        Inventory inventory;
        Click click;

        void Start()
        {
            inventory = GetComponent<Inventory>();
            click = FindObjectOfType<Click>();
            click.ClickEvent += OnClick;
        }

        void OnClick(object sender, Click.ClickArgs args)
        {
            inventory.Store(args.GameObject.GetComponent<Inventory>().UnStore());
        }

        void OnDestroy()
        {
            click.ClickEvent -= OnClick;
        }
    }
}
