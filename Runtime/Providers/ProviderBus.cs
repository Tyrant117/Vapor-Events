using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VaporEvents
{
    public static class ProviderBus
    {
        public static Dictionary<int, ProviderData> providerMap = new();

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
                Debug.Log($"[Provider Bus] Adding Provider: [{eventID}] of Type: {typeof(T)}");
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
                Debug.Log($"[Provider Bus] Adding Provider: [{eventName}] of Type: {typeof(T)}");
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
                Debug.Log($"[Provider Bus] Adding Provider: [{eventKey.name}] of Type: {typeof(T)}");
                providerMap.Add(eventID, Activator.CreateInstance<T>());
                return (T)providerMap[eventID];
            }
        }
    }
}
