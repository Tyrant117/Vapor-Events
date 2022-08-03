using System;

namespace VaporEvents
{
    public class BoolEvent : EventData
    {
        public event Action<bool> OnEventRaised;

        public void Subscribe(Action<bool> listener)
        {
            OnEventRaised += listener;
        }

        public void Unsubscribe(Action<bool> listener)
        {
            OnEventRaised -= listener;
        }

        public void RaiseEvent(bool value)
        {
            OnEventRaised?.Invoke(value);
        }
    }
}
