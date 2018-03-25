using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Marionette
{
    // Makes a GameObject respond to being selected by Select
    // Manages a selected object and a collection of selected objects
    // Controls outline by registering with GlowController
    public class Selectable : MonoBehaviour, IGlow
    {
        // TODO: determine if there's a better way to do this. Maybe a stack.
        static Selectable selected_object = null;
        static List<Selectable> selected_objects = new List<Selectable>();

        [SerializeField]
        Color glow_color = Color.green;

        public static List<Selectable> SelectedObjects {
            get { return selected_objects; }
        }

        public static Selectable SelectedObject {
            get { return selected_object; }
        }

        public Renderer[] Renderers { get; private set; }

        public Color GlowColor { get { return glow_color; } }

        public static void DeselectAll()
        {
            selected_object = null;
            selected_objects.ForEach(i => i.Deselect());
        }

        public void Select()
        {
            selected_object = this;
            selected_objects.Add(this);
            GlowController.RegisterObject(this);
        }

        public void Deselect()
        {
            SelectedObjects.Remove(this);
            GlowController.DeregisterObject(this);
        }

        void Awake()
        {
            Renderers = GetComponentsInChildren<Renderer>();
            if (GetComponent<Collider>() == null) {
                Debug.LogError("Selectable requires a collider to function");
            }
        }
    }
}