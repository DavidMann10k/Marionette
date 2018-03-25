using UnityEngine;
using System;
using System.Collections;

namespace Marionette
{
    public class Living : MonoBehaviour, IDies
    {
        [SerializeField]
        int initialLife = 1;

        [SerializeField]
        GameObject deathparticle = null;

        Observable<int> life;

        public event EventHandler<DeathArgs> DeathEvent;

        public Observable<int> Life {
            get { return life; }
        }

        public void OnDamage(int damage)
        {
            life.Value -= damage;
            if (life.Value <= 0) {
                foreach (IDies component in gameObject.GetComponents<IDies>()) {
                    component.OnDeath();
                }
            }
        }

        public void OnDeath()
        {
            Instantiate(deathparticle, transform.position, Quaternion.identity);
            gameObject.AddComponent<Dead>();
            RaiseDeathEvent();
            Destroy(this);
        }

        void RaiseDeathEvent()
        {
            EventHandler<DeathArgs> handler = DeathEvent;
            if (handler != null) {
                handler(this, new DeathArgs());
            }
        }

        void Awake()
        {
            life = new Observable<int>(initialLife);
        }

        public class DeathArgs : EventArgs
        {
        }
    }
}
