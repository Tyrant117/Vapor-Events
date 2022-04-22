using System;

namespace VaporEvents
{
    public class ShortProvider : ProviderData
    {
        private event Func<short> OnRequestRaised;

        public void Subscribe(Func<short> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe(Func<short> listener)
        {
            OnRequestRaised -= listener;
        }

        public short Request(short defaultResult = 0)
        {
            return OnRequestRaised != null ? OnRequestRaised.Invoke() : defaultResult;
        }
    }
}
