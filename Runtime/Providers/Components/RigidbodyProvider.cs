using System;
using UnityEngine;

namespace VaporEvents
{
    public class RigidbodyProvider : IProviderData
    {
        private Rigidbody cached;
        private Func<Rigidbody> OnRequestRaised;

        public void Subscribe(Func<Rigidbody> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe()
        {
            OnRequestRaised = null;
        }

        public Rigidbody Request()
        {
            if (cached != null)
            {
                return cached;
            }
            else
            {
                Debug.Assert(OnRequestRaised != null, $"RigidbodyProvider was requested before any events were subscribed.");
                cached = OnRequestRaised.Invoke();
            }
            return cached;
        }
    }
}
