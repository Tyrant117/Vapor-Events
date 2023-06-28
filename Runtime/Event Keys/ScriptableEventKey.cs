#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEngine;
using VaporKeys;

namespace VaporEvents
{
    [CreateAssetMenu(menuName = "Vapor/Events/Event Key")]
    public class ScriptableEventKey : ScriptableObject, IKey
    {
        [SerializeField]
        protected bool _isDeprecated;

        // This uses the name of the scriptable object as the key.

#if ODIN_INSPECTOR
        [ReadOnly]
#endif
        [SerializeField]
        private int _key;
        public int Key => _key;
        public void ForceRefreshKey() { _key = name.GetHashCode(); }
        public string DisplayName => name;
        public string InternalID => name;
        public bool IsDeprecated => _isDeprecated;        

#if ODIN_INSPECTOR
        [Button]
#endif
        [ContextMenu("Generate Keys")]
        private void GenerateKeys()
        {
#if UNITY_EDITOR
            if (!UnityEditor.AssetDatabase.IsValidFolder("Assets/Vapor Framework"))
            {
                UnityEditor.AssetDatabase.CreateFolder("Assets", "Vapor Framework");
                UnityEditor.AssetDatabase.Refresh();
            }

            if (!UnityEditor.AssetDatabase.IsValidFolder("Assets/Vapor Framework/Vapor Event Keys"))
            {
                UnityEditor.AssetDatabase.CreateFolder("Assets/Vapor Framework", "Vapor Event Keys");
                UnityEditor.AssetDatabase.Refresh();
            }

            KeyGenerator.GenerateKeys<ScriptableEventKey>("Vapor Framework/Vapor Event Keys", "VaporEvents", "VaporEventKeys", false);
#endif
        }
    }
}
