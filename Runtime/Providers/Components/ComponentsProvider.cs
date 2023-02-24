using System;
using System.Collections.Generic;
using UnityEngine;

namespace VaporEvents
{
    public class ComponentsProvider : IProviderData
    {
        private List<Component> cached;
        private Func<List<Component>> OnRequestRaised;

        public void Subscribe(Func<List<Component>> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe()
        {
            OnRequestRaised = null;
        }

        public List<Component> Request()
        {
            if (cached != null)
            {
                return cached;
            }
            else
            {
                Debug.Assert(OnRequestRaised != null, $"ComponentsProvider was requested before any events were subscribed.");
                cached = OnRequestRaised.Invoke();
            }
            return cached;
        } 

        public T Find<T>() where T : Component
        {
            if (cached == null)
            {
                Debug.Assert(OnRequestRaised != null, $"ComponentsProvider was requested before any events were subscribed.");
                cached = OnRequestRaised.Invoke();
            }

            return cached.Find(_ => _.GetType() == typeof(T)) as T;
        }
    }
}
