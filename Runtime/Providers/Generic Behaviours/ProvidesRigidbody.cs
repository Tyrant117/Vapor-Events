#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEngine;

namespace VaporEvents
{
    public class ProvidesRigidbody : MonoBehaviour
    {
#if ODIN_INSPECTOR
        [HideIf("@optionalKey != null")]
#endif
        [SerializeField, Tooltip("The string name of the provider")]
        private string _providerName;
        [SerializeField, Tooltip("The optional key to use instead of a provider name, useful for no magic string.")]
        private EventKeySO _optionalKey;
        [SerializeField, Tooltip("Rigidbody to provide.")]
        private Rigidbody _rigidbody;

        public string ProviderName { get => _providerName; set => _providerName = value; }
        public EventKeySO OptionalKey { get => _optionalKey; set => _optionalKey = value; }
        public Rigidbody Rigidbody { get => _rigidbody; set => _rigidbody = value; }



        private string InternalName => _optionalKey != null ? _optionalKey.name : _providerName;

        private void OnEnable()
        {
            ProviderBus.Get<RigidbodyProvider>(InternalName).Subscribe(OnRigidbodyRequested);
        }

        private void OnDisable()
        {
            ProviderBus.Get<RigidbodyProvider>(InternalName).Unsubscribe();
        }

        private Rigidbody OnRigidbodyRequested()
        {
            return _rigidbody;
        }
    }
}
