using System;
using UnityEngine;

namespace VaporEvents
{
    public class BooleanProvider : ProviderData
    {
        private Func<bool> OnRequestRaised;

        public void Subscribe(Func<bool> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe()
        {
            OnRequestRaised = null;
        }

        public bool Request()
        {
            Debug.Assert(OnRequestRaised != null, "BooleanProvider was requested before any events were subscribed.");
            return OnRequestRaised.Invoke();
        }
    }
}
