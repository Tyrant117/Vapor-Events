using System;
using UnityEngine;

namespace VaporEvents
{
    public class QuaterionProvider : ProviderData
    {
        private event Func<Quaternion> OnRequestRaised;

        public void Subscribe(Func<Quaternion> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe(Func<Quaternion> listener)
        {
            OnRequestRaised -= listener;
        }

        public Quaternion Request(Quaternion defaultResult = default)
        {
            return OnRequestRaised != null ? OnRequestRaised.Invoke() : defaultResult;
        }
    }
}
