
using System;

namespace VaporEvents
{
    public interface IEventData
    {
    }

    public interface IEventSender
    {

    }

    public class EventData<T> : IEventData
    {
        public event Action<IEventSender, T> OnEventRaised;

        public void Subscribe(Action<IEventSender, T> listener)
        {
            OnEventRaised += listener;
        }

        public void Unsubscribe(Action<IEventSender, T> listener)
        {
            OnEventRaised -= listener;
        }

        public void RaiseEvent(IEventSender sender, T value)
        {
            OnEventRaised?.Invoke(sender, value);
        }
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
}
