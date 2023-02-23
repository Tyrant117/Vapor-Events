using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VaporEvents
{
    public class ProvidedMonoBehaviour : MonoBehaviour
    {
        [SerializeField]
        protected string overrideName = "";

        protected virtual string InternalName => overrideName.Length > 0 ? overrideName : gameObject.name;

        protected virtual void OnEnable()
        {
            ProviderBus.Get<BehaviourProvider>(InternalName).Subscribe(OnBehaviourRequested);
        }

        protected virtual void OnDisable()
        {
            ProviderBus.Get<BehaviourProvider>(InternalName).Unsubscribe();
        }

        private MonoBehaviour OnBehaviourRequested()
        {
            return this;
        }

        public virtual int GetKey()
        {
            return InternalName.GetHashCode();
        }
    }
}
