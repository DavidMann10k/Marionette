using System;
using UnityEngine;
using System.Collections.Generic;

namespace Marionette
{
    // Adds collecting behavior to an AI agent
    [RequireComponent(typeof(Marionette))]
    public class Collects : MonoBehaviour, IBehavior
    {
        [SerializeField]
        List<string> item_names;

        public void ConcludeDirective(IDirective directive)
        {
            throw new NotImplementedException();
        }

        public void OnDeath()
        {
            this.enabled = false;
        }

        void Start()
        {
            // if there are nearby objects of interest
            //   if objects of interest are withing range
            //     create store directive
            //   else
            //     create move directive
            //   else
            //     do nothing
        }
    }
}
