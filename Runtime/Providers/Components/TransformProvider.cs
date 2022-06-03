using System;
using UnityEngine;

namespace VaporEvents
{
    public class TransformProvider : ProviderData
    {
        private Transform cached;
        private Func<Transform> OnRequestRaised;

        public void Subscribe(Func<Transform> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe()
        {
            OnRequestRaised = null;
        }

        public Transform Request()
        {
            if (cached != null)
            {
                return cached;
            }
            else
            {
                Debug.Assert(OnRequestRaised != null, $"TransformProvider was requested before any events were subscribed.");
                cached = OnRequestRaised.Invoke();
            }
            return cached;
        }
    }
}
