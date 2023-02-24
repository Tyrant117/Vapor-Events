using System;
using UnityEngine;

namespace VaporEvents
{
    public class GameObjectProvider : IProviderData
    {
        private GameObject cached;
        private Func<GameObject> OnRequestRaised;

        public void Subscribe(Func<GameObject> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe()
        {
            OnRequestRaised = null;
        }

        public GameObject Request()
        {
            if (cached != null)
            {
                return cached;
            }
            else
            {
                Debug.Assert(OnRequestRaised != null, $"GameObjectProvider was requested before any events were subscribed.");
                cached = OnRequestRaised.Invoke();
            }
            return cached;
        }
    }
}
