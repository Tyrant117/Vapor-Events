using UnityEngine;
using VaporKeys;

namespace VaporEvents
{
    [CreateAssetMenu(menuName = "Vapor/Events/Event Key")]
    public class EventKeySO : KeySO
    {
        public override string DisplayName => name;
    }
}
