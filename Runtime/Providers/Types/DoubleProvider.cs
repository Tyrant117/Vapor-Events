using System;
using UnityEngine;

namespace VaporEvents
{
    public class DoubleProvider : ProviderData
    {
        private Func<double> OnRequestRaised;

        public void Subscribe(Func<double> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe()
        {
            OnRequestRaised = null;
        }

        public double Request()
        {
            Debug.Assert(OnRequestRaised != null, "DoubleProvider was requested before any events were subscribed.");
            return OnRequestRaised.Invoke();
        }
    }
}
