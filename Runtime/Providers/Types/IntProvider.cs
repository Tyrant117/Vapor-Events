using System;

namespace VaporEvents
{
    public class IntProvider : ProviderData
    {
        private event Func<int> OnRequestRaised;

        public void Subscribe(Func<int> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe(Func<int> listener)
        {
            OnRequestRaised -= listener;
        }

        public int Request(int defaultResult = 0)
        {
            return OnRequestRaised != null ? OnRequestRaised.Invoke() : defaultResult;
        }
    }
}
