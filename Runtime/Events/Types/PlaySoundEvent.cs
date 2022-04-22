using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VaporEvents
{
    public class PlaySoundEvent : EventData
    {
        public event Action<AudioClip, Vector3> OnEventRaised;

        public void Subscribe(Action<AudioClip, Vector3> listener)
        {
            OnEventRaised += listener;
        }

        public void Unsubscribe(Action<AudioClip, Vector3> listener)
        {
            OnEventRaised -= listener;
        }

        public void RaiseEvent(AudioClip clip, Vector3 worldPos)
        {
            OnEventRaised?.Invoke(clip, worldPos);
        }
    }
}
