using Runtime.Extensions;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        public UnityAction onPlay = delegate { };
        public UnityAction onLevelInitialize = delegate { };
        public UnityAction onFail = delegate { };
        public UnityAction onReset = delegate { };
    }
}