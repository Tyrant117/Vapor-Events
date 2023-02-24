using System;
using UnityEngine;

namespace VaporEvents
{
    public class BehaviourProvider<T> : IProviderData where T : MonoBehaviour
    {
        private T cached;
        private Func<T> OnRequestRaised;

        public void Subscribe(Func<T> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe()
        {
            OnRequestRaised = null;
        }

        public T Request()
        {
            if (cached != null)
            {
                return cached;
            }
            else
            {
                Debug.Assert(OnRequestRaised != null, $"BehaviourProvider<{typeof(T)}> was requested before any events were subscribed.");
                cached = OnRequestRaised.Invoke();
            }
            return cached;
        }
    }

    public class BehaviourProvider : IProviderData
    {
        private MonoBehaviour cached;
        private Func<MonoBehaviour> OnRequestRaised;

        public void Subscribe(Func<MonoBehaviour> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe()
        {
            OnRequestRaised = null;
        }

        public T Request<T>() where T : MonoBehaviour
        {
            if (cached != null)
            {
                return cached as T;
            }
            else
            {
                Debug.Assert(OnRequestRaised != null, $"BehaviourProvider with {typeof(T)} was requested before any events were subscribed.");
                cached = OnRequestRaised.Invoke();
            }
            return cached as T;
        }
    }
}
