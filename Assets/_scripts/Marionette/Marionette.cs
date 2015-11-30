using UnityEngine;

namespace Marionette
{
    [RequireComponent(typeof(Locomotion))]
    public class Marionette : MonoBehaviour
    {
        Locomotion locomotion;

        private void Start()
        {
            locomotion = gameObject.GetComponent<Locomotion>();
        }

        void Update()
        {

        }
    }
}
