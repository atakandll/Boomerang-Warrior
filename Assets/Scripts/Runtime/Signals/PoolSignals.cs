using System;
using Runtime.Enums.ObjectPooling;
using Runtime.Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class PoolSignals : MonoSingleton<PoolSignals>
    {
        public Func<PoolObjectType, GameObject> onGetObjectFromPool = delegate { return null; };
        public UnityAction<PoolObjectType, GameObject> onReleaseObjectFromPool = delegate { };
    }
}