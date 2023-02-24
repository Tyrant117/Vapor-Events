using System;
using System.Collections.Generic;
using UnityEngine;

namespace VaporEvents
{
    public class StringProvider : IProviderData
    {
        private Func<string> OnRequestRaised;

        public void Subscribe(Func<string> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe()
        {
            OnRequestRaised = null;
        }

        public string Request(string defaultResult = "")
        {
            return OnRequestRaised != null ? OnRequestRaised.Invoke() : defaultResult;
        }
    }
}
