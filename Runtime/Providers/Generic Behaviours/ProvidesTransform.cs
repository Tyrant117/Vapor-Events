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
        [SerializeField]
        private string providerName;
        [SerializeField]
        private ScriptableEventKey optionalKey;

        private string InternalName => optionalKey != null ? optionalKey.name : providerName;

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
