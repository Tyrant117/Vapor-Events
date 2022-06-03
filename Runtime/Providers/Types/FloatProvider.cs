using System;

namespace VaporEvents
{
    public class FloatProvider : ProviderData
    {
        private Func<float> OnRequestRaised;

        public void Subscribe(Func<float> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe()
        {
            OnRequestRaised = null;
        }

        public float Request(float defaultResult = 0)
        {
            return OnRequestRaised != null ? OnRequestRaised.Invoke() : defaultResult;
        }
    }
}
