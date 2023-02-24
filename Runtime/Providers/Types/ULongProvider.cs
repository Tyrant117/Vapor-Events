using System;

namespace VaporEvents
{
    public class ULongProvider : IProviderData
    {
        private Func<ulong> OnRequestRaised;

        public void Subscribe(Func<ulong> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe()
        {
            OnRequestRaised = null;
        }

        public ulong Request(ulong defaultResult = 0)
        {
            return OnRequestRaised != null ? OnRequestRaised.Invoke() : defaultResult;
        }
    }
}
