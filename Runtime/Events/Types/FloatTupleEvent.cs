using System;

namespace VaporEvents
{
    public class FloatTupleEvent : EventData
    {
        public event Action<float, float> OnEventRaised;

        public void Subscribe(Action<float, float> listener)
        {
            OnEventRaised += listener;
        }

        public void Unsubscribe(Action<float, float> listener)
        {
            OnEventRaised -= listener;
        }

        public void RaiseEvent(float value1, float value2)
        {
            OnEventRaised?.Invoke(value1, value2);
        }
    }
}
