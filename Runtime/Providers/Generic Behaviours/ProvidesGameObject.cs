#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VaporEvents
{
    public class ProvidesGameObject : MonoBehaviour
    {
#if ODIN_INSPECTOR
        [HideIf("@optionalKey != null")]
#endif
        [SerializeField]
        private string providerName;
        [SerializeField]
        private EventKeySO optionalKey;

        private string InternalName => optionalKey != null ? optionalKey.name : providerName;

        private void OnEnable()
        {
            ProviderBus.Get<GameObjectProvider>(InternalName).Subscribe(OnGameObjectRequested);
        }

        private void OnDisable()
        {
            ProviderBus.Get<GameObjectProvider>(InternalName).Unsubscribe();
        }

        private GameObject OnGameObjectRequested()
        {
            return gameObject;
        }
    }
}
