#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using System.Collections.Generic;
using UnityEngine;

namespace VaporEvents
{
    public class ProvidesComponents : MonoBehaviour
    {
#if ODIN_INSPECTOR
        [HideIf("@optionalKey != null")]
#endif
        [SerializeField]
        private string providerName;
        [SerializeField]
        private ScriptableEventKey optionalKey;
        [SerializeField]
        private List<Component> components;

        private string InternalName => optionalKey != null ? optionalKey.name : providerName;

        private void OnEnable()
        {
            ProviderBus.Get<ComponentsProvider>(InternalName).Subscribe(OnComponentsRequested);
        }

        private void OnDisable()
        {
            ProviderBus.Get<ComponentsProvider>(InternalName).Unsubscribe();
        }

        private List<Component> OnComponentsRequested()
        {
            return components;
        }
    }
}
