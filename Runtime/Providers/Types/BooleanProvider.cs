using System;

namespace VaporEvents
{
    public class BooleanProvider : ProviderData
    {
        private event Func<bool> OnRequestRaised;

        public void Subscribe(Func<bool> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe(Func<bool> listener)
        {
            OnRequestRaised -= listener;
        }

        public bool Request()
        {
            return OnRequestRaised != null && OnRequestRaised.Invoke();
        }
    }
}
