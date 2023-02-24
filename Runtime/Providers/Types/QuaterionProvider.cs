using System;
using UnityEngine;

namespace VaporEvents
{
    public class QuaterionProvider : IProviderData
    {
        private Func<Quaternion> OnRequestRaised;

        public void Subscribe(Func<Quaternion> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe()
        {
            OnRequestRaised = null;
        }

        public Quaternion Request(Quaternion defaultResult = default)
        {
            return OnRequestRaised != null ? OnRequestRaised.Invoke() : defaultResult;
        }
    }
}
