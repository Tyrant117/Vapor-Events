using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VaporEvents
{
    public static class ProviderBus
    {
        public static readonly Dictionary<int, ProviderData> providerMap = new();

        /// <summary>
        /// Gets or creates an instance of the event at the supplied id. This id should typically be a auto-generated guid, but any integer will work. <br />
        /// The event should always be cached or only used in loading and unloading. <br />
        /// <b>String/Int collisions will not be detected!</b>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static T Get<T>(int eventID) where T : ProviderData
        {
            if (providerMap.TryGetValue(eventID, out var handler))
            {
                return (T)handler;
            }
            else
            {
#if VAPOR_EVENT_LOGGING
                Debug.Log($"[Provider Bus] Adding Provider: [{eventID}] of Type: {typeof(T)}");
#endif
                providerMap.Add(eventID, Activator.CreateInstance<T>());
                return (T)providerMap[eventID];
            }
        }

        /// <summary>
        /// Gets or creates an instance of the event at the supplied id. This id should typically be a auto-generated guid, but any string that isnt empty or null will work. <br />
        /// The event should always be cached or only used in loading and unloading. <br />
        /// <b>String/Int collisions will not be detected!</b>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static T Get<T>(string eventName) where T : ProviderData
        {
            int eventID = eventName.GetHashCode();
            if (providerMap.TryGetValue(eventID, out var handler))
            {
                return (T)handler;
            }
            else
            {
#if VAPOR_EVENT_LOGGING
                Debug.Log($"[Provider Bus] Adding Provider: [{eventName}] of Type: {typeof(T)}");
#endif
                providerMap.Add(eventID, Activator.CreateInstance<T>());
                return (T)providerMap[eventID];
            }
        }

        /// <summary>
        /// Gets or creates an instance of the event at the supplied id. This id should typically be a auto-generated guid, but any string that isnt empty or null will work. <br />
        /// The event should always be cached or only used in loading and unloading. <br />
        /// <b>String/Int collisions will not be detected!</b>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static T Get<T>(ScriptableEventKey eventKey) where T : ProviderData
        {
            int eventID = eventKey.name.GetHashCode();
            if (providerMap.TryGetValue(eventID, out var handler))
            {
                return (T)handler;
            }
            else
            {
#if VAPOR_EVENT_LOGGING
                Debug.Log($"[Provider Bus] Adding Provider: [{eventKey.name}] of Type: {typeof(T)}");
#endif
                providerMap.Add(eventID, Activator.CreateInstance<T>());
                return (T)providerMap[eventID];
            }
        }


        /// <summary>
        /// Gets or creates an instance of the event at the supplied id. This id should typically be a auto-generated guid, but any integer work. <br />
        /// The request will create a or find the cached monobehaviour, the lifecycle will last the entire application runtime unless manually destroyed. <br />
        /// This is a pseudo singleton, not a true singleton. It won't stop the collision of other monobehaviours of the same type, but if accessed only through this method will always used the cached one. <br />
        /// <b>String/Int collisions will not be detected!</b>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static T GetSingleton<T, U>(int eventID) where T : SingletonProvider<U> where U : MonoBehaviour
        {
            if (providerMap.TryGetValue(eventID, out var handler))
            {
                return (T)handler;
            }
            else
            {
#if VAPOR_EVENT_LOGGING
                Debug.Log($"[Provider Bus] Adding Singleton Provider: [{eventID}] of Type: {typeof(T)}");
#endif
                providerMap.Add(eventID, Activator.CreateInstance<SingletonProvider<U>>());
                return (T)providerMap[eventID];
            }
        }

        public static T GetSingleton<T, U>(string eventName) where T : SingletonProvider<U> where U : MonoBehaviour
        {
            return GetSingleton<T, U>(eventName.GetHashCode());
        }

        public static T GetSingleton<T, U>(ScriptableEventKey eventKey) where T : SingletonProvider<U> where U : MonoBehaviour
        {
            return GetSingleton<T, U>(eventKey.name.GetHashCode());
        }
    }
}
