using System;
using System.Collections.Generic;
using UnityEngine;

namespace VaporEvents
{
    public static class EventBus
    {
        public static readonly Dictionary<int, IEventData> eventMap = new();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void Init()
        {
            eventMap.Clear();
        }

        /// <summary>
        /// Gets or creates an instance of the event at the supplied id. This id should typically be a auto-generated guid, but any string that isnt empty or null will work. <br />
        /// The event should always be cached or only used in loading and unloading.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static T Get<T>(int eventID) where T : IEventData
        {
            if (eventMap.TryGetValue(eventID, out var handler))
            {
                return (T)handler;
            }
            else
            {
#if VAPOR_EVENT_LOGGING
                Debug.Log($"[Event Bus] Adding Event: [{eventID}] of Type: {typeof(T)}");
#endif
                eventMap.Add(eventID, Activator.CreateInstance<T>());
                return (T)eventMap[eventID];
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
        public static T Get<T>(string eventName) where T : IEventData
        {
            int eventID = eventName.GetHashCode();
            if (eventMap.TryGetValue(eventID, out var handler))
            {
                return (T)handler;
            }
            else
            {
#if VAPOR_EVENT_LOGGING
                Debug.Log($"[Event Bus] Adding Event: [{eventName}] of Type: {typeof(T)}");
#endif
                eventMap.Add(eventID, Activator.CreateInstance<T>());
                return (T)eventMap[eventID];
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
        public static T Get<T>(ScriptableEventKey eventKey) where T : IEventData
        {
            int eventID = eventKey.Key;
            if (eventMap.TryGetValue(eventID, out var handler))
            {
                return (T)handler;
            }
            else
            {
#if VAPOR_EVENT_LOGGING
                Debug.Log($"[Event Bus] Adding Event: [{eventKey.DisplayName}] of Type: {typeof(T)}");
#endif
                eventMap.Add(eventID, Activator.CreateInstance<T>());
                return (T)eventMap[eventID];
            }
        }
    }
}
