#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEngine;

namespace VaporEvents
{
    public class ProvidesTransform : MonoBehaviour
    {
#if ODIN_INSPECTOR
        [HideIf("@optionalKey != null")]
#endif
        [SerializeField, Tooltip("The string name of the provider")]
        private string _providerName;
        [SerializeField, Tooltip("The optional key to use instead of a provider name, useful for no magic string.")]
        private EventKeySO _optionalKey;

        public string ProviderName { get => _providerName; set => _providerName = value; }
        public EventKeySO OptionalKey { get => _optionalKey; set => _optionalKey = value; }
        

        private string InternalName => _optionalKey != null ? _optionalKey.name : _providerName;

        private void OnEnable()
        {
            ProviderBus.Get<TransformProvider>(InternalName).Subscribe(OnTransformRequested);
        }

        private void OnDisable()
        {
            ProviderBus.Get<TransformProvider>(InternalName).Unsubscribe();
        }

        private Transform OnTransformRequested()
        {
            return transform;
        }
    }
}
