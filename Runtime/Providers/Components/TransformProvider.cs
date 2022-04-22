using System;
using UnityEngine;

namespace VaporEvents
{
    public class TransformProvider : ProviderData
    {
        private Transform cached;
        private event Func<Transform> OnRequestRaised;

        public void Subscribe(Func<Transform> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe(Func<Transform> listener)
        {
            OnRequestRaised -= listener;
        }

        public Transform Request()
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
