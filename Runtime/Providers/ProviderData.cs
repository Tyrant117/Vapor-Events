using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VaporEvents
{
    public class ProviderData
    {

    }

    public class SingletonProviderData<T> : ProviderData
    {
        public T Instance { get; set; }
    }
}
