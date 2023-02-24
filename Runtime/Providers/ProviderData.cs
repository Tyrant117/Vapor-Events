using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VaporEvents
{
    public interface IProviderData
    {

    }

    public class ProviderData<TResult> : IProviderData
    {
        private TResult cached;
        public event Func<TResult> OnRequestRaised;

        public void Subscribe(Func<TResult> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe(Func<TResult> listener)
        {
            OnRequestRaised -= listener;
        }

        public T Request<T>() where T : TResult
        {
            if (cached != null)
            {
                return (T)cached;
            }
            else
            {
                cached = OnRequestRaised.Invoke();
            }
            return (T)cached;
        }
    }

    public class ProviderData<T1, TResult> : IProviderData
    {
        private TResult cached;
        public event Func<T1, TResult> OnRequestRaised;

        public void Subscribe(Func<T1, TResult> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe(Func<T1, TResult> listener)
        {
            OnRequestRaised -= listener;
        }

        public T Request<T>(T1 value1) where T : TResult
        {
            if (cached != null)
            {
                return (T)cached;
            }
            else
            {
                cached = OnRequestRaised.Invoke(value1);
            }
            return (T)cached;
        }
    }

    public class ProviderData<T1, T2, TResult> : IProviderData
    {
        private TResult cached;
        public event Func<T1, T2, TResult> OnRequestRaised;

        public void Subscribe(Func<T1, T2, TResult> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe(Func<T1, T2, TResult> listener)
        {
            OnRequestRaised -= listener;
        }

        public T Request<T>(T1 value1, T2 value2) where T : TResult
        {
            if (cached != null)
            {
                return (T)cached;
            }
            else
            {
                cached = OnRequestRaised.Invoke(value1, value2);
            }
            return (T)cached;
        }
    }

    public class ProviderData<T1, T2, T3, TResult> : IProviderData
    {
        private TResult cached;
        public event Func<T1, T2, T3, TResult> OnRequestRaised;

        public void Subscribe(Func<T1, T2, T3, TResult> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe(Func<T1, T2, T3, TResult> listener)
        {
            OnRequestRaised -= listener;
        }

        public T Request<T>(T1 value1, T2 value2, T3 value3) where T : TResult
        {
            if (cached != null)
            {
                return (T)cached;
            }
            else
            {
                cached = OnRequestRaised.Invoke(value1, value2, value3);
            }
            return (T)cached;
        }
    }

    public class ProviderData<T1, T2, T3, T4, TResult> : IProviderData
    {
        private TResult cached;
        public event Func<T1, T2, T3, T4, TResult> OnRequestRaised;

        public void Subscribe(Func<T1, T2, T3, T4, TResult> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe(Func<T1, T2, T3, T4, TResult> listener)
        {
            OnRequestRaised -= listener;
        }

        public T Request<T>(T1 value1, T2 value2, T3 value3, T4 value4) where T : TResult
        {
            if (cached != null)
            {
                return (T)cached;
            }
            else
            {
                cached = OnRequestRaised.Invoke(value1, value2, value3, value4);
            }
            return (T)cached;
        }
    }

    public class SingletonProviderData<T> : IProviderData
    {
        public T Instance { get; protected set; }
    }
}
