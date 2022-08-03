using System;

namespace VaporEvents
{
    public class EmptyEvent : EventData
    {
        public event Action OnEventRaised;

        public void Subscribe(Action listener)
        {
            OnEventRaised += listener;
        }

        public void Unsubscribe(Action listener)
        {
            OnEventRaised -= listener;
        }

        public void RaiseEvent()
        {
            OnEventRaised?.Invoke();
        }
    }
}
