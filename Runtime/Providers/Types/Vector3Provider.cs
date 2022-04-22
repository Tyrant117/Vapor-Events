using System;
using UnityEngine;

namespace VaporEvents
{
    public class Vector3Provider : ProviderData
    {
        private event Func<Vector3> OnRequestRaised;

        public void Subscribe(Func<Vector3> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe(Func<Vector3> listener)
        {
            OnRequestRaised -= listener;
        }

        public Vector3 Request(Vector3 defaultResult = default)
        {
            return OnRequestRaised != null ? OnRequestRaised.Invoke() : defaultResult;
        }
    }
}
