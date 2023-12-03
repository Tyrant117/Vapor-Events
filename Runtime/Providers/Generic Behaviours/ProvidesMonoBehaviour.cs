#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEngine;

namespace VaporEvents
{
    public class ProvidesMonoBehaviour : MonoBehaviour
    {
#if ODIN_INSPECTOR
        [HideIf("@optionalKey != null")]
#endif
        [SerializeField]
        private string providerName;
        [SerializeField]
        private EventKeySO optionalKey;
        [SerializeField]
        private MonoBehaviour behaviour;

        private string InternalName => optionalKey != null ? optionalKey.name : providerName;

        private void OnEnable()
        {
            ProviderBus.Get<BehaviourProvider>(InternalName).Subscribe(OnBehaviourRequested);
        }

        private void OnDisable()
        {
            ProviderBus.Get<BehaviourProvider>(InternalName).Unsubscribe();
        }

        private MonoBehaviour OnBehaviourRequested()
        {
            return behaviour;
        }
    }
}
