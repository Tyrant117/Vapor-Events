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
        private ScriptableEventKey optionalKey;

        private string InternalName => optionalKey != null ? optionalKey.name : providerName;

        private void OnEnable()
        {
            ProviderBus.Get<GameObjectProvider>(InternalName).Subscribe(OnGameObjectRequested);
        }

        private void OnDisable()
        {
            ProviderBus.Get<GameObjectProvider>(InternalName).Unsubscribe(OnGameObjectRequested);
        }

        private GameObject OnGameObjectRequested()
        {
            return gameObject;
        }
    }
}
