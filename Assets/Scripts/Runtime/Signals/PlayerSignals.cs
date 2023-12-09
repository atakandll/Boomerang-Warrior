using System;
using Runtime.Extensions;
using UnityEngine;

namespace Runtime.Signals
{
    public class PlayerSignals : MonoSingleton<PlayerSignals>
    {
        public Func<Transform> onGetPlayerTransform = delegate { return null; };
    }
}