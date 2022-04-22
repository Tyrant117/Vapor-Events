using System;

namespace VaporEvents
{
    public class ULongProvider : ProviderData
    {
        private event Func<ulong> OnRequestRaised;

        public void Subscribe(Func<ulong> listener)
        {
            OnRequestRaised += listener;
        }

        public void Unsubscribe(Func<ulong> listener)
        {
            OnRequestRaised -= listener;
        }

        public ulong Request(ulong defaultResult = 0)
        {
            return OnRequestRaised != null ? OnRequestRaised.Invoke() : defaultResult;
        }
    }
}
