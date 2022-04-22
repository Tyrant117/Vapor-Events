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
        // This uses the name of the scriptable object as the key.
        public int Key => name.GetHashCode();
        public string DisplayName => name;
        public string InternalID => name;
        public bool IsDeprecated => isDeprecated;

        public bool isDeprecated;

#if ODIN_INSPECTOR
        [Button]
#else
        [ContextMenu("Generate Keys")]
#endif
        private void GenerateKeys()
        {
#if UNITY_EDITOR
            if (!UnityEditor.AssetDatabase.IsValidFolder("Assets/Vapor Framework"))
            {
                UnityEditor.AssetDatabase.CreateFolder("Assets", "Vapor Framework");
                UnityEditor.AssetDatabase.Refresh(UnityEditor.ImportAssetOptions.ForceUpdate);
            }

            if (!UnityEditor.AssetDatabase.IsValidFolder("Assets/Vapor Framework/Vapor Event Keys"))
            {
                UnityEditor.AssetDatabase.CreateFolder("Assets/Vapor Framework", "Vapor Event Keys");
                UnityEditor.AssetDatabase.Refresh(UnityEditor.ImportAssetOptions.ForceUpdate);
            }

            KeyGenerator.GenerateKeys<ScriptableEventKey>(UnityEditor.AssetDatabase.FindAssets("t:ScriptableEventKey"), "Vapor Framework/Vapor Event Keys", "VaporEvents", "VaporEventKeys", true);
#endif
        }
    }
}
