using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VaporEvents
{
    public class SingletonProvider<T> : SingletonProviderData<T> where T : MonoBehaviour
    {
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
