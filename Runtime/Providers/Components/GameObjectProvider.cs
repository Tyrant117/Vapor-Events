using System;
using UnityEngine;

namespace VaporEvents
{
    public class GameObjectProvider : ProviderData
    {
        private GameObject cached;
        private event Func<GameObject> OnRequestRaised;

        public void Subscribe(Func<GameObject> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe(Func<GameObject> listener)
        {
            OnRequestRaised -= listener;
        }

        public GameObject Request()
        {
            if (cached != null)
            {
                return cached;
            }
            else
            {
                cached = OnRequestRaised?.Invoke();
            }
            return cached;
        }
    }
}
