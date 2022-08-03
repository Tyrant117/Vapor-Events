using System;

namespace VaporEvents
{
    public class IntEvent : EventData
    {
        public event Action<int> OnEventRaised;

        public void Subscribe(Action<int> listener)
        {
            OnEventRaised += listener;
        }

        public void Unsubscribe(Action<int> listener)
        {
            OnEventRaised -= listener;
        }

        public void RaiseEvent(int value)
        {
            OnEventRaised?.Invoke(value);
        }
    }
}
