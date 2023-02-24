using System;

namespace VaporEvents
{
    public class ShortProvider : IProviderData
    {
        private Func<short> OnRequestRaised;

        public void Subscribe(Func<short> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe()
        {
            OnRequestRaised = null;
        }

        public short Request(short defaultResult = 0)
        {
            return OnRequestRaised != null ? OnRequestRaised.Invoke() : defaultResult;
        }
    }
}
