using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VaporEvents
{
    public class GenericTypeProvider<T> : IProviderData
    {
        private Func<T> OnRequestRaised;

        public void Subscribe(Func<T> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe()
        {
            OnRequestRaised = null;
        }

        public bool TryRequest(out T result)
        {
            if (OnRequestRaised != null)
            {
                result = OnRequestRaised.Invoke();
                return true;
            }
            else
            {
                result = default;
                return false;
            }
        }
    }
}
