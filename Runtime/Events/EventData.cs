
using System;

namespace VaporEvents
{
    public interface IEventSender
    {
    }

    public interface IEventData
    {
    }

    public class EmptyEvent : IEventData
    {
        public event Action<IEventSender> OnEventRaised;

        public void Subscribe(Action<IEventSender> listener)
        {
            OnEventRaised += listener;
        }

        public void Unsubscribe(Action<IEventSender> listener)
        {
            OnEventRaised -= listener;
        }

        public void RaiseEvent(IEventSender sender)
        {
            OnEventRaised?.Invoke(sender);
        }
    }

    public class EventData<T1> : IEventData
    {
        public event Action<IEventSender, T1> OnEventRaised;

        public void Subscribe(Action<IEventSender, T1> listener)
        {
            OnEventRaised += listener;
        }

        public void Unsubscribe(Action<IEventSender, T1> listener)
        {
            OnEventRaised -= listener;
        }

        public void RaiseEvent(IEventSender sender, T1 value)
        {
            OnEventRaised?.Invoke(sender, value);
        }
    }

    public class EventData<T1, T2> : IEventData
    {
        public event Action<IEventSender, T1, T2> OnEventRaised;

        public void Subscribe(Action<IEventSender, T1, T2> listener)
        {
            OnEventRaised += listener;
        }

        public void Unsubscribe(Action<IEventSender, T1, T2> listener)
        {
            OnEventRaised -= listener;
        }

        public void RaiseEvent(IEventSender sender, T1 value1, T2 value2)
        {
            OnEventRaised?.Invoke(sender, value1, value2);
        }
    }

    public class EventData<T1, T2, T3> : IEventData
    {
        public event Action<IEventSender, T1, T2, T3> OnEventRaised;

        public void Subscribe(Action<IEventSender, T1, T2, T3> listener)
        {
            OnEventRaised += listener;
        }

        public void Unsubscribe(Action<IEventSender, T1, T2, T3> listener)
        {
            OnEventRaised -= listener;
        }

        public void RaiseEvent(IEventSender sender, T1 value1, T2 value2, T3 value3)
        {
            OnEventRaised?.Invoke(sender, value1, value2, value3);
        }
    }

    public class EventData<T1, T2, T3, T4> : IEventData
    {
        public event Action<IEventSender, T1, T2, T3, T4> OnEventRaised;

        public void Subscribe(Action<IEventSender, T1, T2, T3, T4> listener)
        {
            OnEventRaised += listener;
        }

        public void Unsubscribe(Action<IEventSender, T1, T2, T3, T4> listener)
        {
            OnEventRaised -= listener;
        }

        public void RaiseEvent(IEventSender sender, T1 value1, T2 value2, T3 value3, T4 value4)
        {
            OnEventRaised?.Invoke(sender, value1, value2, value3, value4);
        }
    }
}
