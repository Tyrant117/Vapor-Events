using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VaporEvents
{
    public class SingletonProvider<T> : SingletonProviderData<T> where T : MonoBehaviour
    {
        /// <summary>
        /// Supply the instance of the singleton that should be used. This method calls DontDestroyOnLoad on the gameobject.
        /// </summary>
        /// <remarks>Should be used when the singleton is in the scene and does not need to be instantiated.</remarks>
        /// <param name="instance"></param>
        public void Supply(T instance)
        {
            Instance = Instance;
            GameObject.DontDestroyOnLoad(instance.gameObject);
        }

        public T Request()
        {
            if (Instance != null)
            {
                return Instance;
            }
            else
            {
                var go = new GameObject($"[Singleton {typeof(T)}]");
                Instance = go.AddComponent<T>();
                GameObject.DontDestroyOnLoad(go);
            }
            return Instance;
        }
    }
}
