using System;
using UnityEngine;

namespace VaporEvents
{
    public class BehaviourProvider<T> : ProviderData where T : MonoBehaviour
    {
        private T cached;
        private event Func<T> OnRequestRaised;

        public void Subscribe(Func<T> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe(Func<T> listener)
        {
            OnRequestRaised -= listener;
        }

        public T Request()
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

    public class BehaviourProvider : ProviderData
    {
        private MonoBehaviour cached;
        private event Func<MonoBehaviour> OnRequestRaised;

        public void Subscribe(Func<MonoBehaviour> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe(Func<MonoBehaviour> listener)
        {
            OnRequestRaised -= listener;
        }

        public T Request<T>() where T : MonoBehaviour
        {
            if (cached != null)
            {
                return cached as T;
            }
            else
            {
                cached = OnRequestRaised?.Invoke();
            }
            return cached as T;
        }
    }
}
