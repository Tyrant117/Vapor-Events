using System;

namespace VaporEvents
{
    public class DoubleProvider : ProviderData
    {
        private event Func<double> OnRequestRaised;

        public void Subscribe(Func<double> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe(Func<double> listener)
        {
            OnRequestRaised -= listener;
        }

        public double Request(double defaultResult = 0)
        {
            return OnRequestRaised != null ? OnRequestRaised.Invoke() : defaultResult;
        }
    }
}
