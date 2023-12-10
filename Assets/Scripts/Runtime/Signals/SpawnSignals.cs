using Runtime.Extensions;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class SpawnSignals : MonoSingleton<SpawnSignals>
    {
        public UnityAction onSetCollectableSpawnData = delegate { };
    }
}